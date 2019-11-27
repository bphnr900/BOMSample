using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOMSample
{
    class Part
    {
        public Part()
        {
            Parts = new List<Part>();
        }

        public string Name { get; set; }
        public int Level { get; set; }
        public List<Part> Parts { get; set; }
    }
}
