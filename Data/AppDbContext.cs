using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using rtvnaloga.Models;

namespace rtvnaloga.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }

        public DbSet<AccountHeader> AccountHeaders { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountHeader>().
                HasMany(a => a.InvoiceItems).
                WithOne(i => i.AccountHeader).
                HasForeignKey(i => i.AccountHeaderId);

            // Test data
            modelBuilder.Entity<AccountHeader>().HasData(
                new AccountHeader
                {
                    Id = 1,
                    Number = 77553344,
                    DateTime = new DateTime(2024, 7, 1),
                    Currency = Currency.EUR,
                    RecipientName = "Janez Novak",
                    RecipientAddress = "Makadamska cesta 2",
                    RecipientLocation = "1000 Ljubljana"
                },
                new AccountHeader
                {
                    Id = 2,
                    Number = 1234567,
                    DateTime = new DateTime(2024, 8, 1),
                    Currency = Currency.EUR,
                    RecipientName = "Marija Novak",
                    RecipientAddress = "Asfaltna cesta 3",
                    RecipientLocation = "1231 Crnuce"
                }, 
                new AccountHeader
                {
                    Id = 3,
                    Number = 987654,
                    DateTime = new DateTime(2023, 2, 5),
                    Currency = Currency.EUR,
                    RecipientName = "Marko Horvat",
                    RecipientAddress = "Testna ulica 12",
                    RecipientLocation = "3000 Celje"
                }
            );

            modelBuilder.Entity<InvoiceItem>().HasData(
                // Account 1
                new InvoiceItem
                {
                    Id = 1,
                    ItemName = "TV - Javna raba - pavšal",
                    Amount = 12.75f,
                    Price = 4f,
                    AccountHeaderId = 1,
                },
                new InvoiceItem
                {
                    Id = 2,
                    ItemName = "RA - Javna raba - pavšal",
                    Amount = 3.77f,
                    Price = 20f,
                    AccountHeaderId = 1,
                    
                },
                new InvoiceItem
                {
                    Id = 3,
                    ItemName = "TV - Zasebna raba - Pravne osebe",
                    Amount = 12.75f,
                    Price = 10f,
                    AccountHeaderId = 1,
                },
                new InvoiceItem
                {
                    Id = 4,
                    ItemName = "RA - Zasebna raba - Pravne osebe",
                    Amount = 3.77f,
                    Price = 10f,
                    AccountHeaderId = 1,
                },
                // Account 2
                new InvoiceItem
                {
                    Id = 5,
                    ItemName = "TV - Zasebna raba - Pravne osebe",
                    Amount = 8.12f,
                    Price = 10f,
                    AccountHeaderId = 2,
                },
                new InvoiceItem
                {
                    Id = 6,
                    ItemName = "RA - Zasebna raba - Pravne osebe",
                    Amount = 5.17f,
                    Price = 10f,
                    AccountHeaderId = 2,
                },
                new InvoiceItem
                {
                    Id = 7,
                    ItemName = "RA - Zasebna raba - Pravne osebe",
                    Amount = 24.77f,
                    Price = 10f,
                    AccountHeaderId = 2,
                },
                // Account 3
                new InvoiceItem
                {
                    Id = 8,
                    ItemName = "TV - Javna raba - pavšal",
                    Amount = 6.0f,
                    Price = 4f,
                    AccountHeaderId = 3,
                },
                new InvoiceItem
                {
                    Id = 9,
                    ItemName = "RA - Javna raba - pavšal",
                    Amount = 18.5f,
                    Price = 20f,
                    AccountHeaderId = 3,

                },
                new InvoiceItem
                {
                    Id = 10,
                    ItemName = "TV - Zasebna raba - Pravne osebe",
                    Amount = 1.8f,
                    Price = 10f,
                    AccountHeaderId = 3,
                },
                new InvoiceItem
                {
                    Id = 11,
                    ItemName = "RA - Zasebna raba - Pravne osebe",
                    Amount = 14.4f,
                    Price = 10f,
                    AccountHeaderId = 3,
                }, 
                new InvoiceItem
                {
                    Id = 12,
                    ItemName = "RA - Zasebna raba - Pravne osebe",
                    Amount = 30f,
                    Price = 10f,
                    AccountHeaderId = 3,
                }
            );

            // Add 10 new accounts, IDs 4 through 13
            modelBuilder.Entity<AccountHeader>().HasData(
                new AccountHeader
                {
                    Id = 4,
                    Number = 99887766,
                    DateTime = new DateTime(2024, 9, 10),
                    Currency = Currency.EUR,
                    RecipientName = "Ana Kranjc",
                    RecipientAddress = "Ulica Miru 10",
                    RecipientLocation = "2000 Maribor"
                },
                new AccountHeader
                {
                    Id = 5,
                    Number = 11122233,
                    DateTime = new DateTime(2025, 1, 15),
                    Currency = Currency.Dollar,
                    RecipientName = "Petra Zagar",
                    RecipientAddress = "Bukova pot 4",
                    RecipientLocation = "4000 Kranj"
                },
                new AccountHeader
                {
                    Id = 6,
                    Number = 44455566,
                    DateTime = new DateTime(2024, 11, 20),
                    Currency = Currency.EUR,
                    RecipientName = "Tomaž Vidmar",
                    RecipientAddress = "Glavna cesta 1",
                    RecipientLocation = "6000 Koper"
                },
                new AccountHeader
                {
                    Id = 7,
                    Number = 12340001,
                    DateTime = new DateTime(2025, 5, 5),
                    Currency = Currency.EUR,
                    RecipientName = "Nina Tomšič",
                    RecipientAddress = "Obala 77",
                    RecipientLocation = "6320 Portorož"
                },
                new AccountHeader
                {
                    Id = 8,
                    Number = 55599911,
                    DateTime = new DateTime(2023, 12, 31),
                    Currency = Currency.Dollar,
                    RecipientName = "Goran Kovač",
                    RecipientAddress = "Trg Svobode 9",
                    RecipientLocation = "5000 Nova Gorica"
                },
                new AccountHeader
                {
                    Id = 9,
                    Number = 88776655,
                    DateTime = new DateTime(2024, 3, 2),
                    Currency = Currency.EUR,
                    RecipientName = "Maja Breznik",
                    RecipientAddress = "Jablana cesta 6",
                    RecipientLocation = "8000 Novo Mesto"
                },
                new AccountHeader
                {
                    Id = 10,
                    Number = 22334455,
                    DateTime = new DateTime(2025, 2, 14),
                    Currency = Currency.EUR,
                    RecipientName = "Luka Zagorc",
                    RecipientAddress = "Zgornja pot 22",
                    RecipientLocation = "9000 Murska Sobota"
                },
                new AccountHeader
                {
                    Id = 11,
                    Number = 33445566,
                    DateTime = new DateTime(2023, 10, 10),
                    Currency = Currency.EUR,
                    RecipientName = "Sara Kavčič",
                    RecipientAddress = "Sončna ulica 5",
                    RecipientLocation = "8001 Novo Mesto"
                },
                new AccountHeader
                {
                    Id = 12,
                    Number = 69696969,
                    DateTime = new DateTime(2025, 9, 9),
                    Currency = Currency.EUR,
                    RecipientName = "Domen Potrč",
                    RecipientAddress = "Cankarjeva cesta 10",
                    RecipientLocation = "2101 Maribor"
                },
                new AccountHeader
                {
                    Id = 13,
                    Number = 20247777,
                    DateTime = new DateTime(2024, 12, 25),
                    Currency = Currency.EUR,
                    RecipientName = "Eva Mlakar",
                    RecipientAddress = "Lipova pot 16",
                    RecipientLocation = "3210 Slovenske Konjice"
                }
            );

            modelBuilder.Entity<InvoiceItem>().HasData(
                new InvoiceItem
                {
                    Id = 13,
                    ItemName = "TV - Zasebna raba - pavšal",
                    Amount = 4.5f,
                    Price = 8f,
                    AccountHeaderId = 4
                },
                new InvoiceItem
                {
                    Id = 14,
                    ItemName = "RA - Javna raba - pavšal",
                    Amount = 12.7f,
                    Price = 20f,
                    AccountHeaderId = 4
                },
                new InvoiceItem
                {
                    Id = 15,
                    ItemName = "Internet - Pravne osebe",
                    Amount = 2.0f,
                    Price = 25f,
                    AccountHeaderId = 4
                },

                new InvoiceItem
                {
                    Id = 16,
                    ItemName = "TV - Zasebna raba - Pravne osebe",
                    Amount = 1.2f,
                    Price = 10f,
                    AccountHeaderId = 5
                },
                new InvoiceItem
                {
                    Id = 17,
                    ItemName = "RA - Zasebna raba - pavšal",
                    Amount = 3.5f,
                    Price = 8f,
                    AccountHeaderId = 5
                },
                new InvoiceItem
                {
                    Id = 18,
                    ItemName = "Digitalni paket - Pravne osebe",
                    Amount = 2.0f,
                    Price = 15f,
                    AccountHeaderId = 5
                },

                new InvoiceItem
                {
                    Id = 19,
                    ItemName = "TV - Javna raba - pavšal",
                    Amount = 10f,
                    Price = 4f,
                    AccountHeaderId = 6
                },
                new InvoiceItem
                {
                    Id = 20,
                    ItemName = "RA - Zasebna raba - Pravne osebe",
                    Amount = 2.5f,
                    Price = 9f,
                    AccountHeaderId = 6
                },
                new InvoiceItem
                {
                    Id = 21,
                    ItemName = "Mobilni paket - Pravne osebe",
                    Amount = 1.0f,
                    Price = 20f,
                    AccountHeaderId = 6
                },

                new InvoiceItem
                {
                    Id = 22,
                    ItemName = "TV - Zasebna raba - pavšal",
                    Amount = 5f,
                    Price = 4f,
                    AccountHeaderId = 7
                },
                new InvoiceItem
                {
                    Id = 23,
                    ItemName = "RA - Javna raba - pavšal",
                    Amount = 7.2f,
                    Price = 20f,
                    AccountHeaderId = 7
                },
                new InvoiceItem
                {
                    Id = 24,
                    ItemName = "IP Telefonija - Pravne osebe",
                    Amount = 3.0f,
                    Price = 10f,
                    AccountHeaderId = 7
                },

                new InvoiceItem
                {
                    Id = 25,
                    ItemName = "TV - Zasebna raba - Pravne osebe",
                    Amount = 2.2f,
                    Price = 10f,
                    AccountHeaderId = 8
                },
                new InvoiceItem
                {
                    Id = 26,
                    ItemName = "RA - Zasebna raba - pavšal",
                    Amount = 5.0f,
                    Price = 5f,
                    AccountHeaderId = 8
                },
                new InvoiceItem
                {
                    Id = 27,
                    ItemName = "Digitalni paket - Pravne osebe",
                    Amount = 4.5f,
                    Price = 10f,
                    AccountHeaderId = 8
                },

                new InvoiceItem
                {
                    Id = 28,
                    ItemName = "TV - Javna raba - pavšal",
                    Amount = 8.7f,
                    Price = 4f,
                    AccountHeaderId = 9
                },
                new InvoiceItem
                {
                    Id = 29,
                    ItemName = "RA - Zasebna raba - Pravne osebe",
                    Amount = 3.4f,
                    Price = 10f,
                    AccountHeaderId = 9
                },
                new InvoiceItem
                {
                    Id = 30,
                    ItemName = "Mobilni paket - Pravne osebe",
                    Amount = 1.5f,
                    Price = 18f,
                    AccountHeaderId = 9
                },

                new InvoiceItem
                {
                    Id = 31,
                    ItemName = "TV - Zasebna raba - Pravne osebe",
                    Amount = 4.0f,
                    Price = 8f,
                    AccountHeaderId = 10
                },
                new InvoiceItem
                {
                    Id = 32,
                    ItemName = "RA - Javna raba - pavšal",
                    Amount = 9.2f,
                    Price = 20f,
                    AccountHeaderId = 10
                },
                new InvoiceItem
                {
                    Id = 33,
                    ItemName = "Internet - Pravne osebe",
                    Amount = 6.0f,
                    Price = 12f,
                    AccountHeaderId = 10
                },

                new InvoiceItem
                {
                    Id = 34,
                    ItemName = "TV - Zasebna raba - pavšal",
                    Amount = 2.3f,
                    Price = 5f,
                    AccountHeaderId = 11
                },
                new InvoiceItem
                {
                    Id = 35,
                    ItemName = "RA - Zasebna raba - Pravne osebe",
                    Amount = 6.8f,
                    Price = 10f,
                    AccountHeaderId = 11
                },
                new InvoiceItem
                {
                    Id = 36,
                    ItemName = "IP Telefonija - Pravne osebe",
                    Amount = 2.2f,
                    Price = 15f,
                    AccountHeaderId = 11
                },

                new InvoiceItem
                {
                    Id = 37,
                    ItemName = "TV - Javna raba - pavšal",
                    Amount = 2.5f,
                    Price = 4f,
                    AccountHeaderId = 12
                },
                new InvoiceItem
                {
                    Id = 38,
                    ItemName = "RA - Zasebna raba - pavšal",
                    Amount = 8.0f,
                    Price = 5f,
                    AccountHeaderId = 12
                },
                new InvoiceItem
                {
                    Id = 39,
                    ItemName = "Mobilni paket - Pravne osebe",
                    Amount = 1.6f,
                    Price = 20f,
                    AccountHeaderId = 12
                },

                new InvoiceItem
                {
                    Id = 40,
                    ItemName = "TV - Zasebna raba - Pravne osebe",
                    Amount = 3.3f,
                    Price = 8f,
                    AccountHeaderId = 13
                },
                new InvoiceItem
                {
                    Id = 41,
                    ItemName = "RA - Javna raba - pavšal",
                    Amount = 11.1f,
                    Price = 20f,
                    AccountHeaderId = 13
                },
                new InvoiceItem
                {
                    Id = 42,
                    ItemName = "Internet - Pravne osebe",
                    Amount = 5.0f,
                    Price = 14f,
                    AccountHeaderId = 13
                }
            );
        }
    }
}
