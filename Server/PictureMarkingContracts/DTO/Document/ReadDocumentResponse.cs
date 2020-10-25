using Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.Document
{
    public class ReadDocumentResponse : Response
    {
        public ReadDocumentRequest Request { get; }

        public ReadDocumentResponse(ReadDocumentRequest request)
        {
            Request = request;
        }
    }
}