using System.ComponentModel.DataAnnotations;

namespace AppCrudDOTNET.Models
{
    public class Animal
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;

        [Required]
        public Byte[] Data { get; set; }
        [Required]
        public string ContentType { get; set; }

    }
}
