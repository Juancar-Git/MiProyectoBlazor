using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiWebBlazor.Shared
{
    public class Skill: ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? Percentage { get; set; }
        public Resume? Resume { get; set; }
        public int ResumeId { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
