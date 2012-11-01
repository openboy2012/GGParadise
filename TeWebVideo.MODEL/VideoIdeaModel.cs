using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeWebVideo.MODEL
{
    /// <summary>
    /// 视频评论实体类
    /// </summary>
    public class VideoIdeaModel
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
        /// 评论用户名
        /// </summary>
        public string userName
        {
            get { return username; }
            set { username = value; }
        }

        private string ip;
        /// <summary>
        /// 所在IP
        /// </summary>
        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        private string contents;
        /// <summary>
        /// 评论内容
        /// </summary>
        public string Contents
        {
            get { return contents; }
            set { contents = value; }
        }

        private string videoid;
        public string videoId
        {
            get { return videoid; }
            set { videoid = value; }
        }

        private string issuancedate;
        /// <summary>
        /// 评论发布时间
        /// </summary>
        public string issuanceDate
        {
            get { return issuancedate; }
            set { issuancedate = value; }
        }

        public VideoIdeaModel() { }

        public VideoIdeaModel(string username, string contents, string videoid, string issuancedate)
        {
            this.username = username;
            this.contents = contents;
            this.issuancedate = issuancedate;
        }
    }
}
