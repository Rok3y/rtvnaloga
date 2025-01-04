using rtvnaloga.Models;

namespace rtvnaloga.Services
{
    public interface IInvoiceItemRepository
    {
        Task<InvoiceItem?> GetAsync(int id);
        Task<IReadOnlyList<InvoiceItem>> GetAllAsync();
        Task<InvoiceItem> AddAsync(InvoiceItem entity);
        Task UpdateAsync(InvoiceItem entity);
        Task<bool> DeleteAsync(int id);
    }
}
