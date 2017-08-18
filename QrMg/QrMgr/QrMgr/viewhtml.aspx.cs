using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QrMgr
{
    public partial class viewhtml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int uploadidinput = int.Parse(Session["id"].ToString());
            DataClasses1DataContext db = new DataClasses1DataContext();
            var result=from q in db.uploadlinq where q.uploadId ==uploadidinput select q;
            uploadlinq uploadlinqout=new uploadlinq();
            uploadlinqout=result.First();
            Label1.Text = uploadlinqout.路径;

        }
    }
}