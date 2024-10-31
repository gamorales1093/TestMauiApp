using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendTestApp.Models.Entities
{
    [Table("Prospect")]
    public class Prospect
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(250)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(10)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100)]
        public string Email { get; set; }

        public List<Activity> Activities { get; set; }
    }
}
