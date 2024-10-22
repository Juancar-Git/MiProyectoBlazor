using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiWebBlazor.Shared
{
    public class Service : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string DPath { get; set; } = string.Empty;
        public string IBiClass { get; set; } = string.Empty;
        public Resume? Resume { get; set; }
        public int ResumeId { get; set; }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
