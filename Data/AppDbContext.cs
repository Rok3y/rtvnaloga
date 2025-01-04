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
        }
    }
}
