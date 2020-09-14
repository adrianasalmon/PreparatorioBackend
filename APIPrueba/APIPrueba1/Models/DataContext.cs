using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APIPrueba1.Models
{
    public class DataContext:DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }
        public System.Data.Entity.DbSet<APIPrueba1.Models.Prueba> Pruebas { get; set; }
    }
}