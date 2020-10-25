using PictureMarkingContracts.DTO.SharedDocument;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PictureMarkingContracts.Interface.DAL
{
    public interface ISharedDocumentDAL
    {
        public DataSet CreateSharedDocument(SharedDocumentDTO document);

        public DataSet ReadSharedDocuments(string userID);

        public DataSet DeleteSharedDocument(SharedDocumentDTO documentID);
    }
}
