using System.Collections.Generic;
//using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class MercadosRepository
    {

        public List<MercadoDTO> Retrieve()
        {
            List<MercadoDTO> mercados = new List<MercadoDTO>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercados = context.Mercados.Select(p => ToDTO(p)).ToList();
            }

            return mercados;
        }

        public MercadoDTO ToDTO(Mercado m)
        {
            return new MercadoDTO(m.TipoMercado, m.CuotaOver, m.CuotaUnder);
        }

        internal Mercado Retrieve(int id)
        {
            Mercado mercado;

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercado = context.Mercados.Where(s => s.MercadoId == id).Include(p => p.Evento).FirstOrDefault();
            }

            return mercado;
        }

        internal List<Mercado> RetrieveByEvento(int id)
        {
            List<Mercado> mercados;

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercados = context.Mercados.Where(s => s.EventoId == id).ToList();
            }

            return mercados;
        }

        internal void Save(Mercado m)
        {
            try
            {
                PlaceMyBetContext context = new PlaceMyBetContext();
                m.CuotaOver = 1.9F;
                m.CuotaUnder = 1.9F;
                m.DineroOver = 100;
                m.DineroUnder = 100;
                context.Mercados.Add(m);
                context.SaveChanges();
            }
            catch
            {
                Debug.WriteLine("ERROR");
            }
        }

        internal void Refresh(Mercado m, Apuesta a)
        {
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                m = context.Mercados.Where(s => s.MercadoId == a.MercadoId).FirstOrDefault();
                if (a.isOver)
                {
                    m.DineroOver += a.Apostado;
                }
                else
                {
                    m.DineroUnder += a.Apostado;
                }

                double probOV = m.DineroOver / (m.DineroOver + m.DineroUnder);
                double cuotaOV = 1 / probOV * 0.95;
                double probUN = m.DineroUnder / (m.DineroOver + m.DineroUnder);
                double cuotaUN = 1 / probUN * 0.95;


                m.CuotaOver = (float)cuotaOV;
                m.CuotaUnder = (float)cuotaUN;

                context.SaveChanges();
            }
        }
    }
}