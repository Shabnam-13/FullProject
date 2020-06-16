using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp_FullProject.Models;

namespace WebApp_FullProject.ViewModels
{
    public class Vmodels
    {
        public PageSettings pageSetting { get; set; }

        public Sections section { get; set; }

        public List<Sections> sections { get; set; }

        public Store Store { get; set; }
    }
}