using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp_FullProject.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [MaxLength(25)]
        [Required]
        public string Name { get; set; }

        [MaxLength(25)]
        [Required]
        public string Surname { get; set; }

        [MaxLength(250)]
        [Required]
        public string Email { get; set; }

        [MaxLength(250)]
        [MinLength(8)]
        [Required]
        public string Password { get; set; }

        public DateTime CreateDate { get; set; }
    }
}