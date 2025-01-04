using Microsoft.Identity.Client;

namespace rtvnaloga.Models
{
    public enum Currency
    {
        EUR,
        Dollar
    }

    public class AccountHeader
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime DateTime { get; set; }
        public Currency Currency { get; set; }
        public required string RecipientName {  get; set; }
        public required string RecipientAddress { get; set; }
        public required string RecipientLocation { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    }
}
