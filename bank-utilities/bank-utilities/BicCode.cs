using System;
using System.Collections.Generic;
using System.Text;

namespace bank_utilities
{
    class BicCode {
        public string Id { get; set; }
        public string Name { get; set; }
        public BicCode(string id, string name) {
            Id = id;
            Name = name;
        }
    }
}
