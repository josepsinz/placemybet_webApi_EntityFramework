using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EventosController : ApiController
    {
        // GET: api/Eventos
        public IEnumerable<Evento> Get()
        {
            var repo = new EventosRepositoy();
            List<Evento> eventos = repo.Retrieve();
            return eventos;
        }

        // GET: api/Eventos/5
        public Evento Get(int id)
        {
            var repo = new EventosRepositoy();
            Evento e = repo.Retrieve(id);
            return e;
        }

        // POST: api/Eventos
        public void Post([FromBody]Evento evento)
        {
            var repo = new EventosRepositoy();
            repo.Save(evento);
        }

        // PUT: api/Eventos/5
        public void Put(int id, [FromBody]Evento e)
        {
            var repo = new EventosRepositoy();
            repo.Refresh(id, e);
        }

        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
            var repo = new EventosRepositoy();
            repo.Delete(id);
        }

    }
}
