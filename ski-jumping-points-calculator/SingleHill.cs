using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*{"name": "Malinka", "kpoint":"134"},
*/
namespace ski_jumping_points_calculator
{
    class SingleHill
    {
        public string Name { get; set; }
        public string Kpoint { get; set; }
        public SingleHill(string name, string kpoint) {
            Name = name;
            Kpoint = kpoint;
        }
    }
}
