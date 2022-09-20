using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Domain.Model
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите ваше имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите вашу фамилию")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Пожалуйста, выберите ваш пол")]
        public char Gender { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите вашу дату рождения")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Пожалуйста введите название команды")]
        public string TeamName { get; set; }
        [Required(ErrorMessage = "Пожалуйста, выберите вашу страну")]
        public string Country { get; set; }
    }
}
