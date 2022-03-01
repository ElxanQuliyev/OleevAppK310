using Microsoft.AspNetCore.Mvc;
using OleevAppK310.Models;
using OleevAppK310.ViewModels;
using System.Diagnostics;

namespace OleevAppK310.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OlDbContext _context;
        public HomeController(ILogger<HomeController> logger, OlDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            IndexVM vm = new();
            vm.Section1Info= _context.Section1s.FirstOrDefault();
            vm.Services = _context.Services.ToList();
            return View(vm);
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