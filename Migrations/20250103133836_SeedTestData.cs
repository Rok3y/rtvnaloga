using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace rtvnaloga.Migrations
{
    /// <inheritdoc />
    public partial class SeedTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccountHeaders",
                columns: new[] { "Id", "Currency", "DateTime", "Number", "RecipientAddress", "RecipientLocation", "RecipientName" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 77553344, "Makadamska cesta 2", "1000 Ljubljana", "Janez Novak" },
                    { 2, 0, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1234567, "Asfaltna cesta 3", "1231 Crnuce", "Marija Novak" },
                    { 3, 0, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 987654, "Testna ulica 12", "3000 Celje", "Marko Horvat" }
                });

            migrationBuilder.InsertData(
                table: "InvoiceItems",
                columns: new[] { "Id", "AccountHeaderId", "Amount", "ItemName", "Price" },
                values: new object[,]
                {
                    { 1, 1, 12.75f, "TV - Javna raba - pavšal", 4f },
                    { 2, 1, 3.77f, "RA - Javna raba - pavšal", 20f },
                    { 3, 1, 12.75f, "TV - Zasebna raba - Pravne osebe", 10f },
                    { 4, 1, 3.77f, "RA - Zasebna raba - Pravne osebe", 10f },
                    { 5, 2, 8.12f, "TV - Zasebna raba - Pravne osebe", 10f },
                    { 6, 2, 5.17f, "RA - Zasebna raba - Pravne osebe", 10f },
                    { 7, 2, 24.77f, "RA - Zasebna raba - Pravne osebe", 10f },
                    { 8, 3, 6f, "TV - Javna raba - pavšal", 4f },
                    { 9, 3, 18.5f, "RA - Javna raba - pavšal", 20f },
                    { 10, 3, 1.8f, "TV - Zasebna raba - Pravne osebe", 10f },
                    { 11, 3, 14.4f, "RA - Zasebna raba - Pravne osebe", 10f },
                    { 12, 3, 30f, "RA - Zasebna raba - Pravne osebe", 10f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AccountHeaders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccountHeaders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AccountHeaders",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
