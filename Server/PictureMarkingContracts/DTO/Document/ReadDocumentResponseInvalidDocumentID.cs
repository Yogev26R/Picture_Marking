using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.Document
{
    public class ReadDocumentResponseInvalidDocumentID : ReadDocumentResponse
    {
        public ReadDocumentResponseInvalidDocumentID(ReadDocumentRequest request) : base(request) { }
    }
}
