using JsonSubTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonClass
{
    abstract  class Part
    {
        public virtual string Name { get; set; }
        public virtual string Speed { get; set; }

        public virtual string Size { get; set; }
        public virtual string Type { get; set; }
        public virtual string Quantity { get; set; }

        //[JsonIgnore]
        public string _type => GetType().Name;

        public static JsonConverter StandardJsonConverter
        {
            get
            {
                return JsonSubtypesConverterBuilder.Of(typeof(Part), "_type").Build();
            }
        }


    }
}
