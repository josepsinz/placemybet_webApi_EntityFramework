using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Cuenta
    {
        public int CuentaId { get; set; }
        public string Banco { get; set; }
        public long NumeroTarjeta { get; set; }
        public double Saldo { get; set; }
        public string Email { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Cuenta(int cuentaid, int usuarioid, string banco, long numeroTarjeta, double saldo, string email)
        {
            CuentaId = cuentaid;
            UsuarioId = usuarioid;
            Banco = banco;
            NumeroTarjeta = numeroTarjeta;
            Saldo = saldo;
            Email = email;
        }

        public Cuenta()
        {

        }
    }
}