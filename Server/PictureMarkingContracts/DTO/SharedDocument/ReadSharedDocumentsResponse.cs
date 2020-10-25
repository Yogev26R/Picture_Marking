using Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.Document
{
    public class ReadSharedDocumentsResponse : Response {
        public ReadSharedDocumentsRequest Request { get; }

        public ReadSharedDocumentsResponse(ReadSharedDocumentsRequest request)
        {
            Request = request;
        }
    }
}
