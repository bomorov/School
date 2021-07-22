using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public abstract class Person
    {
        public int Id { get; set; }

        [Display(Name = "ФИО")]
        public string FullName { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }
    }
}