using System.ComponentModel.DataAnnotations;

namespace OleevAppK310.Models
{
    public class Section1Left
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? SubHeader { get; set; }
        [MaxLength(100)]
        public string Header { get; set; } = null!;
        [MaxLength(500)]
        public string? Description { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
