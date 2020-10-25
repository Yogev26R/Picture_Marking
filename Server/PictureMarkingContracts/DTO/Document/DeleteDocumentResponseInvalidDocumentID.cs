using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.Document
{
    public class DeleteDocumentResponseInvalidDocumentID : DeleteDocumentResponse
    {
        public DeleteDocumentResponseInvalidDocumentID(DeleteDocumentRequest request) : base(request) { }
    }
}
