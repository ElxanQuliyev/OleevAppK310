using Entities;
using OleevAppK310.Helpers;
using OleevAppK310.Models;

namespace OleevAppK310.ViewModels
{
    public class ServiceVM
    {
        public List<Service> Services { get; set; }
        public Pager Pager { get; set; }
        public int PageNo { get; set; }
        public int? PageSize { get; set; }
    }
}
