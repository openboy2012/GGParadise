using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeWebVideo.MODEL
{
    /// <summary>
    /// 系统日志实体类
    /// </summary>
    public class SystemNotesModel
    {
        public string id
        {
            get;
            set;
        }

        public string userName
        {
            get;
            set;
        }

        public string privilege
        {
            get;
            set;
        }

        public string ip
        {
            get;
            set;
        }

        public string time
        {
            get;
            set;
        }

        public string operate
        {
            get;
            set;
        }

        public SystemNotesModel() { }
    }
}
