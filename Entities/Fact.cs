using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Fact
    {
        public int Id { get; set; }
        [MaxLength(600)]
        public string Icon { get; set; } = null!;
        [MaxLength(200)]
        public string Header { get; set; } = null!;
        public int NumberFun { get; set; }
    }
}
