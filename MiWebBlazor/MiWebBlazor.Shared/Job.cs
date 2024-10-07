using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiWebBlazor.Shared
{
    public class Job
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Company { get; set; }
        public Address? MyAddress { get; set; }
        public List<Avhievement> MyProperty { get; set; }
    }
}
