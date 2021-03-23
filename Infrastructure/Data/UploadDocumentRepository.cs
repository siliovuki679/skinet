using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class UploadDocumentRepository : IUploadDocumentRepository
    {
        private readonly StoreContext _context;
        public UploadDocumentRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<UploadDocument> GetDocumentAsync(int id)
        {
            return await _context.UploadDocuments.FindAsync(id);
        }

        public async Task<IReadOnlyList<UploadDocument>> GetDocumentsAsync()
        {
            return await _context.UploadDocuments.ToListAsync();
        }

        public async Task<UploadDocument> GetFileAsync(string name)
        {
            return await _context.UploadDocuments.FindAsync(name);
        }
    }
}