using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace OleevAppK310.Models
{
    public class Section1
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Display(Name ="Alt Basliq")]
        public string? SubHeader { get; set; }
        [MaxLength(100)]
        [Display(Name = "Basliq")]

        [Required(ErrorMessage ="{0} boş göndərilə bilməz")]
        public string Header { get; set; } = null!;
        [MaxLength(500)]
        public string? Description { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
