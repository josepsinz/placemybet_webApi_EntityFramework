using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ApuestasController : ApiController
    {
        
        // GET: api/Apuestas
        public IEnumerable<ApuestaDTO> Get()
        {
            var repo = new ApuestasRepository();
            List<ApuestaDTO> apuestas = repo.RetrieveDTO();
            return apuestas;
        }

        /*
        //get todas las apuestas con informacion de mercado
        // GET: api/Apuestas
        public IEnumerable<Apuesta> Get()
        {
            var repo = new ApuestasRepository();
            List<Apuesta> apuestas = repo.Retrieve();
            return apuestas;
        }
        */

        // GET: api/Apuestas/5
        public Apuesta Get(int id)
        {
            var repo = new ApuestasRepository();
            Apuesta apuesta = repo.Retrieve(id);
            return apuesta;
        }

        // GET: api/Apuestas?idusuario={idusuario}
        public List<ApuestaDTO> GetByUsuario(int idu)
        {
            var repo = new ApuestasRepository();
            List<ApuestaDTO> apuestas = repo.RetrieveByUsuario(idu);
            return apuestas;
        }

        /*
        //GET: api/Apuestas?email={email}
        public List<ApuestaDTObyEmail> GetByEmail(string email)
        {
            var repo = new ApuestasRepository();
            List<ApuestaDTObyEmail> apuestas = repo.RetrieveDTO(email);
            return apuestas;
        }

       
        [Authorize(Roles = "Admin")]
        //GET: api/Apuestas?mercado={mercado}
        public List<ApuestaDTO> GetByMercado(int mercado)
        {
            var repo = new ApuestasRepository();
            List<ApuestaDTO> apuestas = repo.RetrieveDTO(mercado);
            return apuestas;
        }
        */

        [Authorize(Roles = "Standard")]
        // POST: api/Apuestas
        public void Post([FromBody]Apuesta apuesta)
        {
            var repo = new ApuestasRepository();
            var repo2 = new MercadosRepository();
            var repo3 = new UsuariosRepository();

            Mercado m = repo2.Retrieve(apuesta.MercadoId);
            List<Usuario> users = repo3.Retrieve();
            List<int> usuariosId = new List<int>();

            foreach (Usuario u in users)
            {
                usuariosId.Add(u.UsuarioId);
            }

            if (usuariosId.Contains(apuesta.UsuarioId))
            {
                try
                {
                    if (apuesta.isOver)
                    {
                        apuesta.Cuota = m.CuotaOver;
                    }
                    else
                    {
                        apuesta.Cuota = m.CuotaUnder;
                    }
                    apuesta.TipoMercado = m.TipoMercado;

                    repo.Save(apuesta);
                    repo2.Refresh(m, apuesta);
                }
                catch
                {
                    Debug.WriteLine("Id_Mercado no existe");
                }
            }
            else
            {
                Debug.WriteLine("Usuario no existe");
            }
        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }

    }
}
