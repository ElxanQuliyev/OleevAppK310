
using OleevAppK310.Models;

namespace OleevAppK310.ViewModels
{
    public class IndexVM
    {
        public Section1 Section1Info { get; set; }
        public List<Service> Services { get; set; }
        public List<Doctor>? Doctors { get; set; }   
        public List<ReservCategory> ReservCategories { get; set; }
    }
}
