using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;
using System.IO;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;
using System.Drawing.Imaging;
using ICSharpCode.SharpZipLib.Core;
using System.Collections;
using System.Text;
namespace QrMgr
{
    public partial class getzip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            // ?url=aaaa====|svvvvv;
            MemoryStream ms = new MemoryStream();
            ZipOutputStream s = new ZipOutputStream(ms);
            s.SetLevel(0);
            String url;
            Crc32 crc = new Crc32();
           // String request_url = Request.QueryString["url"];
            //String request_filename = Request.QueryString["filename"];
            String zipcommand = Session["zipcommand"].ToString();
            if (zipcommand != null && zipcommand != "") {
                ArrayList arr = new ArrayList();
                arr = SerializeObj.Desrialize(arr, zipcommand);

                foreach (zipcommand a in arr)
                {
                    string baseurl = System.Configuration.ConfigurationManager.AppSettings["baseurl"];
                    url = baseurl + "QrRedirect.aspx?url=" + a.url;

         
                    Bitmap bt;
                    String logoPath = Server.MapPath("~/" + "logo.jpg");
                    QRCodeEncoder qrcodeencoder = new QRCodeEncoder();
                    qrcodeencoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                    if (a.url != null)
                    {
                        MemoryStream temp = new MemoryStream();
                        bt = qrcodeencoder.Encode(url, System.Text.Encoding.UTF8);
                        Graphics g = Graphics.FromImage(bt);
                        Bitmap bitmapLogo = new Bitmap(logoPath);
                        int logoSize = 55;
                        bitmapLogo = new Bitmap(bitmapLogo, new System.Drawing.Size(logoSize, logoSize));
                        PointF point = new PointF(bt.Width / 2 - logoSize / 2, bt.Height / 2 - logoSize / 2);
                        g.DrawImage(bitmapLogo, point);
                        bt.Save(temp,ImageFormat.Jpeg);
                        ZipEntry entry=new ZipEntry(a.isbn+"-"+a.pos+"-"+a.seq+"-"+".jpg");
                        
                        entry.DateTime=DateTime.Now;
                       entry.Size = temp.Length;
                        s.PutNextEntry(entry);
                        byte[] buffer = new byte[temp.Length];
                      //  temp.Write(buffer, 0, buffer.Length);
                        buffer = temp.ToArray();
                        s.Write(buffer, 0, buffer.Length);

                       //StreamUtils.Copy(temp,s,new byte[4096]);
                       
                        //byte[] buffer = new byte[temp.Length];
                        //temp.Write(buffer, 0, buffer.Length);
                        //temp.Close();
                        //crc.Reset();
                        //crc.Update(buffer);
                        //entry.Crc = crc.Value;
                        //s.PutNextEntry(entry);
                        //s.Write(buffer, 0, buffer.Length);
                        // string path = Server.MapPath("~/image/") + filename + ".jpg";
                        //Response.Write(path);
                        // bt.Save(path);
                        // this.Image1.ImageUrl = "~/image/" + filename + ".jpg";

                       // bt.Save(Response.OutputStream, ImageFormat.Jpeg);
                      //  Response.ContentType = "image/jpeg";


                        // 注意这个调用，它可以产生"Last-Modified"这个响应头，浏览器在收到这个头以后，
                        // 在后续对这个页面访问时，就会将时间以"If-Modified-Since"的形式发到服务器
                        // 这样，上面代码的判断就能生效。
                       // Response.Cache.SetLastModified(DateTime.Now);
                       // Response.Flush();
                      //  bt.Save()
                      //  ms.Read()
                    }
                }
                //s.CloseEntry();
                //s.Close();
               s.Finish();
                s.Close();
                ms.Close();
                string ss = "download" + DateTime.Now.ToString() ;
               HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode (ss,Encoding.UTF8) + ".zip");
               // Reheaders.add("Content-disposition", "attachment;filename=" + URLEncoder.encode(ss, "UTF-8") + ".zip;filename*=UTF-8''" + URLEncoder.encode("中国", "UTF-8") + ".txt");
                HttpContext.Current.Response.BinaryWrite(ms.ToArray());
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
            else {
                Response.Write("参数错误");
            }

        }
    }
}