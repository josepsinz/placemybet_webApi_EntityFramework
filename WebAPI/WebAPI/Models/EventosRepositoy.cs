using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

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

        internal Evento Retrieve(int id)
        {
            Evento evento;

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                evento = context.Eventos.Where(s => s.EventoId == id).FirstOrDefault();
            }
            return evento;
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

        internal void Refresh(int id, Evento e)
        {
            Evento eve;

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                eve = context.Eventos.Where(s => s.EventoId == id).FirstOrDefault();

                eve.Local = e.Local;
                eve.Visitante = e.Visitante;

                context.SaveChanges();
            }
        }

        internal void Delete(int id)
        {
            Evento eve;

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                eve = context.Eventos.Where(s => s.EventoId == id).FirstOrDefault();

                context.Remove(eve);
                context.SaveChanges();
            }
        }
    }
}
