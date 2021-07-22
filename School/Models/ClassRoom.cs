using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class ClassRoom
    {
        public int Id { get; set; }

        [Display(Name = "Класс")]
        public string Name { get; set; }

        [Display(Name = "Студенты")]
        public IList<Student> Students { get; set; }

        [Display(Name = "Классный руководитель")]
        public int? TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public ClassRoom()
        {
            Students = new List<Student>();
        }
    }
}