using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp_FullProject.Models
{
    public class PageSettings
    {
        public int Id { get; set; }
        
        [MaxLength(150)]
        [Required]
        public string Logo { get; set; }

        [MaxLength(250)]
        public string Title { get; set; }

        [MaxLength(250)]
        public string Subtitle { get; set; }

        [MaxLength(50)]
        public string Copyright { get; set; }

        [MaxLength(250)]
        public string BgImage { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}