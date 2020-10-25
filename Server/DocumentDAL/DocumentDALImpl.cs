using Contracts;
using Oracle.ManagedDataAccess.Client;
using PictureMarkingContracts.DTO.Document;
using PictureMarkingContracts.Interface.DAL;
using System;
using System.Data;

namespace DocumentDAL
{
    [Register(Policy.Transient, typeof(IDocumentDAL))]
    public class DocumentDALImpl : IDocumentDAL
    {
        OracleConnection _conn;

        public DocumentDALImpl()
        {
            var strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id=yogev;Password=1234;";
            _conn = new OracleConnection(strConn);
        }

        public DataSet CreateDocument(DocumentDTO document)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = _conn;
            cmd.CommandText = "CREATE_DOCUMENT";
            var param = getParameter("P_OWNER_ID", OracleDbType.Varchar2, document.OwnerID);
            cmd.Parameters.Add(param);
            param = getParameter("P_IMAGE_URL", OracleDbType.Varchar2, document.ImageURL);
            cmd.Parameters.Add(param);
            param = getParameter("P_DOCUMENT_NAME", OracleDbType.Varchar2, document.DocumentName);
            cmd.Parameters.Add(param);
            param = getParameter("P_DOCUMENT_ID", OracleDbType.Varchar2, document.DocumentID);
            cmd.Parameters.Add(param);
            return ExecSPQuery(cmd);
        }

        public DataSet ReadDocument(string documentID)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = _conn;
            cmd.CommandText = "READ_DOCUMENT";
            var param = getParameter("P_DOCUMENT_ID", OracleDbType.Varchar2, documentID);
            cmd.Parameters.Add(param);
            return ExecSPQuery(cmd);
        }

        public DataSet ReadDocuments(string userID)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = _conn;
            cmd.CommandText = "READ_DOCUMENTS";
            var param = getParameter("P_USER_ID", OracleDbType.Varchar2, userID);
            cmd.Parameters.Add(param);
            return ExecSPQuery(cmd);
        }

        public DataSet UpdateDocument(DocumentDTO document)
        {
            throw new NotImplementedException();
        }

        public DataSet DeleteDocument(DocumentDTO document)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = _conn;
            cmd.CommandText = "DELETE_DOCUMENT";
            var paramUserName = getParameter("P_DOCUMENT_ID", OracleDbType.Varchar2, document.DocumentID);
            cmd.Parameters.Add(paramUserName);
            return ExecSPQuery(cmd);
        }

        public DataSet ExecSPQuery(OracleCommand cmd)
        {
            var retval = new DataSet();
            var outParam = new OracleParameter();
            cmd.CommandType = CommandType.StoredProcedure;
            outParam.ParameterName = "P_RETVAL";
            outParam.OracleDbType = OracleDbType.RefCursor;
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(retval);
            return retval;
        }

        private OracleParameter getParameter
            (
            string paramName,
            OracleDbType paramType,
            object paramValue
            )
        {
            var retval = new OracleParameter();
            retval.ParameterName = paramName;
            retval.OracleDbType = paramType;
            retval.Value = paramValue;
            return retval;
        }
    }
}
