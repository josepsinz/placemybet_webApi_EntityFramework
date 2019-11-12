using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class UsuariosController : ApiController
    {

        // GET: api/Usuarios
        public IEnumerable<Usuario> Get()
        {
            var repo = new UsuariosRepository();
            List<Usuario> usuarios = repo.Retrieve();
            return usuarios;
        }

        // GET: api/Usuarios/5
        public Usuario Get(int id)
        {
            var repo = new UsuariosRepository();
            Usuario usuario = repo.Retrieve(id);
            return usuario;
        }

        // POST: api/Usuarios
        public void Post([FromBody]Usuario u)
        {
            var repo = new UsuariosRepository();
            repo.Save(u);
        }

        // PUT: api/Usuarios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuarios/5
        public void Delete(int id)
        {
        }

    }
}
