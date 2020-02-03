using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public partial class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Gender { get; set; }
        public string HealthCondition { get; set; }
        public int DoctorId { get; set; }
        public int NurseId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Nurse Nurse { get; set; }
    }
}