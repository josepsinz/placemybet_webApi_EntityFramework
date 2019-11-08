using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class MercadosRepository
    {

        internal List<Mercado> Retrieve()
        {
            List<Mercado> mercados = new List<Mercado>();
            
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
               
                mercados = context.Mercados.Include(p => p.Evento).ToList();
                foreach (var mer in mercados)
                {
                    Debug.WriteLine(mer.MercadoId);
                    Debug.WriteLine(mer.Evento.Local);
                }

            }

            return mercados;
        }

        internal Mercado Retrieve(int id)
        {
            Mercado mercado;
            
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                
                mercado = context.Mercados.Where(s => s.MercadoId == id).FirstOrDefault();
               
               

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
            //presuponer que las cuotas serán 1.9 y que el dinero base seran 100€
            //ponerlo
            try
            {
                PlaceMyBetContext context = new PlaceMyBetContext();
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

        /*
        internal List<MercadoDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercado";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                MercadoDTO m = null;
                List<MercadoDTO> mercados = new List<MercadoDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2) + " " + res.GetFloat(3) + " " + res.GetDouble(4) + " " + res.GetDouble(5) + " " + res.GetInt32(6));
                    m = new MercadoDTO(res.GetFloat(1), res.GetFloat(2), res.GetFloat(3));
                    mercados.Add(m);
                }

                con.Close();
                return mercados;
            }
            catch
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }

        }

        internal List<MercadoDTO> RetrieveDTO(int id)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select mercado.Mercado, mercado.Cuota_Over, mercado.Cuota_Under FROM mercado, evento WHERE evento.Id=mercado.Id_Evento AND evento.Id=@idevento";
            command.Parameters.AddWithValue("@idevento", id);
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                List<MercadoDTO> mercados = new List<MercadoDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetFloat(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2));
                    MercadoDTO m = new MercadoDTO(res.GetFloat(0), res.GetFloat(1), res.GetFloat(2));
                    mercados.Add(m);
                }

                con.Close();
                return mercados;
            }
            catch
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }

        }
        */

    }
}