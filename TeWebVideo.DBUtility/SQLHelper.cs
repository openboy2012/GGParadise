/* 
 * 创建人：董佳
 * 创建时间：2010.07.31 15:51:34
 * 数据库助手类 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TeWebVideo.DBUtility
{
    public class SQLHelper
    {
        private SqlConnection conn = null;
        private SqlCommand cmd = null;

        /// <summary>
        ///创建数据库连接
        /// </summary>
        /// <returns>返回连接</returns>
        public SqlConnection createCon()
        {
            string sqlconn = ConfigurationManager.AppSettings["con"];
            conn = new SqlConnection(sqlconn);
            return conn;
        }

        /// <summary>
        ///  执行不带参数的增删改SQL语句或者存储过程
        /// </summary>
        /// <param name="cmdText">增删改SQL语句或者存储过程</param>
        /// <returns>返回结果集</returns>
        public int ExecuteNonQuery(string cmdText, CommandType ct)
        {
            int res;
            conn = createCon();
            conn.Open();
            try
            {
                cmd = new SqlCommand(cmdText, conn);
                cmd.CommandType = ct;
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return res;
        }

        /// <summary>
        ///  执行带参数的增删改SQL语句或者存储过程
        /// </summary>
        /// <param name="cmdText">增删改SQL语句或者存储过程</param>
        /// <returns>返回结果集</returns>
        public int ExecuteNonQuery(string cmdText, SqlParameter[] paras, CommandType ct)
        {
            //执行数据操作;
            int res;
            conn = createCon();
            conn.Open();
            try
            {
                using (cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = ct;
                    cmd.Parameters.AddRange(paras);
                    res = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return res;
        }

        /// <summary>
        ///  执行不带带参数的查询SQL语句或者存储过程
        /// </summary>
        /// <param name="cmdText">查询SQL语句或者存储过程</param>
        /// <returns>返回结果集</returns>
        public DataTable getRow(string cmdText, CommandType ct)
        {
            DataTable dt = new DataTable();
            conn = createCon();
            conn.Open();
            try
            {
                cmd = new SqlCommand(cmdText, conn);
                cmd.CommandType = ct;
                using (SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    dt.Load(sdr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //运用了CommandBehavior.CloseConnection)不需要关闭连接;
            }
            return dt;
        }

        /// <summary>
        ///  执行带参数的查询SQL语句或者存储过程
        /// </summary>
        /// <param name="cmdText">查询SQL语句或者存储过程</param>
        /// <param name="paras">参数集合</param>
        /// <returns>返回结果集</returns>
        public DataTable getRow(string cmdText, SqlParameter[] paras, CommandType ct)
        {
            DataTable dt = new DataTable();
            conn = createCon();
            conn.Open();
            try
            {
                cmd = new SqlCommand(cmdText, conn);
                cmd.CommandType = ct;
                cmd.Parameters.AddRange(paras);
                using (SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    dt.Load(sdr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //运用了CommandBehavior.CloseConnection)不需要关闭连接;
            }
            return dt;
        }
    }
}
