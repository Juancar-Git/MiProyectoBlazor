using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiWebBlazor.Shared
{
    public class Fact: ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? Quantity { get; set; }
        public Resume? Resume { get; set; }
        public int ResumeId { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
