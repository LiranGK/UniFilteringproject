using System;
using System.Linq;
using System.Collections.Generic;
using UniFilteringproject.Data;
using UniFilteringproject.Models;
using Microsoft.EntityFrameworkCore;

namespace UniFilteringproject.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Ensures the database exists and schema is created
            context.Database.Migrate();

            // 1. Seed Abilities
            if (!context.Abilities.Any())
            {
                context.Abilities.AddRange(new List<Ability>
                {
                    new Ability { Name = "Leadership", Description = "temp" },
                    new Ability { Name = "Stamina", Description = "temp" },
                    new Ability { Name = "Technical", Description = "temp" }
                });
                context.SaveChanges();
            }

            // 2. Seed Malshabs (Candidates)
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

            // 3. Seed Assignments (Jobs/Roles)
            if (!context.Assignments.Any())
            {
                context.Assignments.AddRange(new List<Assignment>
                {
                    new Assignment
                    {
                        Name = "Paramedic",
                        DaparNeeded = 60,
                        ProfileNeeded = 64,
                        MinMalshabs = 2,
                        Description = "temp"
                    },
                    new Assignment
                    {
                        Name = "Fighter",
                        DaparNeeded = 10,
                        ProfileNeeded = 72,
                        MinMalshabs = 3,
                        Description = "temp"
                    }
                });
                context.SaveChanges();
            }

            // Retrieve the data we just saved to get their generated Database IDs
            var malshabs = context.Malshabs.ToList();
            var assignments = context.Assignments.ToList();
            var abilities = context.Abilities.ToList();

            // 4. Seed MalAss (Assign Malshabs to Jobs)[currently not needed]
            if (!context.MalAss.Any())
            {
             
            }

            // 5. Seed MalAbi (Candidate Ability Levels)
            if (!context.MalAbi.Any())
            {
                // Ariel has Leadership Level 4
                context.MalAbi.Add(new MalAbi
                {
                    MalshabId = malshabs[0].Id,
                    AbilityId = abilities[0].Id, // Leadership
                    AbiLevel = 4
                });
                // Ariel has Stamina Level 4
                context.MalAbi.Add(new MalAbi
                {
                    MalshabId = malshabs[0].Id,
                    AbilityId = abilities[1].Id, // Leadership
                    AbiLevel = 4
                });
                // Liran has Leadership Level 5
                context.MalAbi.Add(new MalAbi
                {
                    MalshabId = malshabs[1].Id,
                    AbilityId = abilities[0].Id, // Leadership
                    AbiLevel = 5
                });
                // Liran has Stamina Level 4
                context.MalAbi.Add(new MalAbi
                {
                    MalshabId = malshabs[1].Id,
                    AbilityId = abilities[1].Id, // Leadership
                    AbiLevel = 4
                });
                // Eli has Leadership Level 3
                context.MalAbi.Add(new MalAbi
                {
                    MalshabId = malshabs[2].Id,
                    AbilityId = abilities[0].Id, // Leadership
                    AbiLevel = 3
                });
                // Eli has Stamina Level 2
                context.MalAbi.Add(new MalAbi
                {
                    MalshabId = malshabs[2].Id,
                    AbilityId = abilities[1].Id, // Leadership
                    AbiLevel = 2
                });
            }

            // 6. Seed AssAbi (Assignment Ability Requirements)
            if (!context.AssAbi.Any())
            {
                // Paramedic requires Leadership (Level 4)
                context.AssAbi.Add(new AssAbi
                {
                    AssignmentId = assignments[0].Id,
                    AbilityId = abilities[0].Id,
                    AbiLevel = 4
                });

                // Fighter requires Stamina (Level 3)
                context.AssAbi.Add(new AssAbi
                {
                    AssignmentId = assignments[1].Id,
                    AbilityId = abilities[1].Id,
                    AbiLevel = 3
                });
            }

            context.SaveChanges();
        }
    }
}