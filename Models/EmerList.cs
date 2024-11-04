using System.ComponentModel.DataAnnotations;

namespace AppCrudDOTNET.Models
{
    public class EmerList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateTime { get; set; } 
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [StringLength(500)]
        public string Edit { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string Recroder { get; set; } = string.Empty;
    }
}
