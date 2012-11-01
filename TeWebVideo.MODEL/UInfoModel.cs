using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeWebVideo.MODEL
{
    /// <summary>
    /// 用户信息实体类
    /// </summary>
    public class UInfoModel
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

        private string nickname;
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string nickName
        {
            get { return nickname; }
            set { nickname = value; }
        }

        private string sex;
        /// <summary>
        /// 用户性别
        /// </summary>
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        private string img;
        /// <summary>
        /// 用户自定义头像
        /// </summary>
        public string Img
        {
            get { return img; }
            set { img = value; }
        }

        private string city;
        /// <summary>
        /// 用户自定义头像
        /// </summary>
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        private string qq;
        /// <summary>
        /// 联系QQ
        /// </summary>
        public string QQ
        {
            get { return qq; }
            set { qq = value; }
        }

        private string speak;
        /// <summary>
        /// 用户个性签名
        /// </summary>
        public string Speak
        {
            get { return speak; }
            set { speak = value; }
        }

        private string summark;
        /// <summary>
        /// 用户积分
        /// </summary>
        public string sumMark
        {
            get { return summark; }
            set { summark = value; }
        }

        private string sumvideo;
        /// <summary>
        /// 用户上传视频数目
        /// </summary>
        public string sumVideo
        {
            get { return sumvideo; }
            set { sumvideo = value; }
        }

        public UInfoModel() { }

        public UInfoModel(string username,string summark) 
        {
            this.username = username;
            this.summark = summark;
        }

        public UInfoModel(string username, string nickname, string sex, string img, string city, string qq, string speak)
        {
            this.username = username;
            this.nickname = nickname;
            this.sex = sex;
            this.img = img;
            this.city = city;
            this.qq = qq;
            this.speak = speak;
        }
    }
}
