using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadDocumentsController : ControllerBase
    {
        private readonly StoreContext _storeContext;
        public UploadDocumentsController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<UploadDocument>>> GetDocuments()
        {
            var uploadDocuments = await _storeContext.UploadDocuments.ToListAsync();

            return Ok(uploadDocuments);

        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<UploadDocument>> GetDocument(int id)
        {
            return await _storeContext.UploadDocuments.FindAsync(id);
        }

    }
}