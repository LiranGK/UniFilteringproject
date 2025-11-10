using Microsoft.AspNetCore.Mvc;
using UniFilteringproject.Data;
using UniFilteringproject.Models;

namespace UniFilteringproject.Controllers
{
    public class MalshabController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MalshabController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult IndexMs()
        {
            var malshabs = _context.TheMalshabs.ToList();
            return View(malshabs);
        }
        public IActionResult CreateMs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMs(Malshab malshab)
        {
            if (ModelState.IsValid)
            {
                // If the user entered an image name, prepend /images/
                if (!string.IsNullOrWhiteSpace(malshab.ImageUrl) && !malshab.ImageUrl.StartsWith("/images/"))
                {
                    malshab.ImageUrl = "/images/" + malshab.ImageUrl.TrimStart('/');
                }
                _context.TheMalshabs.Add(malshab);
                _context.SaveChanges();
                return RedirectToAction(nameof(IndexMs));
            }
            return View(malshab);
        }
    }
}