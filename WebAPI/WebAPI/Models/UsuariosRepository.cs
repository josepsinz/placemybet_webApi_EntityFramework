using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class UsuariosRepository
    {

        internal List<Usuario> Retrieve()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                usuarios = context.Usuarios.ToList();
            }

            return usuarios;
        }

        internal Usuario Retrieve(int id)
        {
            Usuario usuario;

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                usuario = context.Usuarios.Where(s => s.UsuarioId == id).FirstOrDefault();
            }

            return usuario;
        }

        internal void Save(Usuario u)
        {
            try
            {
                PlaceMyBetContext context = new PlaceMyBetContext();
                context.Usuarios.Add(u);
                context.SaveChanges();
            }
            catch
            {
                Debug.WriteLine("ERROR");
            }
        }
    }
}