using System;
using System.Linq;
using UniFilteringproject.Data;
using UniFilteringproject.Models;

namespace UniFilteringproject.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // ----- 1️⃣ Seed Malshabs -----
            if (!context.Malshabs.Any())
            {
                var malshabs = new[]
                {
                    new Malshab { Name = "Ariel", Dapar = 60, Profile = 64, IsAssigned = false },
                    new Malshab { Name = "Liran", Dapar = 90, Profile = 97, IsAssigned = false },
                    new Malshab { Name = "Eli", Dapar = 60, Profile = 64, IsAssigned = false }
                };

                context.Malshabs.AddRange(malshabs);
                context.SaveChanges();
            }

            // ----- 2️⃣ Seed Assignments -----
            if (!context.Assignments.Any())
            {
                var assignments = new[]
                {
                    new Assignment { Name = "Paramedic", DaparNeeded = 60, ProfileNeeded = 64, MinMalshabs = 2 },
                    new Assignment { Name = "Fighter", DaparNeeded = 10, ProfileNeeded = 72, MinMalshabs = 3 }
                };

                context.Assignments.AddRange(assignments);
                context.SaveChanges();
            }

            // ----- 3️⃣ Seed Ability -----
            if (!context.Abilities.Any())
            {
                var abilities = new[]
                {
                    new Ability { Name = "Leadership" }
                };

                context.Abilities.AddRange(abilities);
                context.SaveChanges();
            }

            // ----- 4️⃣ Seed MalAss relationships -----
            if (!context.MalAss.Any())
            {
                var malshabs = context.Malshabs.ToList();
                var assignments = context.Assignments.ToList();

                context.MalAss.Add(new MalAss { MalshabId = malshabs[0].Id, AssignmentId = assignments[0].Id });
                context.MalAss.Add(new MalAss { MalshabId = malshabs[1].Id, AssignmentId = assignments[1].Id });
                context.MalAss.Add(new MalAss { MalshabId = malshabs[2].Id, AssignmentId = assignments[0].Id });

                context.SaveChanges();
            }

            // ----- 5️⃣ Seed MalAbi relationships -----
            if (!context.MalAbi.Any())
            {
                var malshabs = context.Malshabs.ToList();
                var ability = context.Abilities.First();

                foreach (var malshab in malshabs)
                {
                    context.MalAbi.Add(new MalAbi
                    {
                        MalshabId = malshab.Id,
                        AbilityId = ability.Id
                    });
                }

                context.SaveChanges();
            }

            // ----- 6️⃣ Seed AssAbi relationships -----
            if (!context.AssAbi.Any())
            {
                var assignments = context.Assignments.ToList();
                var ability = context.Abilities.First();

                foreach (var assignment in assignments)
                {
                    context.AssAbi.Add(new AssAbi
                    {
                        AssignmentId = assignment.Id,
                        AbilityId = ability.Id
                    });
                }

                context.SaveChanges();
            }

            Console.WriteLine("--> SEEDING COMPLETE!");
        }
    }
}