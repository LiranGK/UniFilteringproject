using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniFilteringproject.Data;
using UniFilteringproject.Models;
using Microsoft.Extensions.DependencyInjection;

namespace UniFilteringproject.Data
{
    public static class SeedData
    {
        // 1. Initialize for App Data
        public static async Task Initialize(IServiceProvider serviceProvider, ApplicationDbContext context)
        {
            context.Database.Migrate();

            // 2. Seed Abilities
            if (!context.Abilities.Any())
            {
                context.Abilities.AddRange(new List<Ability>
                {
                    new Ability { Name = "Leadership", Description = "Capacity to lead teams" },
                    new Ability { Name = "Stamina", Description = "Physical endurance" },
                    new Ability { Name = "Technical", Description = "Technical and engineering skills" }
                });
                context.SaveChanges();
            }

            // 3. Seed Malshabs
            if (!context.Malshabs.Any())
            {
                context.Malshabs.AddRange(new List<Malshab>
                {
                    new Malshab { Name = "Ariel", Dapar = 60, Profile = 64 },
                    new Malshab { Name = "Liran", Dapar = 90, Profile = 97 },
                    new Malshab { Name = "Eli", Dapar = 60, Profile = 64}
                });
                context.SaveChanges();
            }

            // 4. Seed Assignments
            if (!context.Assignments.Any())
            {
                context.Assignments.AddRange(new List<Assignment>
                {
                    new Assignment { Name = "Paramedic", DaparNeeded = 60, ProfileNeeded = 64, MinMalshabs = 2, Description = "Medical responder" },
                    new Assignment { Name = "Fighter", DaparNeeded = 10, ProfileNeeded = 72, MinMalshabs = 3, Description = "Combat personnel" }
                });
                context.SaveChanges();
            }

            var malshabs = context.Malshabs.ToList();
            var assignments = context.Assignments.ToList();
            var abilities = context.Abilities.ToList();

            // 5. Seed Malshab Abilities (Ensure context.MalAbis is the correct property name)
            if (!context.MalAbi.Any())
            {
                context.MalAbi.AddRange(new List<MalAbi>
                {
                    new MalAbi { MalshabId = malshabs[0].Id, AbilityId = abilities[0].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[0].Id, AbilityId = abilities[1].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[1].Id, AbilityId = abilities[0].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[1].Id, AbilityId = abilities[1].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[2].Id, AbilityId = abilities[0].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[2].Id, AbilityId = abilities[1].Id, AbiLevel = 2 }
                });
            }

            // 6. Seed Assignment Requirements
            if (!context.AssAbi.Any())
            {
                context.AssAbi.AddRange(new List<AssAbi>
                {
                    new AssAbi { AssignmentId = assignments[0].Id, AbilityId = abilities[0].Id, AbiLevel = 4 },
                    new AssAbi { AssignmentId = assignments[1].Id, AbilityId = abilities[1].Id, AbiLevel = 3 }
                });
            }

            context.SaveChanges();
        }

        // 7. Separate Identity Seeding logic to match your Program.cs call
        public static async Task InitializeIdentity(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Ensure roles exist
            string[] roleNames = { "Admin", "Moderator", "DataInputer" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Dictionary format: Email -> (FullName, Role, Password)
            var usersToSeed = new Dictionary<string, (string FullName, string Role, string Password)>
            {
                { "roie@admin.com", ("RoieAlima", "Admin", "IAmGod<3") },
                { "mod1@example.com", ("ModeratorOne", "Moderator", "User123!") },
                { "mod2@example.com", ("ModeratorTwo", "Moderator", "User123!") },
                { "data1@example.com", ("DataEntryUser", "DataInputer", "User123!") },
                { "data2@example.com", ("DataEntryAssistant", "DataInputer", "User123!") }
            };

            foreach (var entry in usersToSeed)
            {
                var userEmail = entry.Key;
                var (fullName, role, password) = entry.Value;

                var user = await userManager.FindByEmailAsync(userEmail);
                if (user == null)
                {
                    user = new ApplicationUser
                    {
                        // CRITICAL: UserName must be the Email for default Identity Login to work
                        UserName = userEmail,
                        Email = userEmail,
                        FullName = fullName,
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, role);
                    }
                }
                else
                {
                    // REPAIR LOGIC: Ensure the UserName and Normalized fields are synced with the Email
                    bool needsUpdate = false;

                    if (user.UserName != userEmail)
                    {
                        user.UserName = userEmail;
                        needsUpdate = true;
                    }

                    if (needsUpdate)
                    {
                        // This updates the NormalizedUserName and NormalizedEmail fields in the DB
                        await userManager.UpdateAsync(user);
                        await userManager.UpdateNormalizedUserNameAsync(user);
                        await userManager.UpdateNormalizedEmailAsync(user);
                    }
                }
            }
        }
    }
}