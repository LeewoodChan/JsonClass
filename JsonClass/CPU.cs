using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonClass
{
    class CPU : Part
    {
        public override string Name { get; set; }
        public override string Speed { get; set; }
        //public override string Name { get; set; }
        //public override string Speed { get; set; }
        //public override string BoardID { get; set; }

        public CPU(string name, string speed)
        {
            this.Name = name;
            this.Speed = speed;
        }
    }
}
