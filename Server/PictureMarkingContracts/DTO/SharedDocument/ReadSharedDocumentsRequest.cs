using PictureMarkingContracts.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.Document
{
    public class ReadSharedDocumentsRequest
    {
        public string userID { get; set; }
        public DocumentDTO[] documents { get; set; }
    }
}
