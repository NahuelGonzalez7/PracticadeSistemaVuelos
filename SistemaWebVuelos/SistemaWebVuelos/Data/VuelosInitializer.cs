using SistemaWebVuelos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaWebVuelos.Data
{
    public class VuelosInitializer : DropCreateDatabaseAlways<DbVueloContext>
    {
        protected override void Seed(DbVueloContext context)
        {
            var vuelos = new List<Vuelo>
            {
                new Vuelo
                {
                    Fecha = Convert.ToDateTime("22/12/1990"),
                    Destino = " Cancun ",
                    Origen = "Buenos Aires",
                    Matricula = 777
                }
            };

            vuelos.ForEach(s => context.Vuelos.Add(s));
            context.SaveChanges();
        }
    }
}