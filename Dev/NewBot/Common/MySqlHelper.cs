using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace NewBot.Common
{
    public class MySqlHelper
    {
        private MySqlConnection conn = null;
        private MySqlCommand cmd = null;
        private MySqlDataReader sdr = null;

        public MySqlHelper()
        {
            string strconn = "Database='newbot';Data Source=localhost;User ID=root;Password=123456;CharSet=utf8;";
            conn = new MySqlConnection(strconn);
        }

        private MySqlConnection GetConn()
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            return conn;
        }

        private void OutConn()
        {
            if (conn.State == ConnectionState.Open) conn.Close();
        }

        /// <summary>
        /// 执行不带参数的增删改SQL语句或存储过程
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public int ExecureNonQuery(string sqlstr, CommandType ct)
        {
            int re;
            try
            {
                cmd = new MySqlCommand(sqlstr, GetConn());
                cmd.CommandType = ct;
                re = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                OutConn();
            }
            return re;
        }

        /// <summary>
        /// 执行带参数的增删改SQL语句或存储过程
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <param name="paras"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sqlstr, MySqlParameter[] paras, CommandType ct)
        {
            int re;
            try
            {
                cmd = new MySqlCommand(sqlstr, GetConn());
                cmd.CommandType = ct;
                cmd.Parameters.AddRange(paras);
                re = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                OutConn();
            }
            return re;
        }

        /// <summary>
        /// 执行不带参数的查询SQL语句或存储过程
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string sqlstr, CommandType ct)
        {
            DataTable dt = new DataTable();
            cmd = new MySqlCommand(sqlstr, GetConn());
            cmd.CommandType = ct;
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            return dt;
        }

        /// <summary>
        /// 执行带参数的查询SQL语句或存储过程
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <param name="paras"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string sqlstr, MySqlParameter[] paras, CommandType ct)
        {
            DataTable dt = new DataTable();
            cmd = new MySqlCommand(sqlstr, GetConn());
            cmd.CommandType = ct;
            cmd.Parameters.AddRange(paras);
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            return dt;
        }

        public DataTable Select(string sqlstr)
        {
            DataTable dt = new DataTable();
            cmd = new MySqlCommand(sqlstr, GetConn());
            MySqlDataReader msd = cmd.ExecuteReader();
            dt.Load(msd);
            OutConn();
            return dt;
        }

        public int CUD(string sqlstr)
        {
            cmd = new MySqlCommand(sqlstr, GetConn());
            int res = cmd.ExecuteNonQuery();
            OutConn();
            return res;
        }
    }
}
