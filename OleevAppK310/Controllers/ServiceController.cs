using DataAccess;
using Microsoft.AspNetCore.Mvc;
using OleevAppK310.Helpers;
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

        public IActionResult Index(int? pageNo,int? recordSize)
        {
            pageNo ??= 1;
            recordSize ??= 3;
            int skipCount = (pageNo.Value-1) * recordSize.Value;

            ServiceVM vm = new()
            {
                Services= _context.Services.Skip(skipCount).Take(recordSize.Value).ToList(),
            };
            int count=_context.Services.Count();
            vm.PageNo = pageNo.Value;
            vm.Pager = new Pager(count, pageNo, recordSize.Value);

            return View(vm);
        }
    }
}
