using Microsoft.AspNetCore.Mvc;
using SGS.Domain.Dto;
using SGS.Services.Interfaces;
using System.Threading.Tasks;

namespace SGS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceHDRController : ControllerBase
    {
        private readonly IInvoiceHDRService _invoiceHDRService;
        public InvoiceHDRController(IInvoiceHDRService invoiceHDRService)
        {
            _invoiceHDRService = invoiceHDRService;
        }

        [HttpGet("GetInvoices")]
        public async Task<ActionResult> GetInvoices()
        {
            var invoices = await _invoiceHDRService.GetInvoices();
            return Ok(invoices);
        }

        [HttpPost("GetInvoiceById")]
        public async Task<ActionResult> GetInvoiceById(int invoiceId)
        {
            var invoices = await _invoiceHDRService.GetInvoice(invoiceId);
            return Ok(invoices);
        }

        [HttpPost]
        public async Task<ActionResult> CreateInvoice(InvoiceDto invoiceDto)
        {
            var invoice = await _invoiceHDRService.AddInvoice(invoiceDto);
            return Ok(invoice);
        }

        [HttpPut]
        public async Task<ActionResult> EditInvoice(InvoiceDto invoiceDto)
        {
            await _invoiceHDRService.UpdateInvoice(invoiceDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteInvoice(int InvoiceId)
        {
            await _invoiceHDRService.DeleteInvoice(InvoiceId);
            return Ok();
        }
    }
}
