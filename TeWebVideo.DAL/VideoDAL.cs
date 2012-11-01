using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using TeWebVideo.MODEL;
using TeWebVideo.DBUtility;

namespace TeWebVideo.DAL
{
    /// <summary>
    /// 影片数据访问层
    /// </summary>
    public class VideoDAL
    {
        private SQLHelper sqlhelper;
        public VideoDAL()
        {
            sqlhelper = new SQLHelper();
        }

        #region 影片评论和评价数据访问方法
        /// <summary>
        /// 评论信息显示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable getVideoIdea(string id)
        {
            DataTable dt = new DataTable();
            string cmdText = "select *  from videoIdea where videoId=@id order by issuanceDate desc";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            dt = sqlhelper.getRow(cmdText, paras, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// 鲜花数目更新
        /// </summary>
        /// <param name="id">视频编号</param>
        /// <returns></returns>
        public bool updateFlower(string id)
        {
            bool flag = false;
            string cmdText = "update videoInfo set Flower=Flower+1 where Id=@id";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 拍砖数目更新
        /// </summary>
        /// <param name="id">视频编号</param>
        /// <returns></returns>
        public bool updateTile(string id)
        {
            bool flag = false;
            string cmdText = "update videoInfo set Tile=Tile+1 where Id=@id";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion

        #region 网站首页视频显示数据访问方法

        /// <summary>
        /// 最新上传(Top*)的视频(时间排序)
        /// </summary>
        /// <param name="type">视频类型</param>
        /// <returns></returns>
        public DataTable SelectVideoByNewTop(string type)
        {
            DataTable dt = new DataTable();
            string cmdText = "select top 4 * from videoInfo where videoType =@type and Auditing='1' order by videoDate desc";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@type",type)
            };
            dt = sqlhelper.getRow(cmdText, paras, CommandType.Text);
            return dt;
        }

        public DataTable SelectVideoByNewTop8(string type)
        {
            DataTable dt = new DataTable();
            string cmdText = "select top 8 * from videoInfo where videoType =@type and Auditing='1' order by videoDate desc";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@type",type)
            };
            dt = sqlhelper.getRow(cmdText, paras, CommandType.Text);
            return dt;
        }


        /// <summary>
        /// 最新人气(Top*)的视频(播放次数排序)
        /// </summary>
        /// <param name="type">视频类型</param>
        /// <returns></returns>
        public DataTable SelectVideoByPlaySumTop(string type)
        {
            DataTable dt = new DataTable();
            string cmdText = "select top 4 * from videoInfo where videoType =@type and Auditing='1' order by playSum desc";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@type",type)
            };
            dt = sqlhelper.getRow(cmdText, paras, CommandType.Text);
            return dt;
        }

        public DataTable SelectVideoByPlaySumTop8(string type)
        {
            DataTable dt = new DataTable();
            string cmdText = "select top 8 * from videoInfo where videoType =@type and Auditing='1' order by playSum desc";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@type",type)
            };
            dt = sqlhelper.getRow(cmdText, paras, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// 按类型查找视频(时间排序)
        /// </summary>
        /// <param name="type">视频类型</param>
        /// <returns></returns>
        public DataTable SelectVideoByNew(string type)
        {
            DataTable dt = new DataTable();
            string cmdText = "select * from videoInfo where videoType =@type and Auditing='1' order by videoDate desc";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@type",type)
            };
            dt = sqlhelper.getRow(cmdText, paras, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// 按类型查找视频(播放次数排序)
        /// </summary>
        /// <param name="type">视频类型</param>
        /// <returns></returns>
        public DataTable SelectVideoByPlaySum(string type)
        {
            DataTable dt = new DataTable();
            string cmdText = "select * from videoInfo where videoType =@type and Auditing='1' order by playSum desc";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@type",type)
            };
            dt = sqlhelper.getRow(cmdText, paras, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// 点播TOP10排行榜
        /// </summary>
        /// <returns></returns>
        public DataTable getClickTop()
        {
            DataTable dt = new DataTable();
            string cmdText = "select top 5 *  from videoInfo where Auditing ='1' order by playSum desc";
            dt = sqlhelper.getRow(cmdText, CommandType.Text);
            return dt;
        }


        #endregion

        #region 视频播放页面数据访问方法

        /// <summary>
        /// 返回视频信息
        /// </summary>
        /// <param name="id">视频编号</param>
        /// <returns></returns>
        public DataTable getVideoInfo(string id)
        {
            VideoInfoModel videoInfoModel = new VideoInfoModel();
            DataTable dt = new DataTable();
            string cmdText = "select * from videoInfo where id=@id";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter ("@id", id)
            };
            dt = sqlhelper.getRow(cmdText, paras, CommandType.Text);
            return dt;
        }


        /// <summary>
        /// 验证该IP地址是否已经评价该ID视频
        /// </summary>
        /// <param name="ip">客户端IP</param>
        /// <param name="id">视频编号</param>
        /// <returns></returns>
        public DataTable checkPoll(string ip, string id)
        {
            DataTable dt = new DataTable();
            string cmdText = "select * from videoPoll where ip=@ip and videoId=@id ";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@ip",ip),
                new SqlParameter("@id",id)
            };
            dt = sqlhelper.getRow(cmdText, paras, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// 新增该IP该ID视频到服务器
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool addPoll(string ip, string id)
        {
            bool flag = false;
            string cmdText = "insert into videoPoll(ip,videoId) values(@ip,@id)";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@ip",ip),
                new SqlParameter("@id",id)
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }


        /// <summary>
        /// 播放次数更新
        /// </summary>
        /// <param name="id">视频编号</param>
        /// <returns></returns>
        public bool addPlaySum(string id)
        {
            bool flag = false;
            string cmdText = "update videoInfo set playSum=playSum+1 where Id=@id";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }


        /// <summary>
        /// 评论信息插入
        /// </summary>
        /// <param name="videa">评论信息实体参数</param>
        /// <returns></returns>
        public bool commentInsert(VideoIdeaModel vIdea)
        {
            bool flag = false;
            string cmdText = "insert videoIdea(userName,ip,contents,videoId) values(@username,@ip,@contents,@id)";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@username",vIdea.userName),
                new SqlParameter("@ip",vIdea.Ip),
                new SqlParameter("@contents",vIdea.Contents),
                new SqlParameter("@id",vIdea.Id)           
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }

        #endregion

        #region 视频搜索页面数据访问方法
        /// <summary>
        /// 按照关键字、类型查找视频（上传时间排序）
        /// </summary>
        /// <param name="type">视频类型</param>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        public DataTable SelectVideoWithKeyNew(string type, string key)
        {
            DataTable dt = new DataTable();
            string cmdText = "select * from videoInfo where Auditing ='1' and videoType=@type and ( videoTitle like '%" + key + "%' or userName like '%" + key + "%' or videoContent like '%" + key + "%' ) order by videoDate desc ";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@type",type)
            };
            dt = sqlhelper.getRow(cmdText, paras, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// 按关键字查找视频
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        public DataTable SelectVideoByKey(string key)
        {
            DataTable dt = new DataTable();
            string cmdText = "select * from videoInfo where Auditing ='1'  and ( videoTitle like '%" + key + "%' or userName like '%" + key + "%' or videoContent like '%" + key + "%' ) order by videoDate desc ";
            dt = sqlhelper.getRow(cmdText, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// 按照关键字、类型查找视频（播放次数排序）
        /// </summary>
        /// <param name="type">视频类型</param>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        public DataTable SelectVideoWithKeyPlaySum(string type, string key)
        {
            DataTable dt = new DataTable();
            string cmdText = "select * from videoInfo where Auditing ='1' and videoType=@type and (videoTitle like '%" + key + "%' or userName like '%" + key + "%' or videoContent like '%" + key + "%')  order by playSum desc ";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@type",type),
                //new SqlParameter("@key",key)
            };
            dt = sqlhelper.getRow(cmdText, paras, CommandType.Text);
            return dt;
        }

        #endregion

        #region 视频排行页面数据访问方法
        #endregion

        #region 视频审核、管理页面数据访问方法
        /// <summary>
        /// 未通过审核的视频
        /// </summary>
        /// <returns></returns>
        public DataTable SelectVideoNotAuditing()
        {
            DataTable dt = new DataTable();
            string cmdText = "select * from videoInfo where Auditing ='0' order by videoDate desc ";
            dt = sqlhelper.getRow(cmdText, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// 获取所有通过审核的视频
        /// </summary>
        /// <returns></returns>
        public DataTable getVideoAll()
        {
            DataTable dt = new DataTable();
            string cmdText = "select * from videoInfo where Auditing ='1' ";
            dt = sqlhelper.getRow(cmdText, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// 视频通过审核
        /// </summary>
        /// <returns></returns>
        public bool VideoPass(string id)
        {
            bool flag = false;
            string cmdText = "update videoInfo set Auditing='1' where Id=@id";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            int res = sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 删除视频
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool VideoDelete(string id)
        {
            bool flag = false;
            string cmdText = "delete from videoInfo where Id=@id";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@id",id)
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
