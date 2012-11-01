using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Drawing2D;

public partial class CreateCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string tmp = RndNum(5);
        HttpCookie a = new HttpCookie("ImageV", tmp);
        Response.Cookies.Add(a);
        this.ValidateCode(tmp);
    }

    private void ValidateCode(string VNum)
    {
        Bitmap image = new Bitmap((int)Math.Ceiling(VNum.Length * 15.5), 20);
        Graphics g = Graphics.FromImage(image);
        try
        {
            //生成随机生成器
            Random random = new Random();
            //清空图片背景色
            g.Clear(Color.WhiteSmoke);
            //画图片的干扰线
            for (int i = 0; i < 10; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);
                g.DrawLine(new Pen(Color.LightBlue), x1, y1, x2, y2);
            }
            for (int i = 0; i < VNum.Length; i++)
            {
                Font font = new Font("Arial", 14, FontStyle.Bold);
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.DarkBlue, Color.Orchid, 2.5f, true);
                g.DrawString(VNum.Substring(i, 1), font, brush, 2 + i * 14, 1);
            }
            //画图片的前景干扰点
            for (int i = 0; i < 230; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);
                image.SetPixel(x, y, Color.FromArgb(random.Next()));
            }
            //画图片的边框线
            g.DrawRectangle(new Pen(Color.Gray), 0, 0, image.Width - 1, image.Height - 1);
            //保存图片数据
            MemoryStream stream = new MemoryStream();
            image.Save(stream, ImageFormat.Gif);
            //输出图片
            Response.Clear();
            Response.ContentType = "image/GIF";
            Response.BinaryWrite(stream.ToArray());
        }
        finally
        {
            g.Dispose();
            image.Dispose();
        }
    }

    private string RndNum(int VcodeNum)
    {
        string Vchar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
        string[] VcArray = Vchar.Split(new Char[] { ',' });
        string VNum = "";
        int temp = -1;

        Random rand = new Random();

        for (int i = 1; i < VcodeNum + 1; i++)
        {
            if (temp != -1)
            {
                rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
            }
            int t = rand.Next(62);
            if (temp != -1 && temp == t)
            {
                return RndNum(VcodeNum);
            }
            temp = t;
            VNum += VcArray[t];
        }
        return VNum;
    }
}
