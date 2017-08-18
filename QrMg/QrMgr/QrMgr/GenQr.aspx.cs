using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThoughtWorks.QRCode.Codec;

namespace QrMgr
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static string GetLocalIP()
        {
            
                string HostName = Dns.GetHostName(); //得到主机名  
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    //从IP地址列表中筛选出IPv4类型的IP地址  
                    //AddressFamily.InterNetwork表示此IP为IPv4,  
                    //AddressFamily.InterNetworkV6表示此地址为IPv6类型  
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        return IpEntry.AddressList[i].ToString();
                    }
                }
                return "";
           
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string url = Request.QueryString["url"];
           // url = HttpUtility.UrlEncode(url);
          //  Response.Write(url);
            //string baseurl = System.Configuration.ConfigurationManager.AppSettings["baseurl"];
            url = "http://" + GetLocalIP() + "/QrRedirect.aspx?url=" + url;
            Bitmap bt;
            String logoPath=Server.MapPath("~/"+"logo.jpg");
            QRCodeEncoder qrcodeencoder = new QRCodeEncoder();
              qrcodeencoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            if (url != null)
            {
                DateTime dt;
                if (DateTime.TryParse(Request.Headers["If-Modified-Since"], out dt))
                {
                    // 注意：如果是20秒内，我就以304的方式响应。
                    if ((DateTime.Now - dt).TotalSeconds < 3600.0)
                    {
                        Response.StatusCode = 304;
                        Response.End();
                        return;
                    }
                }
                bt = qrcodeencoder.Encode(url, System.Text.Encoding.UTF8);
                Graphics g = Graphics.FromImage(bt);
                Bitmap bitmapLogo = new Bitmap(logoPath);
                int logoSize = 55;
                bitmapLogo = new Bitmap(bitmapLogo, new System.Drawing.Size(logoSize, logoSize));
                PointF point = new PointF(bt.Width / 2 - logoSize / 2, bt.Height / 2 - logoSize / 2);
                g.DrawImage(bitmapLogo, point);
                // string path = Server.MapPath("~/image/") + filename + ".jpg";
                //Response.Write(path);
                // bt.Save(path);
                // this.Image1.ImageUrl = "~/image/" + filename + ".jpg";

                bt.Save(Response.OutputStream, ImageFormat.Jpeg);
                Response.ContentType = "image/jpeg";
               

                // 注意这个调用，它可以产生"Last-Modified"这个响应头，浏览器在收到这个头以后，
                // 在后续对这个页面访问时，就会将时间以"If-Modified-Since"的形式发到服务器
                // 这样，上面代码的判断就能生效。
                Response.Cache.SetLastModified(DateTime.Now);
                Response.Flush();
            }
        }
    }
}