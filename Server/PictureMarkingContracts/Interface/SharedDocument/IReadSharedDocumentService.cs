using Contracts.DTO;
using PictureMarkingContracts.DTO.Document;
using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.Interface.SharedDocument
{
    public interface IReadSharedDocumentService
    {
        public Response ReadSharedDocuments(ReadSharedDocumentsRequest request);
    }
}
