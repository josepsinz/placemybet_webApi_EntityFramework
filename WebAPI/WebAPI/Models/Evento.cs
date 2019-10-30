using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Evento
    {
        public int EventoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Local { get; set; }
        public int GolesLocal { get; set; }
        public string Visitante { get; set; }
        public int GolesVisitante { get; set; }

        public List<Mercado> Mercados { get; set; }

        public Evento(int eventoid, DateTime fecha, string local, int golesLocal, string visitante, int golesVisitante)
        {
            EventoId = eventoid;
            Fecha = fecha;
            Local = local;
            GolesLocal = golesLocal;
            Visitante = visitante;
            GolesVisitante = golesVisitante;
        }

        public Evento()
        {

        }
    }


    /*
    public class EventoDTO
    {
        public EventoDTO(string local, string visitante)
        {
            Local = local;
            Visitante = visitante;
        }
        
        public string Local { get; set; }
        public string Visitante { get; set; }
    }
    */
}