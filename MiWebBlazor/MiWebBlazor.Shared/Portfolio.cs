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
        public string SrcMainImage { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public DateTime ProjectDate { get; set; } = new DateTime();
        public string ProjectUrl { get; set; } = string.Empty;
        public string SumaryTitle { get; set; } = string.Empty;
        public string Sumary { get; set; } = string.Empty;
        public string UrlImageList { get; set; } = string.Empty;
        public Resume? Resume { get; set; }
        public int ResumeId { get; set; }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
