using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QrMgr
{
    public partial class QrRedirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = Request.QueryString["url"];
            //url = HttpUtility.UrlDecode(url);
            if (url != null)
            {
                QrCode tmp = new QrCode();
                string uploadid = tmp.select_id_url(url);
               
                Uploadclass tmp1 = new Uploadclass();
             
                if (uploadid == "")
                {
                    Response.Write("<script>alert('QRcode未关联')</script>");

                }
                else
                {
                    int isEnable = tmp1.getEnable(Int32.Parse(uploadid));
                    string type = tmp1.getTypebyId(Int32.Parse(uploadid));
                    if (isEnable == 0) {
                        Response.Write("<script>alert('资源已被禁用')</script>资源已被禁用");
                    }
                    else
                    {
                        if (type == "")
                            Response.Write("<script>alert('出错了')</script>");
                        else
                        {
                          //  Server.Transfer(System.Configuration.ConfigurationManager.AppSettings["baseurl"] + "view" + type + ".aspx?uploadid=" + uploadid);
                            Session["id"] = uploadid;
                            Server.Transfer("view" + type + ".aspx");
                        }
                    }
                    }
            }
        }
    }
}