using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using TeWebVideo.DAL;
using TeWebVideo.MODEL;

namespace TeWebVideo.BLL
{
    public class VideoBLL
    {
        private VideoDAL videodal;
        DataTable dt = new DataTable();
        public VideoBLL()
        {
            videodal = new VideoDAL();
        }

        #region 视频播放页面业务逻辑
        //视频信息
        public VideoInfoModel getVideoInfo(string id)
        {
            VideoInfoModel videoInfoModel = new VideoInfoModel();
            dt = videodal.getVideoInfo(id);
            videoInfoModel.Id = dt.DefaultView[0]["id"].ToString();
            videoInfoModel.userName = dt.DefaultView[0]["userName"].ToString();
            videoInfoModel.videoTitle = dt.DefaultView[0]["videoTitle"].ToString();
            videoInfoModel.videoPath = dt.DefaultView[0]["videoPath"].ToString();
            videoInfoModel.videoContent = dt.DefaultView[0]["videoContent"].ToString();
            videoInfoModel.videoDate = dt.DefaultView[0]["videoDate"].ToString();
            videoInfoModel.videoPicture = dt.DefaultView[0]["videoPicture"].ToString();
            videoInfoModel.Flower = int.Parse(dt.DefaultView[0]["Flower"].ToString());
            videoInfoModel.Tile = int.Parse(dt.DefaultView[0]["Tile"].ToString());
            videoInfoModel.playSum = int.Parse(dt.DefaultView[0]["playSum"].ToString());
            videoInfoModel.Auditing = dt.DefaultView[0]["Auditing"].ToString();
            return videoInfoModel;
        }

        //增加鲜花
        public bool addFlower(string id)
        {
            return videodal.updateFlower(id);
        }

        //增加拍砖
        public bool addTile(string id)
        {
            return videodal.updateTile(id);
        }

        //获取评论内容
        public DataTable getVideoIdea(string id)
        {
            return videodal.getVideoIdea(id);
        }

        //增加评论
        public bool addComment(VideoIdeaModel videa)
        {
            return videodal.commentInsert(videa);
        }

        //添加该ID中的IP到服务器
        public bool addPoll(string ip, string id)
        {
            return videodal.addPoll(ip, id);
        }

        //获取该IP是否评价该ID视频
        public bool isExistPoll(string ip, string id)
        {
            bool flag = false;
            if (videodal.checkPoll(ip, id).Rows.Count > 0)
            {
                flag = true;
            }
            return flag;
        }

        //播放次数增加1次
        public bool addPlaySum(string id)
        {
            return videodal.addPlaySum(id);
        }

        #endregion

        #region 视频搜索页面业务逻辑
        //获取点击排行榜
        public DataTable getClickTop() 
        {
            return videodal.getClickTop();
        }
        #endregion

        #region 网站首页面业务逻辑

        //返回最新上传Top视频信息
        public DataTable getVideoList(string type)
        {
            dt = videodal.SelectVideoByNewTop(type);
            return dt;
        }

        #endregion

        #region 视频排行榜页面业务逻辑

        #endregion

        #region 视频浏览、管理页面业务逻辑

        //获取最新的8个视频
        public DataTable getNewTop8(string type)
        {
            dt = videodal.SelectVideoByNewTop8(type);
            return dt;
        }

        //获取播放最多的8个视频
        public DataTable getPlaySumTop8(string type)
        {
            dt = videodal.SelectVideoByPlaySumTop8(type);
            return dt;
        }

        //获取视频列表
        public DataTable getVideoList(string type, string ideal, string key)
        {
            if (type == null)
            {
                if (key != string.Empty || key != null)
                {
                    dt = videodal.SelectVideoByKey(key);
                }
                else
                {
                    dt = videodal.getVideoAll();
                }
            }
            else
            {
                if (ideal == "0" || ideal == "2")
                {
                    if (key == string.Empty || key == null)
                    {
                        dt = videodal.SelectVideoByNew(type);
                    }
                    else
                    {
                        dt = videodal.SelectVideoWithKeyNew(type, key);
                    }
                }
                else if (ideal == "1")
                {
                    if (key == string.Empty || key == null)
                    {
                        dt = videodal.SelectVideoByPlaySum(type);
                    }
                    else
                    {
                        dt = videodal.SelectVideoWithKeyPlaySum(type, key);
                    }
                }
                else
                {
                    if (type == "auditing")
                    {
                        dt = videodal.SelectVideoNotAuditing();
                    }
                }
            }
            return dt;
        }

        //视频通过审核
        public bool videoPass(string id)
        {
            return videodal.VideoPass(id);
        }

        //视频删除
        public bool videoDelete(string id)
        {
            return videodal.VideoDelete(id);
        }
        #endregion
    }
}
