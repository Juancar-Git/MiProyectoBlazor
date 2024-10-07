using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiWebBlazor.Shared
{
    public class Resume
    {
        public int Id { get; set; }
        public string? Sumary { get; set; }
        public Person Myperson { get; set; } = new Person();
        public List<Skill> Skills { get; set; } = new List<Skill>();

    }
}
