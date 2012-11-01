using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeWebVideo.MODEL
{
    public class UploadInfo
    {
        public bool IsReady { get; set; }
        public int ContentLength { get; set; }
        public int UploadedLength { get; set; }
        public string FileName { get; set; }
        public string SaveName { get; set; }
        public string StrExtension { get; set; }
    }
}
