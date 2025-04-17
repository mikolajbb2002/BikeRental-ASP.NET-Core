using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Klienci",
                columns: new[] { "IdKlienta", "Email", "Imie", "Nazwisko", "Telefon" },
                values: new object[] { 2, "adamnowak@gmail.com", "Adam", "Nowak", "123123123" });

            migrationBuilder.InsertData(
                table: "Rowery",
                columns: new[] { "IdRoweru", "Amortyzacja", "Cena", "Hamulce", "Napęd", "Nazwa", "Producent", "RozmiarRamy", "Status", "TypRoweru" },
                values: new object[] { 1, "Przod i tyl ", 100m, "Tarczowe", "2x12", "Trance", "Scott", "L", "Dostepny", "Gorski" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Klienci",
                keyColumn: "IdKlienta",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rowery",
                keyColumn: "IdRoweru",
                keyValue: 1);
        }
    }
}
