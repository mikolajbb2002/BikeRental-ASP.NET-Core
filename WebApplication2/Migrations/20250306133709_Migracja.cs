using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class Migracja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    IdKlienta = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Imie = table.Column<string>(type: "TEXT", nullable: false),
                    Nazwisko = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Telefon = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.IdKlienta);
                });

            migrationBuilder.CreateTable(
                name: "Rowery",
                columns: table => new
                {
                    IdRoweru = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Producent = table.Column<string>(type: "TEXT", nullable: false),
                    Nazwa = table.Column<string>(type: "TEXT", nullable: false),
                    Napęd = table.Column<string>(type: "TEXT", nullable: false),
                    Hamulce = table.Column<string>(type: "TEXT", nullable: false),
                    Amortyzacja = table.Column<string>(type: "TEXT", nullable: false),
                    RozmiarRamy = table.Column<string>(type: "TEXT", nullable: false),
                    TypRoweru = table.Column<string>(type: "TEXT", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rowery", x => x.IdRoweru);
                });

            migrationBuilder.CreateTable(
                name: "Wypozyczenia",
                columns: table => new
                {
                    IdWypozyczenia = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdKlienta = table.Column<int>(type: "INTEGER", nullable: false),
                    IdRoweru = table.Column<int>(type: "INTEGER", nullable: false),
                    DataWypozyczenia = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataZwrotu = table.Column<DateTime>(type: "TEXT", nullable: true),
                    KosztWypozyczenia = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wypozyczenia", x => x.IdWypozyczenia);
                    table.ForeignKey(
                        name: "FK_Wypozyczenia_Klienci_IdKlienta",
                        column: x => x.IdKlienta,
                        principalTable: "Klienci",
                        principalColumn: "IdKlienta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wypozyczenia_Rowery_IdRoweru",
                        column: x => x.IdRoweru,
                        principalTable: "Rowery",
                        principalColumn: "IdRoweru",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wypozyczenia_IdKlienta",
                table: "Wypozyczenia",
                column: "IdKlienta");

            migrationBuilder.CreateIndex(
                name: "IX_Wypozyczenia_IdRoweru",
                table: "Wypozyczenia",
                column: "IdRoweru");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wypozyczenia");

            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropTable(
                name: "Rowery");
        }
    }
}
