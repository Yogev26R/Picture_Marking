using Contracts;
using Oracle.ManagedDataAccess.Client;
using PictureMarkingContracts.DTO.SharedDocument;
using PictureMarkingContracts.Interface.DAL;
using System;
using System.Data;

namespace SharedDocumentDAL
{
    [Register(Policy.Transient, typeof(ISharedDocumentDAL))]
    public class SharedDocumentDALImpl : ISharedDocumentDAL
    {
        OracleConnection _conn;

        public SharedDocumentDALImpl()
        {
            var strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id=yogev;Password=1234;";
            _conn = new OracleConnection(strConn);
        }

        public DataSet CreateSharedDocument(SharedDocumentDTO document)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = _conn;
            cmd.CommandText = "CREATE_SHARED_DOCUMENT";
            var param = getParameter("P_DOCUMENT_ID", OracleDbType.Varchar2, document.DocumentID);
            cmd.Parameters.Add(param);
            param = getParameter("P_USER_ID", OracleDbType.Varchar2, document.UserName);
            cmd.Parameters.Add(param);
            return ExecSPQuery(cmd);
        }

        public DataSet ReadSharedDocuments(string userID)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = _conn;
            cmd.CommandText = "READ_SHARED_DOCUMENTS";
            var param = getParameter("P_USER_ID", OracleDbType.Varchar2, userID);
            cmd.Parameters.Add(param);
            return ExecSPQuery(cmd);
        }

        public DataSet DeleteSharedDocument(SharedDocumentDTO documentID)
        {
            throw new NotImplementedException();
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
