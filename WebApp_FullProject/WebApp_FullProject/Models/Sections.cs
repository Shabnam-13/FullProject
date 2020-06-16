using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp_FullProject.Models
{
    public class Sections
    {
        public int Id { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [MaxLength(250)]
        [Required]
        public string Title { get; set; }

        [MaxLength(250)]
        public string Subtitle { get; set; }

        [MaxLength(1000)]
        public string Content { get; set; }

        [MaxLength(50)]
        [Required]
        public string Page { get; set; }

        public DateTime CreateDate { get; set; }
    }
}