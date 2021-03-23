using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadDocumentsController : ControllerBase
    {
        private readonly IUploadDocumentRepository _repo;
        public UploadDocumentsController(IUploadDocumentRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult<List<UploadDocument>>> GetDocuments()
        {
            var uploadDocuments = await _repo.GetDocumentsAsync();

            return Ok(uploadDocuments);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UploadDocument>> GetDocument(int id)
        {
            return await _repo.GetDocumentAsync(id);
        }

        [HttpGet("name")]
        public async Task<ActionResult<UploadDocument>> GetFileByName(string name)
        {
            return await _repo.GetFileAsync(name);
        }

    }
}