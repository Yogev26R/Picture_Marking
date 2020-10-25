using Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.Document
{
    public class DeleteDocumentResponse : Response
    {
        public DeleteDocumentRequest Request { get; }

        public DeleteDocumentResponse(DeleteDocumentRequest request)
        {
            Request = request;
        }
    }
}
