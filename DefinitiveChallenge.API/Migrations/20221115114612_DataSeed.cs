using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefinitiveChallenge.API.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "BuyDate", "Description", "State", "Type", "Value" },
                values: new object[] { 1, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Automovil Twingo", "Activo", "Vehículos", 20000000.0 });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "BuyDate", "Description", "State", "Type", "Value" },
                values: new object[] { 2, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finca con piscina, salón de juegos, patio, cuarto de cocina, cuarto de ropas y 8 habitaciones", "Inactivo", "Bienes", 400000000.0 });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "BuyDate", "Description", "State", "Type", "Value" },
                values: new object[] { 3, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Telefono móvil iphone 14", "Activo", "Bienes", 5487599.9900000002 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
