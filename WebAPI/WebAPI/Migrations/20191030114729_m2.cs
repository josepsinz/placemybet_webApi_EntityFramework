using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "EventoId", "Fecha", "GolesLocal", "GolesVisitante", "Local", "Visitante" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 10, 30, 12, 47, 28, 274, DateTimeKind.Local).AddTicks(584), 0, 0, "Alicante", "Sueca" },
                    { 2, new DateTime(2019, 10, 30, 12, 47, 28, 277, DateTimeKind.Local).AddTicks(577), 0, 0, "Cáceres", "Albaida" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Administrador", "Apellidos", "Edad", "Email", "Fondos", "Nombre", "Password" },
                values: new object[,]
                {
                    { 1, false, "Sanchez", 29, "pepe@gmail.com", 0.0, "Pepe", "Abc123%" },
                    { 2, true, "Garcia", 33, "anagarcia@gmail.com", 0.0, "Ana", "aBc123%" }
                });

            migrationBuilder.InsertData(
                table: "Cuentas",
                columns: new[] { "CuentaId", "Banco", "Email", "NumeroTarjeta", "Saldo", "UsuarioId" },
                values: new object[] { 1, "Bankia", "pepe@gmail.com", 1234123412341234L, 2000.0, 1 });

            migrationBuilder.InsertData(
                table: "Mercados",
                columns: new[] { "MercadoId", "CuotaOver", "CuotaUnder", "DineroOver", "DineroUnder", "EventoId", "TipoMercado" },
                values: new object[] { 2, 1.9f, 1.9f, 100.0, 100.0, 2, 2.5f });

            migrationBuilder.InsertData(
                table: "Mercados",
                columns: new[] { "MercadoId", "CuotaOver", "CuotaUnder", "DineroOver", "DineroUnder", "EventoId", "TipoMercado" },
                values: new object[] { 1, 1.9f, 1.9f, 100.0, 100.0, 2, 1.5f });

            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "ApuestaId", "Apostado", "Cuota", "MercadoId", "TipoMercado", "UsuarioId", "isOver" },
                values: new object[] { 2, 50.0, 1.9f, 1, 1.5f, 1, false });

            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "ApuestaId", "Apostado", "Cuota", "MercadoId", "TipoMercado", "UsuarioId", "isOver" },
                values: new object[] { 1, 25.0, 1.9f, 2, 2.5f, 1, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Apuestas",
                keyColumn: "ApuestaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Apuestas",
                keyColumn: "ApuestaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cuentas",
                keyColumn: "CuentaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Eventos",
                keyColumn: "EventoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mercados",
                keyColumn: "MercadoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mercados",
                keyColumn: "MercadoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Eventos",
                keyColumn: "EventoId",
                keyValue: 2);
        }
    }
}
