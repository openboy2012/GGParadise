using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using TeWebVideo.BLL;
using TeWebVideo.MODEL;
/// <summary>
///WebService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    UserBLL userbll = new UserBLL();
    public WebService()
    {
        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public AjaxClass CheckUid(string uid)
    {
        AjaxClass ajaxClass = new AjaxClass();
        try
        {
            if (uid.Length < 8 || uid.Length > 20)
            {
                ajaxClass.Msg = "用户名长度为8-12个字符";
                ajaxClass.Result = 0;
            }
            else if (userbll.checkUser(uid))
            {
                ajaxClass.Msg = "该用户名已经被注册";
                ajaxClass.Result = 0;
            }
            else
            {
                ajaxClass.Msg = "格式正确";
                ajaxClass.Result = 1;
            }
        }
        catch
        {
            ajaxClass.Msg = "程序出现异常,请联系管理员";
            ajaxClass.Result = 0;
        }
        return ajaxClass;
    }
}

