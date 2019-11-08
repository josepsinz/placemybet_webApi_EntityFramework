using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        /*
        internal void Save(Usuario u)
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert into usuario (Email, Nombre, Apellidos, Edad, Fondos, Administrador, Password) values (@ema, @nom, @ape, @eda, @fon, @adm, @pas)";
            command.Parameters.AddWithValue("@ema", u.Email);
            command.Parameters.AddWithValue("@nom", u.Nombre);
            command.Parameters.AddWithValue("@ape", u.Apellidos);
            command.Parameters.AddWithValue("@eda", u.Edad);
            command.Parameters.AddWithValue("@fon", u.Fondos);
            command.Parameters.AddWithValue("@adm", u.Administrador);
            command.Parameters.AddWithValue("@pas", u.Password);

            Debug.WriteLine("command " + command.CommandText);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
            }
        }
        */
    }
}