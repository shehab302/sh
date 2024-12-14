﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Member
    {
        public string MemberId { get; set; } = null!;
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(20)]

        public string FName { get; set; } = null!;
        [Required]
        [MaxLength(14)]
        public string SSN { get; set; } = null!;
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(40)]

        public string MName { get; set; } = null!;
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(20)]

        public string LName { get; set; } = null!;
        [ValidateNever]
        public string ImgUrl { get; set; }
        public int IsProfessor { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]

        public EnumGender Gender { get; set; }
        [Required]

        public string Address { get; set; } = null!;
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [Required]

        [DataType(DataType.Text)]

        public string Nationailty { get; set; } = null!;
        [Required]

        public DateTime BirthDate { get; set; }
       
        public int Experence { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<MemberPhone> memberPhones { get; set; }
        public List<Course> Courses { get; set; }

    }
}
