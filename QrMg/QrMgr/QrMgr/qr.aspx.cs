using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
namespace QrMgr
{
    public partial class qr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Loggedin"] == null || !Session["Loggedin"].Equals("1"))
            {
                Response.Redirect("login.aspx");
                return;
            }
            if (Request.QueryString["action"] == "add")
            {
                MultiView1.ActiveViewIndex = 0;
            }else
            MultiView1.ActiveViewIndex = 1;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string url=TextBox1.Text;
            url = HttpUtility.UrlEncode(url);
            DataClasses1DataContext db = new DataClasses1DataContext();
            var result = from q in db.qrcode where q.Url == url select q;
            int result_no = result.Count();
            if (result_no != 0)
            {
                Label_boot.Text = "<div width=\"400px\"   class=\"alert alert-warning  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>该地址已被占用</strong></div>";
            }
            else {
                qrcode new_qr = new qrcode();
                if (url.Trim() == "") {
                    string url_generated = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                    url_generated = url_generated.Replace("+", "");
                    url_generated = url_generated.Replace("/", "");
                    url = url_generated;
                }
                new_qr.Url = url;
                new_qr.生成时间 = DateTime.Now;
                new_qr.uploadId = null;
                new_qr.备注 = TextBox2.Text;
                db.qrcode.InsertOnSubmit(new_qr);
                try
                {
                    db.SubmitChanges();
                    Label_boot.Text = "<div width=\"400px\"   class=\"alert alert-success  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>成功</strong></div>";
                }
                catch (Exception err) {
                    Label_boot.Text = "<div width=\"400px\"   class=\"alert alert-warning  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>"+err.Message+"</strong></div>";
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                String isEnable = e.Row.Cells[3].Text.Trim();
                if (isEnable=="&nbsp;")
                {
                    e.Row.Cells[3].Text = "未关联";
                }
                
                
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex == -1 || GridView2.SelectedIndex == -1)
            {
                Label_boot_edit.Text = "<div width=\"400px\"   class=\"alert alert-warning  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>关联前先选中对应的资源和二维码</strong></div>";
            }
            else
            {
                int selected_qr_id = int.Parse(GridView1.SelectedRow.Cells[5].Text);
                int selected_upload_id = int.Parse(GridView2.SelectedRow.Cells[2].Text);
                DataClasses1DataContext db = new DataClasses1DataContext();
                var result=from q in db.qrcode where q.qrId==selected_qr_id select q;
                qrcode result_out = result.First();
                result_out.uploadId = selected_upload_id;
                try {
                    db.SubmitChanges();

                    Label_boot_edit.Text = "<div width=\"400px\"   class=\"alert alert-success  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>成功</strong></div>";
                  //  GridView1.DataSource = SqlDataSource1;
                    GridView1.DataBind();
                }catch(Exception err){
                    Label_boot_edit.Text = "<div width=\"400px\"   class=\"alert alert-warning  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>"+err.Message+"</strong></div>";
                }
            }

        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {

                e.Row.Cells[5].Visible = false;

            }     
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex == -1)
            {
                Label_boot_edit.Text = "<div width=\"400px\"   class=\"alert alert-warning  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>解除关联前先选中对应二维码</strong></div>";

            }
            else {
                int selected_qr_id = int.Parse(GridView1.SelectedRow.Cells[5].Text);
                DataClasses1DataContext db = new DataClasses1DataContext();
                var result = from q in db.qrcode where q.qrId == selected_qr_id select q;
                qrcode result_out = result.First();
                result_out.uploadId = null;
                try
                {
                    db.SubmitChanges();
                    Label_boot_edit.Text = "<div width=\"400px\"   class=\"alert alert-success  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>成功</strong></div>";
                }
                catch (Exception err){
                    Label_boot_edit.Text = "<div width=\"400px\"   class=\"alert alert-warning  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>" + err.Message + "</strong></div>";
                }
                //GridView1.DataSource = SqlDataSource1;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (GridView1.Rows[e.RowIndex].Cells[3].Text != "未关联") {
                Label_boot_edit.Text = "<div width=\"400px\"   class=\"alert alert-warning  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>无法删除已关联资源的二维码</strong></div>";
                e.Cancel = true;
            }
        }
    }
}