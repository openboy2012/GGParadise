using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using TeWebVideo.MODEL;
using TeWebVideo.DAL;

namespace TeWebVideo.BLL
{
    public class AdminBLL
    {
        private AdminDAL admindal;
        DataTable dt = new DataTable();
        public AdminBLL()
        {
            admindal = new AdminDAL();
        }

        #region 用户管理页面业务逻辑
        #endregion

        #region 网站管理页面业务逻辑

        //返回第一条站内公告
        public BulletinModel getBulletin()
        {
            return admindal.getBulletin();
        }

        //返回所有的站内公告
        public DataTable getBulletins()
        {
            return admindal.getBulletins();
        }

        //添加公告
        public bool addBulletin(BulletinModel bm)
        {
            return admindal.addBulletin(bm);
        }

        //删除公告
        public bool deleteBulletin(int id)
        {
            return admindal.deleteBulletin(id);
        }

        //通过审核
        public bool passcomment(int id)
        {
            return admindal.passComment(id);
        }

        //删除评论
        public bool deletecomment(int id)
        {
            return admindal.deleteComment(id);
        }

        //查询待审核的评论
        public DataTable commentAuditing()
        {
            return admindal.selectCommentNotAuditing();
        }

        //查询所有评论/*有待考虑*/
        public DataTable commentAll()
        {
            return admindal.selectCommentAll();
        }
        #endregion
    }
}
