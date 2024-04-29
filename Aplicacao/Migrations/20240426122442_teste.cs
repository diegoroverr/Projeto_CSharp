using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aplicacao.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quartos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    EstaDisponivel = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quartos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quarto = table.Column<int>(type: "INTEGER", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NumeroDaReserva = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospedes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    JaPagou = table.Column<bool>(type: "INTEGER", nullable: true),
                    NumeroDaReservaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospedes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospedes_Reservas_NumeroDaReservaId",
                        column: x => x.NumeroDaReservaId,
                        principalTable: "Reservas",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Quartos",
                columns: new[] { "Id", "EstaDisponivel", "Numero" },
                values: new object[] { 1, true, 105 });

            migrationBuilder.InsertData(
                table: "Quartos",
                columns: new[] { "Id", "EstaDisponivel", "Numero" },
                values: new object[] { 2, false, 205 });

            migrationBuilder.InsertData(
                table: "Quartos",
                columns: new[] { "Id", "EstaDisponivel", "Numero" },
                values: new object[] { 3, true, 305 });

            migrationBuilder.CreateIndex(
                name: "IX_Hospedes_NumeroDaReservaId",
                table: "Hospedes",
                column: "NumeroDaReservaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hospedes");

            migrationBuilder.DropTable(
                name: "Quartos");

            migrationBuilder.DropTable(
                name: "Reservas");
        }
    }
}
