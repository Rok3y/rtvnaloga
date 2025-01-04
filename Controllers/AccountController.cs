using Microsoft.AspNetCore.Mvc;
using rtvnaloga.Models;
using rtvnaloga.Services;

namespace rtvnaloga.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountHeaderRepository _accountHeaderRepository;

        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountHeaderRepository accountHeaderRepository, ILogger<AccountController> logger)
        {
            _logger = logger;
            _accountHeaderRepository = accountHeaderRepository;
        }

        // GET: api/accounts
        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            _logger.LogInformation("GET request for accounts");
            var accounts = await _accountHeaderRepository.GetAllAsync();

            return Ok(accounts);
        }

        // GET: api/
        [HttpGet("id")]
        public async Task<IActionResult> GetByAccountId(int id)
        {
            _logger.LogInformation("GET request for Account with ID {Id}", id);
            var account = await _accountHeaderRepository.GetAsync(id);
            if (account == null)
            {
                _logger.LogWarning($"Account with ID {id} not found");
                return NotFound();
            }

            return Ok(account);
        }

        // POST: api/accounts
        [HttpPost]
        public async Task<IActionResult> AddAccount([FromBody] AccountHeader newAccount)
        {
            if (newAccount == null)
            {
                _logger.LogWarning($"Account cannot be null");
                return BadRequest("Account cannot be null");
            }

            var createdAccount = await _accountHeaderRepository.AddAsync(newAccount);

            return CreatedAtAction(nameof(AddAccount), new { id = createdAccount.Id });
        }

        // PUT: api/accounts/5
        [HttpPut]
        public async Task<IActionResult> UpdateAccount(int id, [FromBody] AccountHeader updatedAccount)
        {
            if (updatedAccount == null)
                return BadRequest("Account cannot be null");

            if (updatedAccount.Id == id)
                return BadRequest("ID mismatch between URI and request body");

            var existingAccount = await _accountHeaderRepository.GetAsync(id);
            if (existingAccount == null)
                return NotFound();

            await _accountHeaderRepository.UpdateAsync(updatedAccount);

            return NoContent();
        }

        // DELETE: api/accounts/5
        [HttpDelete]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            bool success = await _accountHeaderRepository.DeleteAsync(id);
            if (!success)
            {
                return BadRequest($"Deletion of account with ID {id} failed");
            }

            return NoContent();
        }
    }
}
