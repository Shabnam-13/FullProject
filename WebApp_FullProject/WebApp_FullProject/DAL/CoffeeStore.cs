using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApp_FullProject.Models;

namespace WebApp_FullProject.DAL
{
    public class CoffeeStore:DbContext
    {
        public CoffeeStore(): base("CoffeeStoreCon")
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Sections> Sections { get; set; }
        public DbSet<PageSettings> pageSettings { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}