using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebAPI.Models
{
    public class Mercado
    {
        public int MercadoId { get; set; }
        public float TipoMercado { get; set; }
        public float CuotaOver { get; set; }
        public float CuotaUnder { get; set; }
        public double DineroOver { get; set; }
        public double DineroUnder { get; set; }

        public List<Apuesta> Apuestas { get; set; }

        public int EventoId { get; set; }
        public Evento Evento { get; set; }

        public Mercado(int mercadoid, float tipoMercado, float cuotaOver, float cuotaUnder, double dineroOver, double dineroUnder, int eventoid)
        {
            MercadoId = mercadoid;
            TipoMercado = tipoMercado;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            DineroOver = dineroOver;
            DineroUnder = dineroUnder;
            EventoId = eventoid;

        }

        public Mercado()
        {

        }
    }

    public class MercadoDTO
    {
        public MercadoDTO(float tipoMercado, float cuotaOver, float cuotaUnder)
        {
            TipoMercado = tipoMercado;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
        }

        public float TipoMercado { get; set; }
        public float CuotaOver { get; set; }
        public float CuotaUnder { get; set; }
    }

}