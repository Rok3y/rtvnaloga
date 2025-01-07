using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using rtvnaloga.Models;
using rtvnaloga.Services;

namespace rtvnaloga.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceItemRepository _invoiceItemRepository;

        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(IInvoiceItemRepository invoiceItemRepository, ILogger<InvoiceController> logger)
        {
            _logger = logger;
            _invoiceItemRepository = invoiceItemRepository;
        }

        // GET: api/Invoices
        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            _logger.LogInformation("GET request for Invoices");
            var Invoices = await _invoiceItemRepository.GetAllAsync();

            return Ok(Invoices);
        }

        // GET: api/Invoices
        [HttpGet("id")]
        public async Task<IActionResult> GetByInvoiceId(int id)
        {
            _logger.LogInformation("GET request for Invoice with ID {Id}", id);
            var Invoice = await _invoiceItemRepository.GetAsync(id);
            if (Invoice == null)
            {
                _logger.LogWarning($"Invoice with ID {id} not found");
                return NotFound();
            }

            return Ok(Invoice);
        }

        // GET: api/Invoices
        [HttpGet("accountId")]
        public async Task<IActionResult> GetInvoicesByAccountId(int id)
        {
            _logger.LogInformation("GET request for Invoices with account ID {Id}", id);
            var Invoices = await _invoiceItemRepository.GetAllByAccountId(id);
            if (Invoices.IsNullOrEmpty())
            {
                _logger.LogWarning($"Invoice with ID {id} not found");
                return NotFound();
            }

            return Ok(Invoices);
        }

        // POST: api/Invoices
        [HttpPost]
        public async Task<IActionResult> AddInvoice([FromBody] InvoiceItem newInvoice)
        {
            if (newInvoice == null)
            {
                _logger.LogWarning($"Invoice cannot be null");
                return BadRequest("Invoice cannot be null");
            }

            var createdInvoice = await _invoiceItemRepository.AddAsync(newInvoice);

            return CreatedAtAction(nameof(AddInvoice), new { id = createdInvoice.Id });
        }

        // PUT: api/Invoices/5
        [HttpPut]
        public async Task<IActionResult> UpdateInvoice(int id, [FromBody] InvoiceItem updatedInvoice)
        {
            if (updatedInvoice == null)
                return BadRequest("Invoice cannot be null");

            if (updatedInvoice.Id == id)
                return BadRequest("ID mismatch between URI and request body");

            var existingInvoice = await _invoiceItemRepository.GetAsync(id);
            if (existingInvoice == null)
                return NotFound();

            await _invoiceItemRepository.UpdateAsync(updatedInvoice);

            return NoContent();
        }

        // DELETE: api/Invoices/5
        [HttpDelete]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            bool success = await _invoiceItemRepository.DeleteAsync(id);
            if (!success)
            {
                return BadRequest($"Deletion of Invoice with ID {id} failed");
            }

            return NoContent();
        }
    }
}
