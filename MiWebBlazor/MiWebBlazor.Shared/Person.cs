using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiWebBlazor.Shared
{
    public class Person
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public DateTime Birthday { get; set; } = new DateTime();
        public string? Website { get; set; }
        public string? Phone { get; set; }
        public Address? MyAddress { get; set; }
        public  string? Email { get; set; }
        public bool isFreelance { get; set; }
        public async Task<int> MyAge()
        {
            DateTime now = DateTime.Today;
            int age = DateTime.Today.Year - Birthday.Year;

            if (DateTime.Today < Birthday.AddYears(age))
                return --age;
            else
                return age;
        }
        public async Task<string> Freelance()
        {
            string result = isFreelance ? "Available" : "unavailable";
            return result;
        }
    }
}
