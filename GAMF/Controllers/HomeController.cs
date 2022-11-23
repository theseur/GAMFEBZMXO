using GAMF.Data;
using GAMF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GAMF.Controllers
{
    public class HomeController : Controller
    {
        private readonly GAMFDbContext _context;

        public HomeController(GAMFDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students.ToList();

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}