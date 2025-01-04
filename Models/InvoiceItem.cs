using System.Text.Json.Serialization;

namespace rtvnaloga.Models
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public required string ItemName { get; set; }
        public float Amount { get; set; }
        public float Price { get; set; }

        // Foreign key for the realted account.
        public int AccountHeaderId { get; set; }

        // Navigation property back to account header
        [JsonIgnore]
        public AccountHeader? AccountHeader { get; set; }
    }
}
