using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Service
    {
        public int Id { get; set; }
        [MaxLength(600)]
        public string? Icon { get; set; }
        [MaxLength(200)]
        public string Header { get; set; }=null!;
        [MaxLength(800)]
        public string? Description { get; set; }
    }

}
