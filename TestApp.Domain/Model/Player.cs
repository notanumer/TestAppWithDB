using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Domain.Model
{
    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public string BirthDate { get; set; }
        public string TeamName { get; set; }
        public string County { get; set; }
    }
}
