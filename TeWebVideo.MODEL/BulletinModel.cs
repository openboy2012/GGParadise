using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeWebVideo.MODEL
{
    /// <summary>
    /// 站内公告实体类
    /// </summary>
    public class BulletinModel
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

        private string title;
        /// <summary>
        /// 公告标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string contents;
        /// <summary>
        /// 公告内容
        /// </summary>
        public string Contents
        {
            get { return contents; }
            set { contents = value; }
        }

        private string issuancedate;
        /// <summary>
        /// 公告发布日期
        /// </summary>
        public string issuanceDate
        {
            get { return issuancedate; }
            set { issuancedate = value; }
        }

        public BulletinModel() { }
    }
}
