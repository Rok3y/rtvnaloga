using rtvnaloga.Models;
using System.Collections.Generic;

namespace rtvnaloga.Services
{
    public interface IAccountHeaderRepository
    {
        Task<AccountHeader?> GetAsync(int id);
        Task<IReadOnlyList<AccountHeader>> GetAllAsync();
        Task<AccountHeader> AddAsync(AccountHeader accountHeader);
        Task UpdateAsync(AccountHeader accountHeader);
        Task<bool> DeleteAsync(int id);

    }
}
