using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiWebBlazor.Shared
{
    public class Testimonial: ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;
        public string SrcProfileImage { get; set; } = string.Empty;
        public string TextMessage { get; set; } = string.Empty;
        public Resume? Resume { get; set; }
        public int ResumeId { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
