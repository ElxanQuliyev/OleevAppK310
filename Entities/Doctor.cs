using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Fullname { get; set; } = null!;
        
        [MaxLength(200)]
        public string EmailAddress { get; set; } = null!;
        
        public string WorkArea { get; set; } = null!;
        
        [MaxLength(600)]
        public string? PhotoUrl { get; set; }
    }
}
