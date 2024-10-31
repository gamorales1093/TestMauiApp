using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendTestApp.Models.Entities
{
    [Table("Activity")]
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public DateTime DateOfActivity { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(250)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int Rate { get; set; }

        [ForeignKey("Types")]
        public int TypesId { get; set; }
        public Types Type { get; set; }
        public int ProspectId { get; set; }
    }
}
