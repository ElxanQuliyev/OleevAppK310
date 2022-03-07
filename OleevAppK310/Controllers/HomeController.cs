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
            vm.Doctors = _context.Doctors.ToList();
            vm.ReservCategories = _context.ReservCategories.ToList();
            return View(vm);
        }


        public JsonResult FindByService(int? id)
        {
            var selectedProduct = _context.Services.Find(id);
            return Json(selectedProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult MakeAppointment(Reserv reserv)
        {
            var res = new JsonResult(new { });
            try
            {
                _context.Reservs.Add(reserv);
                _context.SaveChanges();

                res.Value = new { message = "Melumatiniz qeydə alındı",status=true };
            }
            catch (Exception e)
            {

                res.Value = new { message = e.Message, status = false};
            }

            return res;
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