using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APIPrueba.Models
{
    public class DataContext:DbContext
    {
        public DataContext() : base("DefaultConnection")
        { 

        }

        public System.Data.Entity.DbSet<APIPrueba.Models.Prueba> Pruebas { get; set; }
    }
}