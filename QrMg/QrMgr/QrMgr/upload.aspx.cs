using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QrMgr
{
    public partial class upload1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Loggedin"] == null || !Session["Loggedin"].Equals("1"))
            {
                Response.Redirect("login.aspx");
                return;
            }
            if (Request.QueryString["action"] == "add")
                MultiView1.ActiveViewIndex = 0;
            else
                MultiView1.ActiveViewIndex = 1;

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue.ToString().Equals("html"))
            {

                FileUpload1.Visible = false;
                CKEditor1.Visible = true;
                Label2.Text = "编辑网页";
            }
            else {
                FileUpload1.Visible = true;
                CKEditor1.Visible = false;
                Label2.Text = "选择文件";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            uploadlinq new_upload = new uploadlinq();
            if (DropDownList1.SelectedValue.ToString().Equals("pic")) {
                new_upload.类型 = "pic";
            }
            if (DropDownList1.SelectedValue.ToString().Equals("video"))
            {
                new_upload.类型 = "video";
            }
            if (DropDownList1.SelectedValue.ToString().Equals("html")) {
                new_upload.类型 = "html";
            }
            string path = Server.MapPath("~/upload/");
            new_upload.是否启用 = 1;
            new_upload.上传时间 = DateTime.Now;
            if (new_upload.类型 == "html") {
                new_upload.路径 = CKEditor1.Text;
                new_upload.备注 = TextBox1.Text;
                try
                {
                    db.uploadlinq.InsertOnSubmit(new_upload);
                    db.SubmitChanges();
                }
                catch (Exception err) {
                    Response.Write("<script>alert('" + "保存出错" + err.Message.ToString() + "')</script>");
                    return;
                }
                Label4.Text = "<div width=\"400px\"   class=\"alert alert-success  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>成功！</strong></div>";
               // Response.Write("<div class=\"alert alert-warning\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times; </a> <strong>警告！</strong>您的网络连接有问题。</div>");
            }
            if (FileUpload1.HasFile&&new_upload.类型!="html")
            {
                if (System.IO.Path.GetExtension(FileUpload1.FileName).ToLower() == "aspx") {
                    Response.Write("<script>alert('文件非法')</script>");
                }
                else{
                    try
                    {
                        string filename=Guid.NewGuid().ToString()+ System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                        string savepath=path + filename;
                       FileUpload1.SaveAs(savepath);
                       // Uploadclass tmp = new Uploadclass();
                        //if (tmp.AddUpload(type, filename, TextBox_comment.Text) == 1) {
                           // Response.Write("<script>alert('成功')</script>");
                          //  FileUpload1.SaveAs(savepath);
                          //  Response.Redirect("Uploader.aspx");
                           // Response.Write("<script>alert('成功')</script>");
                        //}
                        new_upload.路径=filename;
                        new_upload.备注=TextBox1.Text;
                        db.uploadlinq.InsertOnSubmit(new_upload);
                        db.SubmitChanges();
                        
                           


                       // Response.Write(savepath+"");
                       // Response.Write(ResolveUrl("~/upload/f9ff34c2-89ea-45dd-b284-e052d4cdc716.PNG"));
                    }
                    catch (Exception e1) {
                        Response.Write("<script>alert('"+"保存出错" + e1.Message.ToString()+"')</script>");
                    }

                
                }
            }
            else if(FileUpload1.HasFile==false&&new_upload.类型!="html")
                Response.Write("<script>alert('您还没有选择文件')</script>");
            }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                String isEnable = e.Row.Cells[6].Text.Trim();
                if (isEnable.Equals("1")) {
                    e.Row.Cells[6].Text = "启用";
                }
                else if (isEnable.Equals("0")) {
                    e.Row.Cells[6].Text = "禁用";
                }
                String type = e.Row.Cells[3].Text.Trim();
                if (type.Equals("html")) {
                    e.Row.Cells[4].Text = "HTML网页代码";
                }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int id=0;
            try
            {
                 id = int.Parse(GridView1.SelectedDataKey[0].ToString());
            }
            catch{
                Response.Write("<script>alert('ID不合法')</script>");
                return;
            }
            DataClasses1DataContext db = new DataClasses1DataContext();
            var result=from q in db.uploadlinq where q.uploadId==id select q;
            uploadlinq resultout=result.First();
            resultout.是否启用=0;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception err) {
                Response.Write("<script>alert('" + err.Message + "')</script>");
                return;
            }
            Response.Write("<script>alert('成功')</script>");
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                id = int.Parse(GridView1.SelectedDataKey[0].ToString());
            }
            catch
            {
                Response.Write("<script>alert('ID不合法')</script>");
                return;
            }
            DataClasses1DataContext db = new DataClasses1DataContext();
            var result = from q in db.uploadlinq where q.uploadId == id select q;
            uploadlinq resultout = result.First();
            resultout.是否启用 = 1;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception err)
            {
                Response.Write("<script>alert('" + err.Message + "')</script>");
                return;
            }
            //Response.Write("<div class=\"alert alert-warning\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times; </a> <strong>警告！</strong>您的网络连接有问题。</div>");
            //Response.Write("<script>alert('成功')</script>");
            Label_boot.Text = "<div width=\"400px\"   class=\"alert alert-success  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>成功！</strong></div>";
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string uploadidstr=GridView1.Rows[e.RowIndex].Cells[2].Text;
            DataClasses1DataContext db = new DataClasses1DataContext();
            var result = from q in db.qrcode where q.uploadId == Int32.Parse(uploadidstr) select q;
            int count = result.Count();
            if (count > 0) {
                e.Cancel = true;
                Label_boot.Text = "<div width=\"400px\"   class=\"alert alert-warning  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>无法删除已关联二维码的资源</strong></div>";
            }

        }
        }
    
}