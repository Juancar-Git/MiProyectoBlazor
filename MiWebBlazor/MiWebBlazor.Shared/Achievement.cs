using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiWebBlazor.Shared
{
    public class Achievement: ICloneable
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public Job? Job { get; set; }
        public int JobId { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
