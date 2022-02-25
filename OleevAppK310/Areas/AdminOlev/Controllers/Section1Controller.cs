using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OleevAppK310.Models;

namespace OleevAppK310.Areas.AdminOlev.Controllers
{
    [Area(nameof(AdminOlev))]
    public class Section1Controller : Controller
    {
        private readonly OlDbContext _context;
        private readonly IWebHostEnvironment _env;
        public Section1Controller(OlDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Section1Controller
        public ActionResult Index()
        {
            return View(_context.Section1s.ToList());
        }

        // GET: Section1Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Section1Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Section1Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Section1 sect1,IFormFile PhotoUrl)
        {
            if (ModelState.IsValid)
            {
                if (PhotoUrl != null)
                {
                    string filename=Guid.NewGuid()+ PhotoUrl.FileName;
                    string rootPath = Path.Combine(_env.WebRootPath, "images");
                    string photoPath = Path.Combine(rootPath, filename);
                    using FileStream fl = new(photoPath, FileMode.Create);
                    PhotoUrl.CopyTo(fl);
                    sect1.PhotoUrl = "/images/" + filename;
                }
                _context.Section1s.Add(sect1);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }    
                return View();
        }

        // GET: Section1Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Section1Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Section1 sect1,IFormFile NewPhoto)
        {
            if (ModelState.IsValid)
            {
                if (NewPhoto != null)
                {
                    string filename = Guid.NewGuid() + NewPhoto.FileName;
                    string rootPath = Path.Combine(_env.WebRootPath, "images");
                    string photoPath = Path.Combine(rootPath, filename);
                    using FileStream fl = new(photoPath, FileMode.Create);
                    NewPhoto.CopyTo(fl);
                    sect1.PhotoUrl = "/images/" + filename;
                }
                _context.Section1s.Update(sect1);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Section1Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Section1Controller/Delete/5
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
