using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.Document
{
    public class ReadDocumentsResponseInvalidUserName : ReadDocumentsResponse
    {
        public ReadDocumentsResponseInvalidUserName(ReadDocumentsRequest request) : base(request) { }
    }
}
