using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using TeWebVideo.MODEL;
using TeWebVideo.DBUtility;

namespace TeWebVideo.DAL
{
    /// <summary>
    /// 管理员数据访问层
    /// </summary>
    public class AdminDAL
    {
        private SQLHelper sqlhelper;
        public AdminDAL()
        {
            sqlhelper = new SQLHelper();
        }

        #region 用户管理数据访问方法
        #endregion

        #region 站内管理数据访问方法

        /// <summary>
        /// 站内公告查询
        /// </summary>
        /// <returns>返回最新更新的一条站内公告</returns>
        public BulletinModel getBulletin()
        {
            BulletinModel bulletinModel = new BulletinModel();
            DataTable dt = new DataTable();
            string cmdText = "select top 1 * from bulletin order by issuanceDate desc";
            dt = sqlhelper.getRow(cmdText, CommandType.Text);
            bulletinModel.Id = dt.Rows[0]["id"].ToString();
            bulletinModel.Title = dt.Rows[0]["title"].ToString();
            bulletinModel.Contents = dt.Rows[0]["contents"].ToString();
            bulletinModel.issuanceDate = dt.Rows[0]["issuanceDate"].ToString();
            return bulletinModel;
        }

        /// <summary>
        /// 返回所有的站内公告
        /// </summary>
        /// <returns></returns>
        public DataTable getBulletins()
        {
            DataTable dt = new DataTable();
            string cmdText = "select  * from bulletin order by issuanceDate desc";
            dt = sqlhelper.getRow(cmdText, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// 添加新公告
        /// </summary>
        /// <param name="bm">公告实体类</param>
        /// <returns></returns>
        public bool addBulletin(BulletinModel bm)
        {
            bool flag = false;
            string cmdText = "insert into bulletin(title,contents) values(@title,@contents)";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter ("@title",bm.Title),
                new SqlParameter ("@contents",bm.Contents)     
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 按编号删除站内公告
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public bool deleteBulletin(int id)
        {
            bool flag = false;
            string cmdText = "delete from bulletin where id =@id";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter ("@id",id)
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 查询未通过审核的视频评论
        /// </summary>
        /// <returns></returns>
        public DataTable selectCommentNotAuditing()
        {
            DataTable dt = new DataTable();
            string cmdText = "select * from videoIdea where auditing ='0' order by issuanceDate desc";
            dt = sqlhelper.getRow(cmdText, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// 按评论ID删除评论
        /// </summary>
        /// <param name="id">评论ID</param>
        /// <returns></returns>
        public bool deleteComment(int id)
        {
            bool flag = false;
            string cmdText = "delete from videoIdea where id =@id";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter ("@id",id)
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 评论通过审核
        /// </summary>
        /// <param name="id">评论ID</param>
        /// <returns></returns>
        public bool passComment(int id)
        {
            bool flag = false;
            string cmdText = "update videoIdea set auditing= '1' where id =@id";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter ("@id",id)
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 查询所评论
        /// </summary>
        /// <returns></returns>
        public DataTable selectCommentAll()
        {
            DataTable dt = new DataTable();
            string cmdText = "select * from videoIdea order by issuanceDate desc";
            dt = sqlhelper.getRow(cmdText, CommandType.Text);
            return dt;
        }

        #endregion


        #region 系统日志

        /// <summary>
        /// 插入系统日志
        /// </summary>
        /// <param name="sysnotesmodel">系统日志实体类</param>
        /// <returns></returns>
        public bool sysNotesAdd(SystemNotesModel sysnotesmodel)
        {
            bool flag = false;
            string cmdText = "insert into sysNotes(userName,privilege,ip,operate) values(@userName,@privilege,@ip,@operate);";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter ("@userName",sysnotesmodel.userName),
                new SqlParameter ("@privilege",sysnotesmodel.privilege),
                new SqlParameter ("@ip",sysnotesmodel.ip),
                new SqlParameter ("@operate",sysnotesmodel.operate)
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        /// <summary>
        /// 查询系统日志
        /// </summary>
        /// <returns></returns>
        public DataTable getSystemNotesByTimeDesc()
        {
            DataTable dt = new DataTable();
            string cmdText = "select * from sysNotes order by Time desc";
            dt = sqlhelper.getRow(cmdText, CommandType.Text);
            return dt;
        }
        #endregion
    }
}
