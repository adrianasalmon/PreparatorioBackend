using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace admPrueba1.Models
{
    public class DataContext:DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<admPrueba1.Models.Prueba> Pruebas { get; set; }
    }
}