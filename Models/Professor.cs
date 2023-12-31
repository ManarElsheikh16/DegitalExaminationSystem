﻿using DigitalExaminationSys.Repository.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalExaminationSys.Models
{
    public class Professor : IBaseModel<string>
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public List<Course> ?Courses { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
