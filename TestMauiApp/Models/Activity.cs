using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMauiApp.Models
{
    public partial class Activity
    {

        public int Id { get; set; }
        public DateTime DateOfActivity { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        public string Description { get; set; }
        public int Rate { get; set; }
        public Types Type { get; set; }
        public int TypesId { get; set; }
        public int ProspectId { get; set; }
    }
}
