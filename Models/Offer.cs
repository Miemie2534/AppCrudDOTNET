using System.ComponentModel.DataAnnotations;

namespace AppCrudDOTNET.Models
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        public string Select { get; set; } = string.Empty;
        [Required]
        [StringLength(200)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
