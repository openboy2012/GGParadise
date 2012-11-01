using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeWebVideo.MODEL
{
    /// <summary>
    /// 用户注册实体类
    /// </summary>
    public class URegModel
    {
        private string id;
        /// <summary>
        /// 主键，自增
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string username;
        /// <summary>
        /// 用户名
        /// </summary>
        public string userName
        {
            get { return username; }
            set { username = value; }
        }

        private string userpass;
        /// <summary>
        /// 用户密码
        /// </summary>
        public string userPass
        {
            get { return userpass; }
            set { userpass = value; }
        }

        private string passquestion;
        /// <summary>
        /// 用户密码保护问题
        /// </summary>
        public string passQuestion
        {
            get { return passquestion; }
            set { passquestion = value; }
        }

        private string passanswer;
        /// <summary>
        /// 用户密码保护答案
        /// </summary>
        public string passAnswer
        {
            get { return passanswer; }
            set { passanswer = value; }
        }

        private string email;
        /// <summary>
        /// 注册Email
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string _lock;
        /// <summary>
        /// 账号是否锁定
        /// </summary>
        public string _Lock
        {
            get { return _lock; }
            set { _lock = value; }
        }

        private string lockcause;
        /// <summary>
        /// 锁定原因
        /// </summary>
        public string lockCause
        {
            get { return lockcause; }
            set { lockcause = value; }
        }

        private string privilege;
        /// <summary>
        /// 用户权限级别
        /// </summary>
        public string Privilege
        {
            get { return privilege; }
            set { privilege = value; }
        }

        private string registerdate;
        /// <summary>
        /// 用户注册日期
        /// </summary>
        public string registerDate
        {
            get { return registerdate; }
            set { registerdate = value; }
        }

        private string updatetime;
        /// <summary>
        /// 登录时间更新
        /// </summary>
        public string updateTime
        {
            get { return updatetime; }
            set { updatetime = value; }
        }

        public URegModel() { }

        public URegModel(string username, string userpass)
        {
            this.username = username;
            this.userpass = userpass;
        }

        public URegModel(string username, string userpass, string passquestion, string passanswer, string email)
        {
            this.username = username;
            this.userpass = userpass;
            this.passquestion = passquestion;
            this.passanswer = passanswer;
            this.email = email;
        }
    }
}
