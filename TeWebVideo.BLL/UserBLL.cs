using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using TeWebVideo.MODEL;
using TeWebVideo.DAL;

namespace TeWebVideo.BLL
{
    public class UserBLL
    {
        private UserDAL userDAL;
        public UserBLL()
        {
            userDAL = new UserDAL();
        }

        #region  用户注册页面业务逻辑

        //检查用户
        public bool checkUser(string userName)
        {
            return userDAL.IsExistence(userName);
        }

        //注册新用户
        public bool newRegister(URegModel uRegModel)
        {
            return userDAL.register(uRegModel);
        }

        #endregion

        #region 用户登录页面业务逻辑

        //登陆
        public bool login(URegModel ur)
        {
            bool flag = false;
            DataTable dt = new DataTable();
            dt = userDAL.checkUser(ur);
            if (dt.Rows.Count > 0)
            {
                if (userDAL.loginTime(ur.userName))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            return flag;
        }

        //用户注册信息
        public URegModel getUReg(string userName)
        {
            return userDAL.getRegInfo(userName);
        }

        //管理员信息
        public DataTable getAdminInfo(string userName)
        {
            return userDAL.getAdminInfo(userName);
        }

        //用户详细信息
        public UInfoModel getUInfo(string userName)
        {
            return userDAL.getUserInfo(userName);
        }

        #endregion

        #region 用户更新信息页面业务逻辑

        //更新用户信息
        public bool updateUserInfo(UInfoModel uInfoModel)
        {
            return userDAL.updateUserInfo(uInfoModel);
        }

        //更新用户昵称
        public bool updateNickname(UInfoModel uim)
        {
            return userDAL.updateNickname(uim);
        }

        //删除注册用户
        public bool deleteUserRegister(string id)
        {
            return userDAL.deleteUserRegister(id);
        }

        #endregion

        #region 用户上传视频页面业务逻辑
        //插入视频信息到数据库
        public bool insertVideo(VideoInfoModel vim)
        {
            return userDAL.insertVideo(vim);
        }

        //增加积分
        public bool addSumMark(UInfoModel uim)
        {
            return userDAL.addSumMark(uim);
        }

        //减少积分
        public bool subSumMark(UInfoModel uim)
        {
            return userDAL.addSumMark(uim);
        }

        //增加视频数目
        public bool addSumVideo(string userName)
        {
            return userDAL.addSumVideo(userName);
        }
        #endregion

        #region 用户密码页面业务逻辑
        //更新密码
        public bool UpdatePass(string username, string password)
        {
            return userDAL.userPassUpdate(username, password);
        }

        #endregion

        #region 用户管理
        //用户管理
        public DataTable getUserRegisterInfo(string cmd, string privilege, string key)
        {
            DataTable dt = new DataTable();
            if (key != null)
            {
                if (cmd == "admin")
                {
                    dt = userDAL.getUserRegisterByPrivilege(privilege);
                }
                else if (cmd == "lock")
                {
                    dt = userDAL.getUserRegisterByUserNameOrderByLock(privilege, key);
                }
                else
                {
                    dt = userDAL.getUserRegisterByUserName(privilege, key);
                }
            }
            else
            {
                if (cmd == "lock")
                {
                    dt = userDAL.getUserRegisterOrderByLocked(privilege);
                }
                else
                {
                    dt = userDAL.getAllUserRegister(privilege);
                }
            }
            return dt;
        }

        //按用户组查询用户信息
        public DataTable getUserRegisterByGroup(string privilege)
        {
            return userDAL.getUserRegisterByPrivilege(privilege);
        }

        //设置用户权限
        public bool doPrivilege(string userName, string privilege)
        {
            return userDAL.setPrivilege(userName, privilege);
        }

        //更改用户状态
        public bool doStatus(string userName, string reason)
        {
            return userDAL.setStatus(userName, reason);
        }
        #endregion
    }
}
