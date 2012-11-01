using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using TeWebVideo.DBUtility;
using TeWebVideo.MODEL;

namespace TeWebVideo.DAL
{
    /// <summary>
    /// 用户数据访问层
    /// </summary>
    public class UserDAL
    {
        private SQLHelper sqlhelper;
        public UserDAL()
        {
            sqlhelper = new SQLHelper();
        }

        #region 用户注册页面数据访问方法

        /// <summary>
        /// 检查注册用户名是否已经存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public bool IsExistence(string username)
        {
            bool flag = false;
            DataTable dt = new DataTable();
            string cmdText = "select * from userRegister where userName = @userName";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@userName", username ),
            };
            dt = sqlhelper.getRow(cmdText, paras, CommandType.Text);
            if (dt.Rows.Count > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="uReg">注册实体参数</param>
        /// <returns></returns>
        public bool register(URegModel uReg)
        {
            bool flag = false;
            string cmdText = "insert into userRegister(userName,userPass,passQuestion,passAnswer,email) values(@userName,@userPass,@passQuestion,@passAnswer,@email);";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter ("@userName", uReg.userName ),
                new SqlParameter ("@userPass",uReg.userPass ),
                new SqlParameter ("@passQuestion",uReg.passQuestion ),
                new SqlParameter ("@passAnswer",uReg.passAnswer),
                new SqlParameter ("@email",uReg.Email)
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 查询所有的注册用户
        /// </summary>
        /// <returns></returns>
        public DataTable getAllUserRegister(string privilege)
        {
            string cmdText = "select * from userRegister where privilege<@privilege order by privilege desc";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter ("@privilege", privilege)
            };
            DataTable dt = sqlhelper.getRow(cmdText, paras, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// 按用户名查询用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public DataTable getUserRegisterByUserName(string privilege, string userName)
        {
            DataTable dt = new DataTable();
            string cmdText = "select * from userRegister where userName like '%" + userName + "%' and privilege<@privilege";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter ("@privilege", privilege)
            };
            dt = sqlhelper.getRow(cmdText, paras, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// 按用户名查询管理员信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public DataTable getAdminInfo(string userName)
        {
            DataTable dt = new DataTable();
            string cmdText = "select * from userRegister where userName =@userName;";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter ("@userName", userName )
            };
            dt = sqlhelper.getRow(cmdText, paras, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// 按权限查询用户信息
        /// </summary>
        /// <param name="privilege">用户权限</param>
        /// <returns></returns>
        public DataTable getUserRegisterByPrivilege(string privilege)
        {
            DataTable dt = new DataTable();
            string cmdText = "select * from userRegister where privilege = @privilege order by privilege desc";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@privilege",privilege),
            };
            dt = sqlhelper.getRow(cmdText, paras, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// 按用户状态排序查询用户信息
        /// </summary>
        /// <returns></returns>
        public DataTable getUserRegisterOrderByLocked(string privilege)
        {
            DataTable dt = new DataTable();
            string cmdText = "select * from userRegister where privilege <@privilege order by lock desc";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@privilege",privilege)
            };
            dt = sqlhelper.getRow(cmdText, paras, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// 按用户名查询状态锁定的用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable getUserRegisterByUserNameOrderByLock(string privilege, string key)
        {
            DataTable dt = new DataTable();
            string cmdText = "select * from userRegister where userName  like '%" + key + "%'  and lock='1' and privilege<@privilege order by privilege desc ";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@privilege",privilege)
            };
            dt = sqlhelper.getRow(cmdText, paras, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// 设置用户权限
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="privilege">用户权限</param>
        /// <returns></returns>
        public bool setPrivilege(string userName, string privilege)
        {
            bool flag = false;
            DataTable dt = new DataTable();
            string cmdText = "Update userRegister set privilege=@privilege where userName =@userName";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@userName", userName ),
                new SqlParameter("@privilege",privilege)
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 设置用户状态
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="statusReason">状态原因</param>
        /// <returns></returns>
        public bool setStatus(string userName, string statusReason)
        {
            bool flag = false;
            DataTable dt = new DataTable();
            string cmdText = "update userRegister set lock =case (select lock from userRegister where userName=@userName) when '1' then '0' when '0' then '1' end,lockCause=@statusReason where userName=@userName";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@userName", userName ),
                new SqlParameter("@statusReason", statusReason)
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 按ID号删除用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool deleteUserRegister(string id)
        {
            bool flag = false;
            DataTable dt = new DataTable();
            string cmdText = "delete from userRegister where id= @id";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@id", id )
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion

        #region 登录页面数据访问方法

        /// <summary>
        /// 用户登录数据访问
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public DataTable checkUser(URegModel uRegModel)
        {
            DataTable dt = new DataTable();
            string cmdText = "select * from userRegister where userName = @userName  and userPass =@pwd ";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@userName",uRegModel.userName ),
                new SqlParameter("@pwd",uRegModel.userPass)
            };
            dt = sqlhelper.getRow(cmdText, paras, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// 更新登陆时间
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public bool loginTime(string userName)
        {
            bool flag = false;
            DataTable dt = new DataTable();
            string cmdText = "update userRegister set updateTime =getDate() where userName=@userName";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@userName", userName )
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 返回注册用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public URegModel getRegInfo(string userName)
        {
            URegModel uRegModel = new URegModel();
            DataTable dt = new DataTable();
            string cmdText = "select * from userRegister where userName = @userName";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@userName",userName),
            };
            dt = sqlhelper.getRow(cmdText, paras, CommandType.Text);
            uRegModel.Id = dt.Rows[0]["id"].ToString();
            uRegModel.userName = dt.Rows[0]["userName"].ToString();
            uRegModel.userPass = dt.Rows[0]["userPass"].ToString();
            uRegModel.passQuestion = dt.Rows[0]["passQuestion"].ToString();
            uRegModel.passAnswer = dt.Rows[0]["passAnswer"].ToString();
            uRegModel.Email = dt.Rows[0]["email"].ToString();
            uRegModel._Lock = dt.Rows[0]["lock"].ToString();
            uRegModel.lockCause = dt.Rows[0]["lockCause"].ToString();
            uRegModel.Privilege = dt.Rows[0]["privilege"].ToString();
            uRegModel.registerDate = dt.Rows[0]["registerDate"].ToString();
            uRegModel.updateTime = dt.Rows[0]["updateTime"].ToString();
            return uRegModel;
        }
        #endregion

        #region 密码找回数据访问方法

        /// <summary>
        /// 用户密码更新
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="userpass">用户新密码</param>
        /// <returns></returns>
        public bool userPassUpdate(string username, string userpass)
        {
            bool flag = false;
            string cmdText = "update userRegister set userPass = @userPass where userName = @userName";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@userName", username ),
                new SqlParameter ("@userPass",userpass)
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion

        #region 用户信息更新页面数据访问方法

        public bool updateNickname(UInfoModel uInfo)
        {
            bool flag = false;
            string cmdText = "update userInfo set nickname=@nickName where userName=@userName";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter ("@userName", uInfo.userName),
                new SqlParameter ("@nickName",uInfo.nickName)
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 用户信息更新
        /// </summary>
        /// <param name="ui">用户信息实体参数</param>
        /// <returns>返回真或假</returns>
        public bool updateUserInfo(UInfoModel uInfo)
        {
            bool flag = false;
            string cmdText = "update userInfo set sex =@sex,img=@img,city=@city,QQ=@qq,speak=@speak where userName=@userName";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter ("@userName", uInfo.userName),
                new SqlParameter ("@sex",uInfo.Sex ),
                new SqlParameter ("@img",uInfo.Img),
                new SqlParameter ("@city",uInfo.City),
                new SqlParameter ("@qq",uInfo.QQ),
                new SqlParameter ("@speak",uInfo.Speak)
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 根据用户名查找用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public UInfoModel getUserInfo(string userName)
        {
            UInfoModel uInfoModel = new UInfoModel();
            DataTable dt = new DataTable();
            string cmdText = "select * from userInfo where userName = @userName";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter ("@userName", userName)
            };
            dt = sqlhelper.getRow(cmdText, paras, CommandType.Text);
            uInfoModel.Id = dt.Rows[0]["id"].ToString();
            uInfoModel.userName = dt.Rows[0]["userName"].ToString();
            uInfoModel.nickName = dt.Rows[0]["nickName"].ToString();
            uInfoModel.Sex = dt.Rows[0]["sex"].ToString();
            uInfoModel.Img = dt.Rows[0]["img"].ToString();
            uInfoModel.City = dt.Rows[0]["city"].ToString();
            uInfoModel.Speak = dt.Rows[0]["speak"].ToString();
            uInfoModel.sumMark = dt.Rows[0]["summark"].ToString();
            uInfoModel.sumVideo = dt.Rows[0]["sumvideo"].ToString();
            return uInfoModel;
        }

        #endregion

        #region 用户上传视频数据访问方法

        /// <summary>
        /// 上传视频到服务器
        /// </summary>
        /// <param name="vi">视频实体参数</param>
        /// <returns>返回真或假</returns>
        public bool insertVideo(VideoInfoModel vInfo)
        {
            bool flag = false;
            string cmdText = "insert into videoInfo(userName,videoTitle,videoContent,videoPath,videoPicture,videoType) values(@username,@videotitle,@videocontent,@videopath,@videopicture,@videotype)";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter ("@username",vInfo.userName),
                new SqlParameter ("@videotitle",vInfo.videoTitle),
                new SqlParameter ("@videocontent",vInfo.videoContent),
                new SqlParameter ("@videopath",vInfo.videoPath),
                new SqlParameter ("@videopicture",vInfo.videoPicture),
                new SqlParameter ("@videotype",vInfo.videoType)
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 用户积分增加
        /// </summary>
        /// <param name="uInfo">积分实体</param>
        /// <returns></returns>
        public bool addSumMark(UInfoModel uInfo)
        {
            bool flag = false;
            string cmdText = "update userInfo set SumMark = SumMark+@sumMark where userName = @userName";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@userName", uInfo.userName ),
                new SqlParameter("@sumMark",uInfo.sumMark)
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 用户积分减少
        /// </summary>
        /// <param name="uInfo">积分实体</param>
        /// <returns></returns>
        public bool subSumMark(UInfoModel uInfo)
        {
            bool flag = false;
            string cmdText = "update userInfo set SumMark = SumMark-@sumMark where userName = @userName";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@userName", uInfo.userName ),
                new SqlParameter("@sumMark",uInfo.sumMark)
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        ///  用户上传视频数目增加
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public bool addSumVideo(string userName)
        {
            bool flag = false;
            string cmdText = "update userInfo set SumVideo = SumVideo+1 where userName = @userName";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@userName", userName )
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }

        #endregion
    }
}