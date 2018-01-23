using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Angular_Crud.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext():base("StudentConnection")
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<Country> Countrys { get; set; }
    }
}