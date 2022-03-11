using DataAccess;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OleevAppK310.Models;

namespace OleevAppK310.Areas.AdminOlev.Controllers
{
    [Area(nameof(AdminOlev))]
    public class ServiceController : Controller
    {
        private readonly OlDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ServiceController(OlDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        // GET: ServiceController
        public ActionResult Index()
        {
            return View(_context.Services.ToList());
        }

        // GET: ServiceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Service service, IFormFile Icon)
        {
            if (ModelState.IsValid)
            {
                if (Icon != null)
                {
                    string filename = Guid.NewGuid() + Icon.FileName;
                    string rootPath = Path.Combine(_env.WebRootPath, "images");
                    string photoPath = Path.Combine(rootPath, filename);
                    using FileStream fl = new(photoPath, FileMode.Create);
                    Icon.CopyTo(fl);
                    service.Icon = "/images/" + filename;
                }
                _context.Services.Add(service);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }

        // GET: ServiceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
