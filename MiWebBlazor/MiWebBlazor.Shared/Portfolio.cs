using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiWebBlazor.Shared
{
    public class Portfolio: ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Filter { get; set; } = string.Empty;
        public string SrcImage { get; set; } = string.Empty;
        public Resume? Resume { get; set; }
        public int ResumeId { get; set; }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
