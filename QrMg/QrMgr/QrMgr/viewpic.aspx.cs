using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QrMgr
{
    public partial class viewpic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // int uploadid = Int32.Parse( Request.QueryString["uploadid"]);
            int uploadid = int.Parse(Session["id"].ToString());
            string type = "";
            Uploadclass tmp = new Uploadclass();
            string path=tmp.getPathbyId(uploadid);
            type = tmp.getTypebyId(uploadid);
            if (type == "pic")
            {
                string pic_path = ResolveUrl("~/upload/"+path);
                Image1.ImageUrl = pic_path;
            }
            else
                Response.Redirect("Error.aspx");
        }
    }
}