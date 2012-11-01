using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeWebVideo.MODEL
{
    public class VideoInfoModel
    {
        private string id;
        /// <summary>
        /// 视频编号，主键自增
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string username;
        /// <summary>
        /// 上传用户名
        /// </summary>
        public string userName
        {
            get { return username; }
            set { username = value; }
        }

        private string videotitle;
        /// <summary>
        /// 视频名称
        /// </summary>
        public string videoTitle
        {
            get { return videotitle; }
            set { videotitle = value; }
        }

        private string videocontent;
        /// <summary>
        /// 视频内容（简介）
        /// </summary>
        public string videoContent
        {
            get { return videocontent; }
            set { videocontent = value; }
        }

        private string videodate;
        /// <summary>
        /// 上传日期
        /// </summary>
        public string videoDate
        {
            get { return videodate; }
            set { videodate = value; }
        }

        private string videopath;
        /// <summary>
        /// 视频文件路径
        /// </summary>
        public string videoPath
        {
            get { return videopath; }
            set { videopath = value; }
        }

        private string videopicture;
        /// <summary>
        /// 视频图片路径
        /// </summary>
        public string videoPicture
        {
            get { return videopicture; }
            set { videopicture = value; }
        }

        private string videotype;
        /// <summary>
        /// 视频类别
        /// </summary>
        public string videoType
        {
            get { return videotype; }
            set { videotype = value; }
        }

        private int playsum;
        /// <summary>
        /// 视频播放次数
        /// </summary>
        public int playSum
        {
            get { return playsum; }
            set { playsum = value; }
        }

        private int flower;
        /// <summary>
        /// 视频鲜花数目
        /// </summary>
        public int Flower
        {
            get { return flower; }
            set { flower = value; }
        }

        private int tile;
        /// <summary>
        /// 视频拍砖数目
        /// </summary>
        public int Tile
        {
            get { return tile; }
            set { tile = value; }
        }

        private string auditing;
        /// <summary>
        /// 视频审核状态
        /// </summary>
        public string Auditing
        {
            get { return auditing; }
            set { auditing = value; }
        }

        public VideoInfoModel() { }

        public VideoInfoModel(string username, string videotitle, string videocontent, string videodate, string videopath, string videopicture, string videotype)
        {
            this.username = username;
            this.videotitle = videotitle;
            this.videocontent = videocontent;
            this.videodate = videodate;
            this.videopath = videopath;
            this.videopicture = videopicture;
            this.videotype = videotype;
        }
    }
}
