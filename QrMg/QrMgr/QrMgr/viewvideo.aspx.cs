using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QrMgr
{
    public partial class viewvideo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //int uploadid = Int32.Parse(Request.QueryString["uploadid"]);
            int uploadid = int.Parse(Session["id"].ToString());
            string type = "";
            Uploadclass tmp = new Uploadclass();
            string path = tmp.getPathbyId(uploadid);
            type = tmp.getTypebyId(uploadid);
            if (type == "video")
            {
                string video_path = ResolveUrl("~/upload/" + path);
               // Application["video_path"] = video_path;
                Session["video_path"] = video_path;
                
            }
            else
                Response.Redirect("Error.aspx");
        }
        public string geturl() {
            return Session["video_path"].ToString() ;
        }
    }
}