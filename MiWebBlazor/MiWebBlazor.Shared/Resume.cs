using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiWebBlazor.Shared
{
    public class Resume: ICloneable
    {
        public int Id { get; set; }
        public string? Profession { get; set; } = string.Empty;
        public string? Sumary { get; set; } = string.Empty;
        public string? Degree { get; set; } = string.Empty;

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
