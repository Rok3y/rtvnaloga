using Microsoft.EntityFrameworkCore;
using rtvnaloga.Models;
using rtvnaloga.Services;

namespace rtvnaloga.Data
{
    public class InvoiceItemRepository : IInvoiceItemRepository, IDisposable
    {
        private readonly AppDbContext _context;
        private readonly ILogger<InvoiceItemRepository> _logger;

        public InvoiceItemRepository(AppDbContext context, ILogger<InvoiceItemRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<InvoiceItem> AddAsync(InvoiceItem entity)
        {
            _logger.LogInformation($"Adding new invoice item");
            _context.InvoiceItems.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _logger.LogInformation($"Deleting invoice item with ID {id}");
            var invoice = await _context.InvoiceItems.FindAsync(id);
            if (invoice != null)
            {
                _context.InvoiceItems.Remove(invoice);
                await _context.SaveChangesAsync();
                return true;
            }

            _logger.LogWarning($"Invoice item with ID {id} not found!");
            return false;
        }

        public async Task<IReadOnlyList<InvoiceItem>> GetAllAsync()
        {
            _logger.LogInformation($"Fetching all invoice items");
            return await _context.InvoiceItems.ToListAsync();
        }

        public async Task<InvoiceItem?> GetAsync(int id)
        {
            _logger.LogInformation($"Fetching invoice item with ID {id}");
            return await _context.InvoiceItems.FindAsync(id);
        }

        public async Task UpdateAsync(InvoiceItem entity)
        {
            _logger.LogInformation($"Updating invoice item with ID {entity.Id}");
            _context.InvoiceItems.Update(entity);
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
