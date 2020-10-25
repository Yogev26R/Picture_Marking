using Contracts;
using Oracle.ManagedDataAccess.Client;
using PictureMarkingContracts.DTO.Marker;
using PictureMarkingContracts.Interface.DAL;
using System;
using System.Data;

namespace MarkerDAL
{
    [Register(Policy.Transient, typeof(IMarkerDAL))]
    public class MarkerDALImpl : IMarkerDAL
    {
        OracleConnection _conn;

        public MarkerDALImpl()
        {
            var strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id=yogev;Password=1234;";
            _conn = new OracleConnection(strConn);
        }

        public DataSet CreateMarker(MarkerDTO marker)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = _conn;
            cmd.CommandText = "CREATE_DOCUMENT_MARKER";
            var param = getParameter("P_DOCUMENT_ID", OracleDbType.Varchar2, marker.DocumentID);
            cmd.Parameters.Add(param);
            param = getParameter("P_MARKER_ID", OracleDbType.Varchar2, marker.MarkerID);
            cmd.Parameters.Add(param);
            param = getParameter("P_MARKER_TYPE", OracleDbType.Varchar2, marker.MarkerType);
            cmd.Parameters.Add(param);
            param = getParameter("P_MARKER_LOCATION", OracleDbType.Varchar2, marker.MarkerLocation);
            cmd.Parameters.Add(param);
            param = getParameter("P_MARKER_COLOR", OracleDbType.Varchar2, marker.MarkerColor);
            cmd.Parameters.Add(param);
            param = getParameter("P_USER_ID", OracleDbType.Varchar2, marker.UserID);
            cmd.Parameters.Add(param);
            return ExecSPQuery(cmd);
        }

        public DataSet ReadMarkers(string documentID)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = _conn;
            cmd.CommandText = "READ_DOCUMENT_MARKERS";
            var param = getParameter("P_DOCUMENT_ID", OracleDbType.Varchar2, documentID);
            cmd.Parameters.Add(param);
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
