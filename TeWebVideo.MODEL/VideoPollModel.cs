using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeWebVideo.MODEL
{
    /// <summary>
    /// 评价IP地址实体类
    /// </summary>
    public class VideoPollModel
    {
        private string id;
        /// <summary>
        /// 主键自增
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string ip;
        /// <summary>
        /// IP地址
        /// </summary>
        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        private string videoid;
        /// <summary>
        /// 视频编号
        /// </summary>
        public string videoId
        {
            get { return videoid; }
            set { videoid = value; }
        }

        public VideoPollModel() { }
    }
}
