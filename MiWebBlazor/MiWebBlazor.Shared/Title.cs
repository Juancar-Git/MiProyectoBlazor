using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiWebBlazor.Shared
{
    public class Title: ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string EducationalCenter { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = new DateTime();
        public DateTime EndDate { get; set; } = new DateTime();
        public Location? Location { get; set; }
        public int LocationId { get; set; }
        public Resume? Resume { get; set; }
        public int ResumeId { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
