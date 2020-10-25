using Contracts;
using Oracle.ManagedDataAccess.Client;
using PictureMarkingContracts.DTO.User;
using PictureMarkingContracts.Interface;
using System;
using System.Data;

namespace PictureMarkingDAL
{
    [Register(Policy.Transient, typeof(IUserDAL))]
    public class UserDALImpl : IUserDAL
    {
        OracleConnection _conn;

        public UserDALImpl()
        {
            var strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id=yogev;Password=1234;";
            _conn = new OracleConnection(strConn);
        }

        public DataSet CreateUser(RegisterDTO register)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = _conn;
            cmd.CommandText = "CREATE_USER";
            var param = getParameter("P_User_ID", OracleDbType.Varchar2, register.UserID);
            cmd.Parameters.Add(param);
            param = getParameter("P_USER_NAME", OracleDbType.Varchar2, register.Login.UserName);
            cmd.Parameters.Add(param);
            return ExecSPQuery(cmd);
        }

        public DataSet ReadUserByUserID(string userID)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = _conn;
            cmd.CommandText = "READ_USER_BY_USER_ID";
            var param = getParameter("P_User_ID", OracleDbType.Varchar2, userID);
            cmd.Parameters.Add(param);
            return ExecSPQuery(cmd);
        }

        public DataSet ReadUserByUserName(string userName)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = _conn;
            cmd.CommandText = "READ_USER_BY_USER_NAME";
            var param = getParameter("P_User_Name", OracleDbType.Varchar2, userName);
            cmd.Parameters.Add(param);
            return ExecSPQuery(cmd);
        }

        public DataSet UpdateUser(string userName)
        {
            throw new NotImplementedException();
        }

        public DataSet DeleteUser(UnSubscribeDTO unSubscribe)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = _conn;
            cmd.CommandText = "DELETE_USER";
            var paramUserID = getParameter("P_USER_ID", OracleDbType.Varchar2, unSubscribe.UserID);
            cmd.Parameters.Add(paramUserID);
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
