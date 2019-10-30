using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Apuesta
    {
        public int ApuestaId { get; set; }
        public float TipoMercado { get; set; }
        public bool isOver { get; set; }
        public float Cuota { get; set; }
        public double Apostado { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int MercadoId { get; set; }
        public Mercado Mercado { get; set; }

        public Apuesta(int apuestaid, float mercado, bool isover, float cuota, double apostado, int usuarioid, int mercadoid)
        {
            ApuestaId = apuestaid;
            TipoMercado = mercado;
            isOver = isover;
            Cuota = cuota;
            Apostado = apostado;
            UsuarioId = usuarioid;
            MercadoId = mercadoid;
        }

        public Apuesta()
        {

        }

    }
    /*
    public class ApuestaDTO
    {
        public ApuestaDTO(float mercado, bool tipo, float cuota, double apostado, string email)
        {
            Mercado = mercado;
            Cuota = cuota;
            Tipo = tipo;
            Apostado = apostado;
            Email = email;
        }

        public float Mercado { get; set; }
        public bool Tipo { get; set; }
        public float Cuota { get; set; }
        public double Apostado { get; set; }
        public string Email { get; set; }
    }

    public class ApuestaDTObyEmail
    {
        public ApuestaDTObyEmail(int id_Evento, DateTime fecha, string local, string visitante, float mercado, bool tipo, float cuota, double apostado)
        {
            Id_Evento = id_Evento;
            Fecha = fecha;
            Local = local;
            Visitante = visitante;
            Mercado = mercado;
            Tipo = tipo;
            Cuota = cuota;
            Apostado = apostado;
        }

        public int Id_Evento { get; set; }
        public DateTime Fecha { get; set; }
        public string Local { get; set; }
        public string Visitante { get; set; }
        public float Mercado { get; set; }
        public bool Tipo { get; set; }
        public float Cuota { get; set; }
        public double Apostado { get; set; }
    }
    */
}