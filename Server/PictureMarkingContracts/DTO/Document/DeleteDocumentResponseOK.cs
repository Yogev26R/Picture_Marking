using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.Document
{
    public class DeleteDocumentResponseOK : DeleteDocumentResponse
    {
        public DeleteDocumentResponseOK(DeleteDocumentRequest request) : base(request) { }
    }
}
