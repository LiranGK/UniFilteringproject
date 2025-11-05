using Microsoft.AspNetCore.Mvc;
using UniFilteringproject.Data;

namespace UniFilteringproject.Controllers
{
    public class MalshabController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MalshabController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult IndexPr()
        {
            var products = _context.Malshabs.ToList();
            return View(products);
        }
    }
}
