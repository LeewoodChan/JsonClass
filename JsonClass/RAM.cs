using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonClass
{
    class RAM : Part
    {
        
        public override string Size { get; set; }
        public override string Type { get; set; }
        public override string Quantity { get; set; }
        public override string Speed { get; set; }

        //public override string Size { get; set; }
        //public override string Type { get; set; }
        //public override string Quantity { get; set; }
        //public override string Speed { get; set; }

        public RAM(string size, string type, string quantity, string speed)
        {
            this.Size = size;
            this.Type = type;
            this.Quantity = quantity;
            this.Speed = speed;
        }


    }
}
