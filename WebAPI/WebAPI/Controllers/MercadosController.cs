using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class MercadosController : ApiController
    {

        // GET: api/Mercados
        public IEnumerable<Mercado> Get()
        {
            var repo = new MercadosRepository();
            List<Mercado> mercados = repo.Retrieve();
            return mercados;
        }

        // GET: api/Mercados/5
        public Mercado Get(int id)
        {
            var repo = new MercadosRepository();
            Mercado m = repo.Retrieve(id);
            return m;
        }
        
        // GET: api/Mercados?id_partido={id_partido}
        public List<Mercado> GetbyEvento(int id_partido)
        {
            var repo = new MercadosRepository();
            List<Mercado> mercados = repo.RetrieveByEvento(id_partido);
            return mercados;
        }
        /*
        // GET: api/Mercados?id_apuesta={id_apuesta}
        public List<Mercado> GetbyEvento(int id_partido)
        {
            var repo = new MercadosRepository();
            List<Mercado> mercados = repo.RetrieveByEvento(id_partido);
            return mercados;
        }
        */
        // POST: api/Mercados
        public void Post([FromBody]Mercado m)
        {
            if(m.TipoMercado == 1.5 || m.TipoMercado == 2.5 || m.TipoMercado == 3.5)
            {
                var repo1 = new MercadosRepository();
                List<Mercado> mercados = repo1.RetrieveByEvento(m.EventoId);
                List<float> tiposMercados = new List<float>();
                foreach (Mercado mercado in mercados)
                {
                    tiposMercados.Add(mercado.TipoMercado);
                }
                if (!tiposMercados.Contains(m.TipoMercado))
                {
                    var repo2 = new MercadosRepository();
                    repo2.Save(m);
                }
            }   
        }
        /*
        // PUT: api/Mercados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercados/5
        public void Delete(int id)
        {
        }
        */
    }
}
