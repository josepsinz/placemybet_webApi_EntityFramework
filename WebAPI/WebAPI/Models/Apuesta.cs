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

    public class ApuestaDTO
    {
        public int UsuarioId { get; set; }
        public int EventoId { get; set; }
        public float TipoMercado { get; set; }
        public bool isOver { get; set; }
        public float Cuota { get; set; }
        public double Apostado { get; set; }

        public ApuestaDTO(int usuarioId, int eventoid, float tipoMercado, bool isover, float cuota, double apostado)
        {
            UsuarioId = usuarioId;
            EventoId = eventoid;
            TipoMercado = tipoMercado;
            isOver = isover;
            Cuota = cuota;
            Apostado = apostado;
        }
    }

}