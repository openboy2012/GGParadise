using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using TeWebVideo.MODEL;
using TeWebVideo.DAL;

namespace TeWebVideo.BLL
{
    public class SysNotesBLL
    {
        private AdminDAL admindal;
        DataTable dt = new DataTable();
        SystemNotesModel snm = new SystemNotesModel();
        public SysNotesBLL()
        {
            admindal = new AdminDAL();
        }

        public bool sysNotesAdd(string userName, string privilege, string ip, string keyword, int cmd)
        {
            bool flag = false;
            snm.userName = userName;
            snm.privilege = privilege;
            snm.ip = ip;
            switch (cmd)
            {
                case 0:
                    {
                        snm.operate = "成功登录了乖乖乐园管理系统(后台)";
                        break;
                    }
                case 1:
                    {
                        snm.operate = "在视频审核模块进行了以下操作:" + keyword;
                        break;
                    }
                case 2:
                    {
                        snm.operate = "在视频管理模块进行了以下操作:" + keyword;
                        break;
                    }
                case 3:
                    {
                        snm.operate = "在用户管理模块进行了以下操作:" + keyword;
                        break;
                    }
                case 4:
                    {
                        snm.operate = "在视频评论管理模块进行了以下操作:" + keyword;
                        break;
                    }
                case 5:
                    {
                        snm.operate = "在站内公告管理模块进行了以下操作:" + keyword;
                        break;
                    }
            }
            admindal.sysNotesAdd(snm);
            return flag;
        }

        public DataTable getSystemNotes()
        {
            return admindal.getSystemNotesByTimeDesc();
        }
    }
}
