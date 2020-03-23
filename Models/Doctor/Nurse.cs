using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public partial class Nurse
    {
        public Nurse()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}