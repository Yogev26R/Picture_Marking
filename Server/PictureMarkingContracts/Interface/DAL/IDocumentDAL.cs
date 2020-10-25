using PictureMarkingContracts.DTO.Document;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PictureMarkingContracts.Interface.DAL
{

    public interface IDocumentDAL
    {
        public DataSet CreateDocument(DocumentDTO document);

        public DataSet ReadDocuments(string userID);

        public DataSet ReadDocument(string documentName);

        public DataSet UpdateDocument(DocumentDTO document);

        public DataSet DeleteDocument(DocumentDTO documentID);
    }

}
