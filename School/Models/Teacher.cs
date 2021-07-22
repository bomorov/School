using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    [Table("Teachers")]
    public class Teacher : Person
    {
        [Display(Name = "Класс")]
        public ClassRoom ClassRoom { get; set; }
    }
}