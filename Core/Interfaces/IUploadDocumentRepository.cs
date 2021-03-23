using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IUploadDocumentRepository
    {
        Task <UploadDocument> GetDocumentAsync(int id);

        Task <IReadOnlyList<UploadDocument>> GetDocumentsAsync();

        Task <UploadDocument> GetFileAsync(string name);
    }
}