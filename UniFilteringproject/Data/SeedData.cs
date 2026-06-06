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
                    new Ability { Name = "Information processing", Description = "Efficiently analyzing, organizing, and interpreting complex data and insights" },
                    new Ability { Name = "organizational management", Description = "Leading structural operations, optimizing workflows, and coordinating resources effectively" },
                    new Ability { Name = "technical operation", Description = "Expertly managing, maintaining, and troubleshooting technical systems and equipment" },
                    new Ability { Name = "Teamwork", Description = "Collaborating effectively with diverse teams to achieve shared goals" },
                    new Ability { Name = "initiative and leadership", Description = "Driving progress, inspiring others, and proactively taking ownership of projects" },
                    new Ability { Name = "influence", Description = "Persuading others and driving positive change across the organization" },
                    new Ability { Name = "guidance", Description = "Guiding, educating, and developing skills in individuals and teams" },
                    new Ability { Name = "functioning in stressful situations", Description = "Maintaining focus and delivering high-quality results in stressful environments" },
                    new Ability { Name = "Maturity and independence", Description = "Working autonomously with high accountability and professional judgment" },
                    new Ability { Name = "order and organization", Description = "Keeping tasks, schedules, and environments structured and efficient" },
                    new Ability { Name = "communication", Description = "Conveying ideas clearly and building strong professional relationships" }
                });
                context.SaveChanges();
            }

            // 3. Seed Malshabs
            if (!context.Malshabs.Any())
            {
                context.Malshabs.AddRange(new List<Malshab>
                {
                    new Malshab { Name = "Ariel", Dapar = 60, Profile = 64 },
                    new Malshab { Name = "Liran", Dapar = 90, Profile = 72 },
                    new Malshab { Name = "Itay", Dapar = 70, Profile = 72 },
                    new Malshab { Name = "Ori", Dapar = 90, Profile = 82 },
                    new Malshab { Name = "Daniel", Dapar = 80, Profile = 97 },
                    new Malshab { Name = "Idan", Dapar = 60, Profile = 64 },
                    new Malshab { Name = "Amit", Dapar = 90, Profile = 97 },
                    new Malshab { Name = "Yosef", Dapar = 50, Profile = 45 },
                    new Malshab { Name = "Omer", Dapar = 80, Profile = 72 },
                    new Malshab { Name = "Roee", Dapar = 70, Profile = 97 },
                    new Malshab { Name = "Ben", Dapar = 90, Profile = 82 },
                    new Malshab { Name = "Eitan", Dapar = 80, Profile = 64 },
                    new Malshab { Name = "Tom", Dapar = 40, Profile = 64 },
                    new Malshab { Name = "Guy", Dapar = 90, Profile = 97 },
                    new Malshab { Name = "David", Dapar = 70, Profile = 82 },
                    new Malshab { Name = "Lior", Dapar = 80, Profile = 97 },
                    new Malshab { Name = "Jonathan", Dapar = 90, Profile = 72 },
                    new Malshab { Name = "Asaf", Dapar = 60, Profile = 82 },
                    new Malshab { Name = "Nadav", Dapar = 80, Profile = 97 },
                    new Malshab { Name = "Matan", Dapar = 70, Profile = 64 },
                    new Malshab { Name = "Ofek", Dapar = 90, Profile = 82 },
                    new Malshab { Name = "Yuval", Dapar = 80, Profile = 72 },
                    new Malshab { Name = "Harel", Dapar = 30, Profile = 30 },
                    new Malshab { Name = "Elai", Dapar = 90, Profile = 97 },
                    new Malshab { Name = "Shon", Dapar = 70, Profile = 82 },
                    new Malshab { Name = "Ron", Dapar = 80, Profile = 45 },
                    new Malshab { Name = "Bar", Dapar = 60, Profile = 97 },
                    new Malshab { Name = "Dor", Dapar = 90, Profile = 82 },
                    new Malshab { Name = "Tal", Dapar = 70, Profile = 72 },
                    new Malshab { Name = "Eyal", Dapar = 80, Profile = 97 },
                    new Malshab { Name = "Nir", Dapar = 90, Profile = 64 },
                    new Malshab { Name = "Gal", Dapar = 50, Profile = 82 },
                    new Malshab { Name = "Aviv", Dapar = 80, Profile = 97 },
                    new Malshab { Name = "Ilai", Dapar = 70, Profile = 72 },
                    new Malshab { Name = "Gil", Dapar = 90, Profile = 82 },
                    new Malshab { Name = "Shahar", Dapar = 80, Profile = 64 },
                    new Malshab { Name = "Yair", Dapar = 20, Profile = 24 },
                    new Malshab { Name = "Ran", Dapar = 70, Profile = 97 },
                    new Malshab { Name = "Mor", Dapar = 90, Profile = 82 },
                    new Malshab { Name = "Dan", Dapar = 60, Profile = 45 },
                    new Malshab { Name = "Sagi", Dapar = 80, Profile = 97 },
                    new Malshab { Name = "Oz", Dapar = 90, Profile = 72 },
                    new Malshab { Name = "Roni", Dapar = 70, Profile = 82 },
                    new Malshab { Name = "Liam", Dapar = 80, Profile = 97 },
                    new Malshab { Name = "Yazen", Dapar = 10, Profile = 21 },
                    new Malshab { Name = "Alon", Dapar = 90, Profile = 64 },
                    new Malshab { Name = "Moti", Dapar = 70, Profile = 82 },
                    new Malshab { Name = "Adir", Dapar = 80, Profile = 97 },
                    new Malshab { Name = "Ohad", Dapar = 90, Profile = 82 },
                    new Malshab { Name = "Dolev", Dapar = 60, Profile = 72 }
                });
                context.SaveChanges();
            }

            // 4. Seed Assignments
            if (!context.Assignments.Any())
            {
                context.Assignments.AddRange(new List<Assignment>
                {
                    new Assignment
                    {
                        Name = "Programmer",
                        DaparNeeded = 60,
                        ProfileNeeded = 25,
                        MinMalshabs = 3,
                        Description = "Software development and cyber defense in technology units"
                    },
                    new Assignment
                    {
                        Name = "Shachakim",
                        DaparNeeded = 80,
                        ProfileNeeded = 25,
                        MinMalshabs = 2,
                        Description = "Elite intelligence path for data research and analysis"
                    },
                    new Assignment
                    {
                        Name = "Psychotechnic Evaluator",
                        DaparNeeded = 60,
                        ProfileNeeded = 25,
                        MinMalshabs = 4,
                        Description = "Conducting personal interviews and sorting candidates in recruitment centers"
                    },
                    new Assignment
                    {
                        Name = "Simulator Instructor",
                        DaparNeeded = 60,
                        ProfileNeeded = 64,
                        MinMalshabs = 4,
                        Description = "Training combat soldiers using advanced operational simulation systems"
                    },
                    new Assignment
                    {
                        Name = "Border Infantry",
                        DaparNeeded = 40,
                        ProfileNeeded = 72,
                        MinMalshabs = 6,
                        Description = "Combat service for protecting borders and counter-terrorism operations"
                    },
                    new Assignment
                    {
                        Name = "Operations Room Sergeant",
                        DaparNeeded = 40,
                        ProfileNeeded = 25,
                        MinMalshabs = 5,
                        Description = "Managing military operations centers and coordinating real-time forces"
                    },
                    new Assignment
                    {
                        Name = "Network Administrator",
                        DaparNeeded = 40,
                        ProfileNeeded = 25,
                        MinMalshabs = 4,
                        Description = "Managing communication infrastructures and technical computer network support"
                    },
                    new Assignment
                    {
                        Name = "Logistics Coordinator",
                        DaparNeeded = 10,
                        ProfileNeeded = 25,
                        MinMalshabs = 6,
                        Description = "Organizing, managing, and supplying equipment in military bases"
                    },
                    new Assignment
                    {
                        Name = "Meitav Service Representative",
                        DaparNeeded = 10,
                        ProfileNeeded = 25,
                        MinMalshabs = 5,
                        Description = "Providing phone support and assistance to candidates before enlistment"
                    },
                    new Assignment
                    {
                        Name = "Office Administrator",
                        DaparNeeded = 10,
                        ProfileNeeded = 25,
                        MinMalshabs = 6,
                        Description = "Managing schedules and administrative paperwork in senior officers' bureaus"
                    }
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
                    // --- מלש"ב 0: Ariel ---
                    new MalAbi { MalshabId = malshabs[0].Id, AbilityId = abilities[0].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[0].Id, AbilityId = abilities[1].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[0].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[0].Id, AbilityId = abilities[3].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[0].Id, AbilityId = abilities[4].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[0].Id, AbilityId = abilities[5].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[0].Id, AbilityId = abilities[6].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[0].Id, AbilityId = abilities[7].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[0].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[0].Id, AbilityId = abilities[9].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[0].Id, AbilityId = abilities[10].Id, AbiLevel = 4 },

                    // --- מלש"ב 1: Liran ---
                    new MalAbi { MalshabId = malshabs[1].Id, AbilityId = abilities[0].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[1].Id, AbilityId = abilities[1].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[1].Id, AbilityId = abilities[2].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[1].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[1].Id, AbilityId = abilities[4].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[1].Id, AbilityId = abilities[5].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[1].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[1].Id, AbilityId = abilities[7].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[1].Id, AbilityId = abilities[8].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[1].Id, AbilityId = abilities[9].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[1].Id, AbilityId = abilities[10].Id, AbiLevel = 3 },

                    // --- מלש"ב 2: Itay ---
                    new MalAbi { MalshabId = malshabs[2].Id, AbilityId = abilities[0].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[2].Id, AbilityId = abilities[1].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[2].Id, AbilityId = abilities[2].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[2].Id, AbilityId = abilities[3].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[2].Id, AbilityId = abilities[4].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[2].Id, AbilityId = abilities[5].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[2].Id, AbilityId = abilities[6].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[2].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[2].Id, AbilityId = abilities[8].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[2].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[2].Id, AbilityId = abilities[10].Id, AbiLevel = 5 },

                    // --- מלש"ב 3: Ori ---
                    new MalAbi { MalshabId = malshabs[3].Id, AbilityId = abilities[0].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[3].Id, AbilityId = abilities[1].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[3].Id, AbilityId = abilities[2].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[3].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[3].Id, AbilityId = abilities[4].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[3].Id, AbilityId = abilities[5].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[3].Id, AbilityId = abilities[6].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[3].Id, AbilityId = abilities[7].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[3].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[3].Id, AbilityId = abilities[9].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[3].Id, AbilityId = abilities[10].Id, AbiLevel = 4 },

                    // --- מלש"ב 4: Daniel ---
                    new MalAbi { MalshabId = malshabs[4].Id, AbilityId = abilities[0].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[4].Id, AbilityId = abilities[1].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[4].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[4].Id, AbilityId = abilities[3].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[4].Id, AbilityId = abilities[4].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[4].Id, AbilityId = abilities[5].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[4].Id, AbilityId = abilities[6].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[4].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[4].Id, AbilityId = abilities[8].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[4].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[4].Id, AbilityId = abilities[10].Id, AbiLevel = 5 },

                    // --- מלש"ב 5: Idan ---
                    new MalAbi { MalshabId = malshabs[5].Id, AbilityId = abilities[0].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[5].Id, AbilityId = abilities[1].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[5].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[5].Id, AbilityId = abilities[3].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[5].Id, AbilityId = abilities[4].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[5].Id, AbilityId = abilities[5].Id, AbiLevel = 1 },
                    new MalAbi { MalshabId = malshabs[5].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[5].Id, AbilityId = abilities[7].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[5].Id, AbilityId = abilities[8].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[5].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[5].Id, AbilityId = abilities[10].Id, AbiLevel = 2 },

                    // --- מלש"ב 6: Amit ---
                    new MalAbi { MalshabId = malshabs[6].Id, AbilityId = abilities[0].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[6].Id, AbilityId = abilities[1].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[6].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[6].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[6].Id, AbilityId = abilities[4].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[6].Id, AbilityId = abilities[5].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[6].Id, AbilityId = abilities[6].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[6].Id, AbilityId = abilities[7].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[6].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[6].Id, AbilityId = abilities[9].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[6].Id, AbilityId = abilities[10].Id, AbiLevel = 5 },

                    // --- מלש"ב 7: Yosef ---
                    new MalAbi { MalshabId = malshabs[7].Id, AbilityId = abilities[0].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[7].Id, AbilityId = abilities[1].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[7].Id, AbilityId = abilities[2].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[7].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[7].Id, AbilityId = abilities[4].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[7].Id, AbilityId = abilities[5].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[7].Id, AbilityId = abilities[6].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[7].Id, AbilityId = abilities[7].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[7].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[7].Id, AbilityId = abilities[9].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[7].Id, AbilityId = abilities[10].Id, AbiLevel = 3 },

                    // --- מלש"ב 8: Omer ---
                    new MalAbi { MalshabId = malshabs[8].Id, AbilityId = abilities[0].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[8].Id, AbilityId = abilities[1].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[8].Id, AbilityId = abilities[2].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[8].Id, AbilityId = abilities[3].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[8].Id, AbilityId = abilities[4].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[8].Id, AbilityId = abilities[5].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[8].Id, AbilityId = abilities[6].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[8].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[8].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[8].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[8].Id, AbilityId = abilities[10].Id, AbiLevel = 4 },

                    // --- מלש"ב 9: Roee ---
                    new MalAbi { MalshabId = malshabs[9].Id, AbilityId = abilities[0].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[9].Id, AbilityId = abilities[1].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[9].Id, AbilityId = abilities[2].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[9].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[9].Id, AbilityId = abilities[4].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[9].Id, AbilityId = abilities[5].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[9].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[9].Id, AbilityId = abilities[7].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[9].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[9].Id, AbilityId = abilities[9].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[9].Id, AbilityId = abilities[10].Id, AbiLevel = 4 },

                    // --- מלש"ב 10: Ben ---
                    new MalAbi { MalshabId = malshabs[10].Id, AbilityId = abilities[0].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[10].Id, AbilityId = abilities[1].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[10].Id, AbilityId = abilities[2].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[10].Id, AbilityId = abilities[3].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[10].Id, AbilityId = abilities[4].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[10].Id, AbilityId = abilities[5].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[10].Id, AbilityId = abilities[6].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[10].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[10].Id, AbilityId = abilities[8].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[10].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[10].Id, AbilityId = abilities[10].Id, AbiLevel = 4 },

                    // --- מלש"ב 11: Eitan ---
                    new MalAbi { MalshabId = malshabs[11].Id, AbilityId = abilities[0].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[11].Id, AbilityId = abilities[1].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[11].Id, AbilityId = abilities[2].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[11].Id, AbilityId = abilities[3].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[11].Id, AbilityId = abilities[4].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[11].Id, AbilityId = abilities[5].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[11].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[11].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[11].Id, AbilityId = abilities[8].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[11].Id, AbilityId = abilities[9].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[11].Id, AbilityId = abilities[10].Id, AbiLevel = 3 },

                    // --- מלש"ב 12: Tom ---
                    new MalAbi { MalshabId = malshabs[12].Id, AbilityId = abilities[0].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[12].Id, AbilityId = abilities[1].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[12].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[12].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[12].Id, AbilityId = abilities[4].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[12].Id, AbilityId = abilities[5].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[12].Id, AbilityId = abilities[6].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[12].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[12].Id, AbilityId = abilities[8].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[12].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[12].Id, AbilityId = abilities[10].Id, AbiLevel = 2 },

                    // --- מלש"ב 13: Guy ---
                    new MalAbi { MalshabId = malshabs[13].Id, AbilityId = abilities[0].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[13].Id, AbilityId = abilities[1].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[13].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[13].Id, AbilityId = abilities[3].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[13].Id, AbilityId = abilities[4].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[13].Id, AbilityId = abilities[5].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[13].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[13].Id, AbilityId = abilities[7].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[13].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[13].Id, AbilityId = abilities[9].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[13].Id, AbilityId = abilities[10].Id, AbiLevel = 5 },

                    // --- מלש"ב 14: David ---
                    new MalAbi { MalshabId = malshabs[14].Id, AbilityId = abilities[0].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[14].Id, AbilityId = abilities[1].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[14].Id, AbilityId = abilities[2].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[14].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[14].Id, AbilityId = abilities[4].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[14].Id, AbilityId = abilities[5].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[14].Id, AbilityId = abilities[6].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[14].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[14].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[14].Id, AbilityId = abilities[9].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[14].Id, AbilityId = abilities[10].Id, AbiLevel = 4 },

                    // --- מלש"ב 15: Lior ---
                    new MalAbi { MalshabId = malshabs[15].Id, AbilityId = abilities[0].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[15].Id, AbilityId = abilities[1].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[15].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[15].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[15].Id, AbilityId = abilities[4].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[15].Id, AbilityId = abilities[5].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[15].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[15].Id, AbilityId = abilities[7].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[15].Id, AbilityId = abilities[8].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[15].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[15].Id, AbilityId = abilities[10].Id, AbiLevel = 3 },

                    // --- מלש"ב 16: Jonathan ---
                    new MalAbi { MalshabId = malshabs[16].Id, AbilityId = abilities[0].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[16].Id, AbilityId = abilities[1].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[16].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[16].Id, AbilityId = abilities[3].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[16].Id, AbilityId = abilities[4].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[16].Id, AbilityId = abilities[5].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[16].Id, AbilityId = abilities[6].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[16].Id, AbilityId = abilities[7].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[16].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[16].Id, AbilityId = abilities[9].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[16].Id, AbilityId = abilities[10].Id, AbiLevel = 5 },

                    // --- מלש"ב 17: Asaf ---
                    new MalAbi { MalshabId = malshabs[17].Id, AbilityId = abilities[0].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[17].Id, AbilityId = abilities[1].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[17].Id, AbilityId = abilities[2].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[17].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[17].Id, AbilityId = abilities[4].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[17].Id, AbilityId = abilities[5].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[17].Id, AbilityId = abilities[6].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[17].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[17].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[17].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[17].Id, AbilityId = abilities[10].Id, AbiLevel = 3 },

                    // --- מלש"ב 18: Nadav ---
                    new MalAbi { MalshabId = malshabs[18].Id, AbilityId = abilities[0].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[18].Id, AbilityId = abilities[1].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[18].Id, AbilityId = abilities[2].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[18].Id, AbilityId = abilities[3].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[18].Id, AbilityId = abilities[4].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[18].Id, AbilityId = abilities[5].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[18].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[18].Id, AbilityId = abilities[7].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[18].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[18].Id, AbilityId = abilities[9].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[18].Id, AbilityId = abilities[10].Id, AbiLevel = 4 },

                    // --- מלש"ב 19: Matan ---
                    new MalAbi { MalshabId = malshabs[19].Id, AbilityId = abilities[0].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[19].Id, AbilityId = abilities[1].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[19].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[19].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[19].Id, AbilityId = abilities[4].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[19].Id, AbilityId = abilities[5].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[19].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[19].Id, AbilityId = abilities[7].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[19].Id, AbilityId = abilities[8].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[19].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[19].Id, AbilityId = abilities[10].Id, AbiLevel = 3 },

                    // --- מלש"ב 20: Ofek ---
                    new MalAbi { MalshabId = malshabs[20].Id, AbilityId = abilities[0].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[20].Id, AbilityId = abilities[1].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[20].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[20].Id, AbilityId = abilities[3].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[20].Id, AbilityId = abilities[4].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[20].Id, AbilityId = abilities[5].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[20].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[20].Id, AbilityId = abilities[7].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[20].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[20].Id, AbilityId = abilities[9].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[20].Id, AbilityId = abilities[10].Id, AbiLevel = 4 },

                    // --- מלש"ב 21: Yuval ---
                    new MalAbi { MalshabId = malshabs[21].Id, AbilityId = abilities[0].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[21].Id, AbilityId = abilities[1].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[21].Id, AbilityId = abilities[2].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[21].Id, AbilityId = abilities[3].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[21].Id, AbilityId = abilities[4].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[21].Id, AbilityId = abilities[5].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[21].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[21].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[21].Id, AbilityId = abilities[8].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[21].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[21].Id, AbilityId = abilities[10].Id, AbiLevel = 3 },

                    // --- מלש"ב 22: Harel ---
                    new MalAbi { MalshabId = malshabs[22].Id, AbilityId = abilities[0].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[22].Id, AbilityId = abilities[1].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[22].Id, AbilityId = abilities[2].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[22].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[22].Id, AbilityId = abilities[4].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[22].Id, AbilityId = abilities[5].Id, AbiLevel = 1 },
                    new MalAbi { MalshabId = malshabs[22].Id, AbilityId = abilities[6].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[22].Id, AbilityId = abilities[7].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[22].Id, AbilityId = abilities[8].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[22].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[22].Id, AbilityId = abilities[10].Id, AbiLevel = 3 },

                    // --- מלש"ב 23: Elai ---
                    new MalAbi { MalshabId = malshabs[23].Id, AbilityId = abilities[0].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[23].Id, AbilityId = abilities[1].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[23].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[23].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[23].Id, AbilityId = abilities[4].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[23].Id, AbilityId = abilities[5].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[23].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[23].Id, AbilityId = abilities[7].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[23].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[23].Id, AbilityId = abilities[9].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[23].Id, AbilityId = abilities[10].Id, AbiLevel = 5 },

                    // --- מלש"ב 24: Shon ---
                    new MalAbi { MalshabId = malshabs[24].Id, AbilityId = abilities[0].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[24].Id, AbilityId = abilities[1].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[24].Id, AbilityId = abilities[2].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[24].Id, AbilityId = abilities[3].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[24].Id, AbilityId = abilities[4].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[24].Id, AbilityId = abilities[5].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[24].Id, AbilityId = abilities[6].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[24].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[24].Id, AbilityId = abilities[8].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[24].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[24].Id, AbilityId = abilities[10].Id, AbiLevel = 4 },

                    // --- מלש"ב 25: Ron ---
                    new MalAbi { MalshabId = malshabs[25].Id, AbilityId = abilities[0].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[25].Id, AbilityId = abilities[1].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[25].Id, AbilityId = abilities[2].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[25].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[25].Id, AbilityId = abilities[4].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[25].Id, AbilityId = abilities[5].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[25].Id, AbilityId = abilities[6].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[25].Id, AbilityId = abilities[7].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[25].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[25].Id, AbilityId = abilities[9].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[25].Id, AbilityId = abilities[10].Id, AbiLevel = 3 },

                    // --- מלש"ב 26: Bar ---
                    new MalAbi { MalshabId = malshabs[26].Id, AbilityId = abilities[0].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[26].Id, AbilityId = abilities[1].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[26].Id, AbilityId = abilities[2].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[26].Id, AbilityId = abilities[3].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[26].Id, AbilityId = abilities[4].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[26].Id, AbilityId = abilities[5].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[26].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[26].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[26].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[26].Id, AbilityId = abilities[9].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[26].Id, AbilityId = abilities[10].Id, AbiLevel = 5 },

                    // --- מלש"ב 27: Dor ---
                    new MalAbi { MalshabId = malshabs[27].Id, AbilityId = abilities[0].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[27].Id, AbilityId = abilities[1].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[27].Id, AbilityId = abilities[2].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[27].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[27].Id, AbilityId = abilities[4].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[27].Id, AbilityId = abilities[5].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[27].Id, AbilityId = abilities[6].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[27].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[27].Id, AbilityId = abilities[8].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[27].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[27].Id, AbilityId = abilities[10].Id, AbiLevel = 4 },

                    // --- מלש"ב 28: Tal ---
                    new MalAbi { MalshabId = malshabs[28].Id, AbilityId = abilities[0].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[28].Id, AbilityId = abilities[1].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[28].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[28].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[28].Id, AbilityId = abilities[4].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[28].Id, AbilityId = abilities[5].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[28].Id, AbilityId = abilities[6].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[28].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[28].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[28].Id, AbilityId = abilities[9].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[28].Id, AbilityId = abilities[10].Id, AbiLevel = 4 },

                    // --- מלש"ב 29: Eyal ---
                    new MalAbi { MalshabId = malshabs[29].Id, AbilityId = abilities[0].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[29].Id, AbilityId = abilities[1].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[29].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[29].Id, AbilityId = abilities[3].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[29].Id, AbilityId = abilities[4].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[29].Id, AbilityId = abilities[5].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[29].Id, AbilityId = abilities[6].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[29].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[29].Id, AbilityId = abilities[8].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[29].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[29].Id, AbilityId = abilities[10].Id, AbiLevel = 3 },

                    // --- מלש"ב 30: Nir ---
                    new MalAbi { MalshabId = malshabs[30].Id, AbilityId = abilities[0].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[30].Id, AbilityId = abilities[1].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[30].Id, AbilityId = abilities[2].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[30].Id, AbilityId = abilities[3].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[30].Id, AbilityId = abilities[4].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[30].Id, AbilityId = abilities[5].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[30].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[30].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[30].Id, AbilityId = abilities[8].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[30].Id, AbilityId = abilities[9].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[30].Id, AbilityId = abilities[10].Id, AbiLevel = 4 },

                    // --- מלש"ב 31: Gal ---
                    new MalAbi { MalshabId = malshabs[31].Id, AbilityId = abilities[0].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[31].Id, AbilityId = abilities[1].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[31].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[31].Id, AbilityId = abilities[3].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[31].Id, AbilityId = abilities[4].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[31].Id, AbilityId = abilities[5].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[31].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[31].Id, AbilityId = abilities[7].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[31].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[31].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[31].Id, AbilityId = abilities[10].Id, AbiLevel = 5 },

                    // --- מלש"ב 32: Aviv ---
                    new MalAbi { MalshabId = malshabs[32].Id, AbilityId = abilities[0].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[32].Id, AbilityId = abilities[1].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[32].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[32].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[32].Id, AbilityId = abilities[4].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[32].Id, AbilityId = abilities[5].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[32].Id, AbilityId = abilities[6].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[32].Id, AbilityId = abilities[7].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[32].Id, AbilityId = abilities[8].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[32].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[32].Id, AbilityId = abilities[10].Id, AbiLevel = 4 },

                    // --- מלש"ב 33: Ilai ---
                    new MalAbi { MalshabId = malshabs[33].Id, AbilityId = abilities[0].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[33].Id, AbilityId = abilities[1].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[33].Id, AbilityId = abilities[2].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[33].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[33].Id, AbilityId = abilities[4].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[33].Id, AbilityId = abilities[5].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[33].Id, AbilityId = abilities[6].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[33].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[33].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[33].Id, AbilityId = abilities[9].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[33].Id, AbilityId = abilities[10].Id, AbiLevel = 4 },

                    // --- מלש"ב 34: Gil ---
                    new MalAbi { MalshabId = malshabs[34].Id, AbilityId = abilities[0].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[34].Id, AbilityId = abilities[1].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[34].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[34].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[34].Id, AbilityId = abilities[4].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[34].Id, AbilityId = abilities[5].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[34].Id, AbilityId = abilities[6].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[34].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[34].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[34].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[34].Id, AbilityId = abilities[10].Id, AbiLevel = 5 },

                    // --- מלש"ב 35: Shahar ---
                    new MalAbi { MalshabId = malshabs[35].Id, AbilityId = abilities[0].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[35].Id, AbilityId = abilities[1].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[35].Id, AbilityId = abilities[2].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[35].Id, AbilityId = abilities[3].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[35].Id, AbilityId = abilities[4].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[35].Id, AbilityId = abilities[5].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[35].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[35].Id, AbilityId = abilities[7].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[35].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[35].Id, AbilityId = abilities[9].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[35].Id, AbilityId = abilities[10].Id, AbiLevel = 3 },

                    // --- מלש"ב 36: Yair ---
                    new MalAbi { MalshabId = malshabs[36].Id, AbilityId = abilities[0].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[36].Id, AbilityId = abilities[1].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[36].Id, AbilityId = abilities[2].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[36].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[36].Id, AbilityId = abilities[4].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[36].Id, AbilityId = abilities[5].Id, AbiLevel = 1 },
                    new MalAbi { MalshabId = malshabs[36].Id, AbilityId = abilities[6].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[36].Id, AbilityId = abilities[7].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[36].Id, AbilityId = abilities[8].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[36].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[36].Id, AbilityId = abilities[10].Id, AbiLevel = 2 },

                    // --- מלש"ב 37: Ran ---
                    new MalAbi { MalshabId = malshabs[37].Id, AbilityId = abilities[0].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[37].Id, AbilityId = abilities[1].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[37].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[37].Id, AbilityId = abilities[3].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[37].Id, AbilityId = abilities[4].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[37].Id, AbilityId = abilities[5].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[37].Id, AbilityId = abilities[6].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[37].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[37].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[37].Id, AbilityId = abilities[9].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[37].Id, AbilityId = abilities[10].Id, AbiLevel = 5 },

                    // --- מלש"ב 38: Mor ---
                    new MalAbi { MalshabId = malshabs[38].Id, AbilityId = abilities[0].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[38].Id, AbilityId = abilities[1].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[38].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[38].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[38].Id, AbilityId = abilities[4].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[38].Id, AbilityId = abilities[5].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[38].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[38].Id, AbilityId = abilities[7].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[38].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[38].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[38].Id, AbilityId = abilities[10].Id, AbiLevel = 5 },

                    // --- מלש"ב 39: Dan ---
                    new MalAbi { MalshabId = malshabs[39].Id, AbilityId = abilities[0].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[39].Id, AbilityId = abilities[1].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[39].Id, AbilityId = abilities[2].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[39].Id, AbilityId = abilities[3].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[39].Id, AbilityId = abilities[4].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[39].Id, AbilityId = abilities[5].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[39].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[39].Id, AbilityId = abilities[7].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[39].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[39].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[39].Id, AbilityId = abilities[10].Id, AbiLevel = 3 },

                    // --- מלש"ב 40: Sagi ---
                    new MalAbi { MalshabId = malshabs[40].Id, AbilityId = abilities[0].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[40].Id, AbilityId = abilities[1].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[40].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[40].Id, AbilityId = abilities[3].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[40].Id, AbilityId = abilities[4].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[40].Id, AbilityId = abilities[5].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[40].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[40].Id, AbilityId = abilities[7].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[40].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[40].Id, AbilityId = abilities[9].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[40].Id, AbilityId = abilities[10].Id, AbiLevel = 4 },

                    // --- מלש"ב 41: Oz ---
                    new MalAbi { MalshabId = malshabs[41].Id, AbilityId = abilities[0].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[41].Id, AbilityId = abilities[1].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[41].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[41].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[41].Id, AbilityId = abilities[4].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[41].Id, AbilityId = abilities[5].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[41].Id, AbilityId = abilities[6].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[41].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[41].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[41].Id, AbilityId = abilities[9].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[41].Id, AbilityId = abilities[10].Id, AbiLevel = 5 },

                    // --- מלש"ב 42: Roni ---
                    new MalAbi { MalshabId = malshabs[42].Id, AbilityId = abilities[0].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[42].Id, AbilityId = abilities[1].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[42].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[42].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[42].Id, AbilityId = abilities[4].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[42].Id, AbilityId = abilities[5].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[42].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[42].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[42].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[42].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[42].Id, AbilityId = abilities[10].Id, AbiLevel = 4 },

                    // --- מלש"ב 43: Liam ---
                    new MalAbi { MalshabId = malshabs[43].Id, AbilityId = abilities[0].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[43].Id, AbilityId = abilities[1].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[43].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[43].Id, AbilityId = abilities[3].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[43].Id, AbilityId = abilities[4].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[43].Id, AbilityId = abilities[5].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[43].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[43].Id, AbilityId = abilities[7].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[43].Id, AbilityId = abilities[8].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[43].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[43].Id, AbilityId = abilities[10].Id, AbiLevel = 4 },

                    // --- מלש"ב 44: Yazen ---
                    new MalAbi { MalshabId = malshabs[44].Id, AbilityId = abilities[0].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[44].Id, AbilityId = abilities[1].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[44].Id, AbilityId = abilities[2].Id, AbiLevel = 1 },
                    new MalAbi { MalshabId = malshabs[44].Id, AbilityId = abilities[3].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[44].Id, AbilityId = abilities[4].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[44].Id, AbilityId = abilities[5].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[44].Id, AbilityId = abilities[6].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[44].Id, AbilityId = abilities[7].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[44].Id, AbilityId = abilities[8].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[44].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[44].Id, AbilityId = abilities[10].Id, AbiLevel = 3 },

                    // --- מלש"ב 45: Alon ---
                    new MalAbi { MalshabId = malshabs[45].Id, AbilityId = abilities[0].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[45].Id, AbilityId = abilities[1].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[45].Id, AbilityId = abilities[2].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[45].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[45].Id, AbilityId = abilities[4].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[45].Id, AbilityId = abilities[5].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[45].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[45].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[45].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[45].Id, AbilityId = abilities[9].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[45].Id, AbilityId = abilities[10].Id, AbiLevel = 4 },

                    // --- מלש"ב 46: Moti ---
                    new MalAbi { MalshabId = malshabs[46].Id, AbilityId = abilities[0].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[46].Id, AbilityId = abilities[1].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[46].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[46].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[46].Id, AbilityId = abilities[4].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[46].Id, AbilityId = abilities[5].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[46].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[46].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[46].Id, AbilityId = abilities[8].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[46].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[46].Id, AbilityId = abilities[10].Id, AbiLevel = 4 },

                    // --- מלש"ב 47: Adir ---
                    new MalAbi { MalshabId = malshabs[47].Id, AbilityId = abilities[0].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[47].Id, AbilityId = abilities[1].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[47].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[47].Id, AbilityId = abilities[3].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[47].Id, AbilityId = abilities[4].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[47].Id, AbilityId = abilities[5].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[47].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[47].Id, AbilityId = abilities[7].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[47].Id, AbilityId = abilities[8].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[47].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[47].Id, AbilityId = abilities[10].Id, AbiLevel = 4 },

                    // --- מלש"ב 48: Ohad ---
                    new MalAbi { MalshabId = malshabs[48].Id, AbilityId = abilities[0].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[48].Id, AbilityId = abilities[1].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[48].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[48].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[48].Id, AbilityId = abilities[4].Id, AbiLevel = 5 },
                    new MalAbi { MalshabId = malshabs[48].Id, AbilityId = abilities[5].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[48].Id, AbilityId = abilities[6].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[48].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[48].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[48].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[48].Id, AbilityId = abilities[10].Id, AbiLevel = 5 },

                    // --- מלש"ב 49: Dolev ---
                    new MalAbi { MalshabId = malshabs[49].Id, AbilityId = abilities[0].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[49].Id, AbilityId = abilities[1].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[49].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[49].Id, AbilityId = abilities[3].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[49].Id, AbilityId = abilities[4].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[49].Id, AbilityId = abilities[5].Id, AbiLevel = 2 },
                    new MalAbi { MalshabId = malshabs[49].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[49].Id, AbilityId = abilities[7].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[49].Id, AbilityId = abilities[8].Id, AbiLevel = 3 },
                    new MalAbi { MalshabId = malshabs[49].Id, AbilityId = abilities[9].Id, AbiLevel = 4 },
                    new MalAbi { MalshabId = malshabs[49].Id, AbilityId = abilities[10].Id, AbiLevel = 3 }
                });
            }

            // 6. Seed Assignment Requirements
            if (!context.AssAbi.Any())
            {
                context.AssAbi.AddRange(new List<AssAbi>
                {
                    // --- 0. Programmer ---
                    new AssAbi { AssignmentId = assignments[0].Id, AbilityId = abilities[0].Id, AbiLevel = 4 },
                    new AssAbi { AssignmentId = assignments[0].Id, AbilityId = abilities[2].Id, AbiLevel = 4 },

                    // --- 1. Shachakim ---
                    new AssAbi { AssignmentId = assignments[1].Id, AbilityId = abilities[0].Id, AbiLevel = 5 },
                    new AssAbi { AssignmentId = assignments[1].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new AssAbi { AssignmentId = assignments[1].Id, AbilityId = abilities[3].Id, AbiLevel = 3 },

                    // --- 2. Psychotechnic Evaluator ---
                    new AssAbi { AssignmentId = assignments[2].Id, AbilityId = abilities[10].Id, AbiLevel = 4 },
                    new AssAbi { AssignmentId = assignments[2].Id, AbilityId = abilities[8].Id, AbiLevel = 4 },
                    new AssAbi { AssignmentId = assignments[2].Id, AbilityId = abilities[0].Id, AbiLevel = 3 },

                    // --- 3. Simulator Instructor ---
                    new AssAbi { AssignmentId = assignments[3].Id, AbilityId = abilities[6].Id, AbiLevel = 4 },
                    new AssAbi { AssignmentId = assignments[3].Id, AbilityId = abilities[2].Id, AbiLevel = 3 },
                    new AssAbi { AssignmentId = assignments[3].Id, AbilityId = abilities[10].Id, AbiLevel = 3 },

                    // --- 4. Border Infantry ---
                    new AssAbi { AssignmentId = assignments[4].Id, AbilityId = abilities[3].Id, AbiLevel = 3 },
                    new AssAbi { AssignmentId = assignments[4].Id, AbilityId = abilities[7].Id, AbiLevel = 3 },

                    // --- 5. Operations Room Sergeant (סמב"ץ) ---
                    new AssAbi { AssignmentId = assignments[5].Id, AbilityId = abilities[7].Id, AbiLevel = 4 },
                    new AssAbi { AssignmentId = assignments[5].Id, AbilityId = abilities[3].Id, AbiLevel = 3 },

                    // --- 6. Network Administrator ---
                    new AssAbi { AssignmentId = assignments[6].Id, AbilityId = abilities[2].Id, AbiLevel = 3 },
                    new AssAbi { AssignmentId = assignments[6].Id, AbilityId = abilities[0].Id, AbiLevel = 3 },
                    new AssAbi { AssignmentId = assignments[6].Id, AbilityId = abilities[10].Id, AbiLevel = 3 },

                    // --- 7. Logistics Coordinator ---
                    new AssAbi { AssignmentId = assignments[7].Id, AbilityId = abilities[9].Id, AbiLevel = 3 },
                    new AssAbi { AssignmentId = assignments[7].Id, AbilityId = abilities[3].Id, AbiLevel = 2 },

                    // --- 8. Meitav Service Representative ---
                    new AssAbi { AssignmentId = assignments[8].Id, AbilityId = abilities[10].Id, AbiLevel = 4 },
                    new AssAbi { AssignmentId = assignments[8].Id, AbilityId = abilities[9].Id, AbiLevel = 3 },

                    // --- 9. Office Administrator (פקל"ש) ---
                    new AssAbi { AssignmentId = assignments[9].Id, AbilityId = abilities[9].Id, AbiLevel = 3 },
                    new AssAbi { AssignmentId = assignments[9].Id, AbilityId = abilities[10].Id, AbiLevel = 3 }
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