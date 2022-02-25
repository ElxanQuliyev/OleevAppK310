using System.ComponentModel.DataAnnotations;

namespace OleevAppK310.Models
{
    public class ReservCategory
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; } = null!;

    }

}
