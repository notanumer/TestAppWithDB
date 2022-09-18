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
        [Required(ErrorMessage = "Please enter your name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please choose your gender")]
        public char Gender { get; set; }
        [Required(ErrorMessage = "Please choose your birth date")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Please enter your name of team")]
        public string TeamName { get; set; }
        [Required(ErrorMessage = "Please choose your country")]
        public string Country { get; set; }
    }
}
