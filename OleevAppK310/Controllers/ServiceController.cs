using Microsoft.AspNetCore.Mvc;
using OleevAppK310.Models;
using OleevAppK310.ViewModels;

namespace OleevAppK310.Controllers
{
    public class ServiceController : Controller
    {
        private readonly OlDbContext _context;

        public ServiceController(OlDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int pageNo=0)
        {

            pageNo = pageNo < 0 ? 0 : pageNo;

            int skipCount = pageNo * 3;
            ServiceVM vm = new ServiceVM
            {
                Services= _context.Services.Skip(skipCount).Take(3).ToList(),
                TotalPage=_context.Services.Count()
            };

            //pageNo = vm.TotalPage.Value / 3 < pageNo ? vm.TotalPage.Value / 3 : pageNo;
            vm.PageNo = pageNo;

            return View(vm);
        }
    }
}
