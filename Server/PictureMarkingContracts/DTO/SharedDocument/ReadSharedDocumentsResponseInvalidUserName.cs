using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.Document
{
    public class ReadSharedDocumentsResponseInvalidUserName : ReadSharedDocumentsResponse
    {
        public ReadSharedDocumentsResponseInvalidUserName(ReadSharedDocumentsRequest request) : base(request) { }
    }
}
