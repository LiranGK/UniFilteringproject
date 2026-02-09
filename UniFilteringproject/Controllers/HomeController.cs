using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniFilteringproject.Data;
using UniFilteringproject.Models;

namespace UniFilteringproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // 1. Total Malshabs
            ViewBag.TotalMalshabs = await _context.Malshabs.CountAsync();

            // 2. Total Assignments
            ViewBag.TotalAssignments = await _context.Assignments.CountAsync();

            // 3. Unassigned Malshabs
            // A Malshab is unassigned if their MalAssignedList is empty
            ViewBag.UnassignedCount = await _context.Malshabs
                .Include(m => m.MalAssignedList)
                .CountAsync(m => !m.MalAssignedList.Any());

            // 4. Assignments Below Minimum Staffing
            // Count assignments where current assigned count < MinMalshabs
            var assignments = await _context.Assignments
                .Include(a => a.MalAssignedList)
                .ToListAsync();

            ViewBag.BelowMinCount = assignments
                .Count(a => a.MalAssignedList.Count < a.MinMalshabs);

            return View();
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}