using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace rtvnaloga.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccountHeaders",
                columns: new[] { "Id", "Currency", "DateTime", "Number", "RecipientAddress", "RecipientLocation", "RecipientName" },
                values: new object[,]
                {
                    { 4, 0, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 99887766, "Ulica Miru 10", "2000 Maribor", "Ana Kranjc" },
                    { 5, 1, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 11122233, "Bukova pot 4", "4000 Kranj", "Petra Zagar" },
                    { 6, 0, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 44455566, "Glavna cesta 1", "6000 Koper", "Tomaž Vidmar" },
                    { 7, 0, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 12340001, "Obala 77", "6320 Portorož", "Nina Tomšič" },
                    { 8, 1, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 55599911, "Trg Svobode 9", "5000 Nova Gorica", "Goran Kovač" },
                    { 9, 0, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 88776655, "Jablana cesta 6", "8000 Novo Mesto", "Maja Breznik" },
                    { 10, 0, new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 22334455, "Zgornja pot 22", "9000 Murska Sobota", "Luka Zagorc" },
                    { 11, 0, new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 33445566, "Sončna ulica 5", "8001 Novo Mesto", "Sara Kavčič" },
                    { 12, 0, new DateTime(2025, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 69696969, "Cankarjeva cesta 10", "2101 Maribor", "Domen Potrč" },
                    { 13, 0, new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 20247777, "Lipova pot 16", "3210 Slovenske Konjice", "Eva Mlakar" }
                });

            migrationBuilder.InsertData(
                table: "InvoiceItems",
                columns: new[] { "Id", "AccountHeaderId", "Amount", "ItemName", "Price" },
                values: new object[,]
                {
                    { 13, 4, 4.5f, "TV - Zasebna raba - pavšal", 8f },
                    { 14, 4, 12.7f, "RA - Javna raba - pavšal", 20f },
                    { 15, 4, 2f, "Internet - Pravne osebe", 25f },
                    { 16, 5, 1.2f, "TV - Zasebna raba - Pravne osebe", 10f },
                    { 17, 5, 3.5f, "RA - Zasebna raba - pavšal", 8f },
                    { 18, 5, 2f, "Digitalni paket - Pravne osebe", 15f },
                    { 19, 6, 10f, "TV - Javna raba - pavšal", 4f },
                    { 20, 6, 2.5f, "RA - Zasebna raba - Pravne osebe", 9f },
                    { 21, 6, 1f, "Mobilni paket - Pravne osebe", 20f },
                    { 22, 7, 5f, "TV - Zasebna raba - pavšal", 4f },
                    { 23, 7, 7.2f, "RA - Javna raba - pavšal", 20f },
                    { 24, 7, 3f, "IP Telefonija - Pravne osebe", 10f },
                    { 25, 8, 2.2f, "TV - Zasebna raba - Pravne osebe", 10f },
                    { 26, 8, 5f, "RA - Zasebna raba - pavšal", 5f },
                    { 27, 8, 4.5f, "Digitalni paket - Pravne osebe", 10f },
                    { 28, 9, 8.7f, "TV - Javna raba - pavšal", 4f },
                    { 29, 9, 3.4f, "RA - Zasebna raba - Pravne osebe", 10f },
                    { 30, 9, 1.5f, "Mobilni paket - Pravne osebe", 18f },
                    { 31, 10, 4f, "TV - Zasebna raba - Pravne osebe", 8f },
                    { 32, 10, 9.2f, "RA - Javna raba - pavšal", 20f },
                    { 33, 10, 6f, "Internet - Pravne osebe", 12f },
                    { 34, 11, 2.3f, "TV - Zasebna raba - pavšal", 5f },
                    { 35, 11, 6.8f, "RA - Zasebna raba - Pravne osebe", 10f },
                    { 36, 11, 2.2f, "IP Telefonija - Pravne osebe", 15f },
                    { 37, 12, 2.5f, "TV - Javna raba - pavšal", 4f },
                    { 38, 12, 8f, "RA - Zasebna raba - pavšal", 5f },
                    { 39, 12, 1.6f, "Mobilni paket - Pravne osebe", 20f },
                    { 40, 13, 3.3f, "TV - Zasebna raba - Pravne osebe", 8f },
                    { 41, 13, 11.1f, "RA - Javna raba - pavšal", 20f },
                    { 42, 13, 5f, "Internet - Pravne osebe", 14f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "AccountHeaders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AccountHeaders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AccountHeaders",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AccountHeaders",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AccountHeaders",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AccountHeaders",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AccountHeaders",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AccountHeaders",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AccountHeaders",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AccountHeaders",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
