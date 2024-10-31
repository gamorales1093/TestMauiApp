using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendTestApp.Models.Entities
{
    [Table("Types")]
    public class Types
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(250)]
        public string Description { get; set; }
    }
}
