using Microsoft.EntityFrameworkCore;
using rtvnaloga.Controllers;
using rtvnaloga.Models;
using rtvnaloga.Services;

namespace rtvnaloga.Data
{
    public class AccountHeaderRepository : IAccountHeaderRepository, IDisposable
    {
        private readonly AppDbContext _context;
        private readonly ILogger<AccountHeaderRepository> _logger;

        public AccountHeaderRepository(AppDbContext context, ILogger<AccountHeaderRepository> logger) 
        {
            _context = context;
            _logger = logger;
        }

        public async Task<AccountHeader?> GetAsync(int id)
        {
            return await _context.AccountHeaders.Include(a => a.InvoiceItems).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IReadOnlyList<AccountHeader>> GetAllAsync()
        {
            return await _context.AccountHeaders.ToListAsync();
        }


        public async Task<AccountHeader> AddAsync(AccountHeader accountHeader)
        {
            _logger.LogInformation($"Inserting new account item");
            _context.AccountHeaders.Add(accountHeader);
            await _context.SaveChangesAsync();
            return accountHeader;
        }

        public async Task<bool> DeleteAsync(int id)
        {

            _logger.LogInformation($"Deleting account item with ID {id}");
            var accountHeader = await _context.AccountHeaders.FindAsync(id);
            if (accountHeader != null)
            {
                _context.AccountHeaders.Remove(accountHeader);
                await _context.SaveChangesAsync();
                return true;
            }

            _logger.LogWarning($"Account with ID {id} not found!");
            return false;
        }

        public async Task UpdateAsync(AccountHeader accountHeader)
        {
            _logger.LogInformation($"Updating account item with ID {accountHeader.Id}");
            _context.AccountHeaders.Update(accountHeader);
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
