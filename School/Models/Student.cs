using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    [Table("Students")]
    public class Student : Person
    {
        [Display(Name = "Год рождения")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Класс")]
        public int ClassRoomId { get; set; }

        public ClassRoom ClassRoom { get; set; }
    }
}