using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class EventosRepositoy
    {

        internal List<Evento> Retrieve()
        {
            List<Evento> eventos = new List<Evento>();

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                eventos = context.Eventos.ToList();
            }

            return eventos;
        }

        internal void Save(Evento e)
        {
            try
            {
                PlaceMyBetContext context = new PlaceMyBetContext();

                context.Eventos.Add(e);
                context.SaveChanges();
            }
            catch
            {
                Debug.WriteLine("ERROR");
            }
        }
    }
}