using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiWebBlazor.Shared
{
    public class Person:ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Birthday { get; set; } = new DateTime();
        public string Website { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public  string Email { get; set; } = string.Empty;  
        public bool IsFreelancer { get; set; }//Revisar si donde va este campo
        public Location? Location { get; set; }
        public int LocationId { get; set; }
        public Resume? Resume { get; set; }
        public int ResumeId { get; set; }
        public int MyAge()
        {
            DateTime now = DateTime.Today;
            int age = DateTime.Today.Year - Birthday.Year;

            if (DateTime.Today < Birthday.AddYears(age))
                return --age;
            else
                return age;
        }
        public string Freelance()
        {
            return IsFreelancer ? "Available" : "unavailable";
        }
        public string BirthdayFormated()
        {
            return Birthday.ToString("d MMM yyyy", CultureInfo.CreateSpecificCulture("en-US"));
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
