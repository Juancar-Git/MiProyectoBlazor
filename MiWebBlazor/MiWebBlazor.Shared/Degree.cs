using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiWebBlazor.Shared
{
    internal class Degree
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; } = new DateTime();
        public DateTime EndDate { get; set; } = new DateTime();
        public string? EducationalCenter { get; set; }
        public Address? MyAddress { get; set; }

    }
}

