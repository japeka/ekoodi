using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ski_jumping_points_calculator
{
    class FakeName
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Region { get; set; }
        public FakeName(string name, string surname, string gender, string region)
        {
            Name = name;
            Surname = surname;
            Gender = gender;
            Region = region;
        }

    }
}
