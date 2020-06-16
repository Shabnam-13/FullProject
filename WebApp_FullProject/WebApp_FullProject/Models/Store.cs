using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp_FullProject.Models
{
    public class Store
    {
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Adress { get; set; }

        [MaxLength(20)]
        [Required]
        public string Phone { get; set; }

        [MaxLength(250)]
        public string Title { get; set; }

        [MaxLength(250)]
        public string Subtitle { get; set; }

        [MaxLength(25)]
        public string Sunday { get; set; }

        [MaxLength(25)]
        public string Munday { get; set; }

        [MaxLength(25)]
        public string Tuesday { get; set; }

        [MaxLength(25)]
        public string Wednesday { get; set; }

        [MaxLength(25)]
        public string Thursday { get; set; }

        [MaxLength(25)]
        public string Friday { get; set; }

        [MaxLength(25)]
        public string Saturday { get; set; }

        [MaxLength(50)]
        [Required]
        public string Page { get; set; }
    }
}