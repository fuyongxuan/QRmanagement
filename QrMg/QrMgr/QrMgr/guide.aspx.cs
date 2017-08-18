using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QrMgr
{
    public partial class guide : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Loggedin"] == null || !Session["Loggedin"].Equals("1"))
            {
                Response.Redirect("login.aspx");
                return;
            }
            MultiView3.ActiveViewIndex = 0;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == 0) {
               
                MultiView1.ActiveViewIndex = 0;
            }
            else if (RadioButtonList1.SelectedIndex == 1) {
                MultiView1.ActiveViewIndex = 1;
            }
        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == 0)
            {
                //string filename = "";
                //string path = "";
                //string savepath = "";
                //if (FileUpload2.HasFile == false)
                //{
                //    Response.Write("<script>alert('您还没有选择封面图片')</script>");
                //    return;
                //}
               
                //else
                //{
                //    path = Server.MapPath("~/upload/");
                //    filename = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                //    savepath = path + filename;

                //}
                String Book_coverpath = null;
                if (Session["filename"] != null)
                {
                    String path = Server.MapPath("~/upload/");
                    //String Book_coverpath = Session["filename"].ToString();
                    String filename = Session["filename"].ToString();
                    String newfilename =  Guid.NewGuid().ToString() + Session["extension"].ToString();
                    System.IO.File.Move(path + filename, path + newfilename);
                    Book_coverpath=newfilename;
                }
                
                String Book_name = TextBox_title.Text;
                String Book_ISBN = TextBox_isbn.Text;
                String Book_Author = TextBox_author.Text;
                String Book_brief = TextBox_brief.Text;
                DateTime Book_Date = Calendar1.SelectedDate.Date;
                DataClasses1DataContext db = new DataClasses1DataContext();
                book newBook = new book();
                newBook.Book_Author = Book_Author;
                newBook.Book_ISBN = Book_ISBN;
                newBook.Book_Title = Book_name;
                newBook.Book_Date = Book_Date;
                newBook.Book_Brief = Book_brief;
                newBook.Book_addDate = DateTime.Now;
                newBook.Book_coverpath = Book_coverpath;
                db.book.InsertOnSubmit(newBook);
                try
                {
                    db.SubmitChanges();
                //    FileUpload2.SaveAs(savepath);
                }
                catch (Exception a)
                {
                    Response.Write("<script>alert('" + a.Message + "')</script>");
                }
            }
            if (RadioButtonList2.SelectedIndex == 0) {
                String Book_ISBN="";
                if (RadioButtonList1.SelectedIndex == 0)
                 Book_ISBN = TextBox_isbn.Text;
                if (RadioButtonList1.SelectedIndex == 1)
                     Book_ISBN =DropDownList1.SelectedValue.ToString();
                String pos = TextBox2.Text;
                int seq_tmp = 0;
                DataClasses1DataContext db = new DataClasses1DataContext();
                position a = new position();
                a.Book_ISBN = Book_ISBN;
                a.Pos = pos;
                if (TextBox3.Text != "")
                {
                    a.name = TextBox3.Text;
                }
                else
                    a.name = "";
                var result = from tmp in db.position where tmp.Book_ISBN == Book_ISBN where tmp.Pos == pos select tmp;
                if (result == null)
                {
                    a.seq = 0;
                }
                else
                {
                    foreach (var item in result)
                    {
                        if (item.seq > seq_tmp)
                        {
                            seq_tmp = (int)item.seq;
                        }

                    }
                    seq_tmp++;
                    a.seq = seq_tmp;
                }
                var qridresult=from q in db.qrcode where q.Url==Session["url"] select q;
                qrcode qrresultout=qridresult.First();
                a.qrid = qrresultout.qrId;
                db.position.InsertOnSubmit(a);
                try
                {
                    db.SubmitChanges();
                }
                catch (Exception err)
                {
                    Response.Write("<script>alert('" + err.Message + "')</script>");
                }

            }
            if (RadioButtonList2.SelectedIndex == 1) {
                String Book_ISBN = DropDownList1.SelectedValue.ToString();
                String pos = TextBox2.Text;
                int seq_tmp = 0;
                DataClasses1DataContext db = new DataClasses1DataContext();
                position a = new position();
                a.Book_ISBN = Book_ISBN;
                a.Pos = pos;
                var result = from tmp in db.position where tmp.Book_ISBN == Book_ISBN where tmp.Pos == pos select tmp;
                if (result == null)
                {
                    a.seq = 0;
                }
                else
                {
                    foreach (var item in result)
                    {
                        if (item.seq > seq_tmp)
                        {
                            seq_tmp = (int)item.seq;
                        }

                    }
                    seq_tmp++;
                    a.seq = seq_tmp;
                }
                var qridresult = from q in db.qrcode where q.Url == Session["url"] select q;
                qrcode qrresultout = qridresult.First();
                a.qrid = qrresultout.qrId;
                db.position.InsertOnSubmit(a);
                try
                {
                    db.SubmitChanges();
                }
                catch (Exception err)
                {
                    Response.Write("<script>alert('" + err.Message + "')</script>");
                }
            }
           
        }

        protected void Wizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            if (e.CurrentStepIndex == 0)
            {
                #region
                if (TextBox_isbn.Text == "" && RadioButtonList1.SelectedIndex == 0)
                {
                    e.Cancel = true;
                    Response.Write("<script>alert('isbn不能为空')</script>");
                }
                if (Calendar1.SelectedDate.Date == DateTime.MinValue && RadioButtonList1.SelectedIndex == 0)
                {
                    e.Cancel = true;
                    Response.Write("<script>alert('请选择日期')</script>");
                    return;
                }
                if (TextBox_isbn.Text != "" && RadioButtonList1.SelectedIndex == 0)
                {
                    String Book_name = TextBox_title.Text;
                    String Book_ISBN = TextBox_isbn.Text;
                    String Book_Author = TextBox_author.Text;
                    String Book_brief = TextBox_brief.Text;
                    DateTime Book_Date = Calendar1.SelectedDate.Date;
                    DataClasses1DataContext db = new DataClasses1DataContext();
                    int result = (from q in db.book where q.Book_ISBN == Book_ISBN select q).Count();
                    if (result != 0)
                    {
                        e.Cancel = true;
                        Response.Write("<script>alert('ISBN重复')</script>");
                        return;
                    }
                    string filename = "";
                    string path = "";
                    string savepath = "";
                    if (FileUpload2.HasFile == false)
                    {
                        Response.Write("<script>alert('您还没有选择封面图片')</script>");
                        return;
                    }

                    else
                    {
                        path = Server.MapPath("~/upload/");
                        filename = "guide-temp"+Guid.NewGuid().ToString() + System.IO.Path.GetExtension(FileUpload2.FileName).ToLower();
                        savepath = path + filename;
                        FileUpload2.SaveAs(savepath);
                        Session["filename"] = filename;
                        Session["extension"] = System.IO.Path.GetExtension(FileUpload2.FileName).ToLower();
                    }
                    //book newBook = new book();
                    //newBook.Book_Author = Book_Author;
                    //newBook.Book_ISBN = Book_ISBN;
                    //newBook.Book_Title = Book_name;
                    //newBook.Book_Date = Book_Date;
                    //newBook.Book_Brief = Book_brief;
                    //db.book.InsertOnSubmit(newBook);
                    //try
                    //{
                    //    db.SubmitChanges();
                    //}
                    //catch (Exception a)
                    //{
                    //    Response.Write("<script>alert('" + a.Message + "')</script>");
                    //}
                }
                if (RadioButtonList1.SelectedIndex == -1)
                {
                    e.Cancel = true;
                    Response.Write("<script>alert('未选择操作')</script>");
                }
                #endregion

            }
            if (e.CurrentStepIndex == 1)
            {
                if (RadioButtonList2.SelectedIndex == 1 && RadioButtonList1.SelectedIndex == 0) {
                    e.Cancel = true;
                    Response.Write("<script>alert('新建教材必须添加知识点')</script>");
                    return;
                }
                if (RadioButtonList2.SelectedIndex == 0 && TextBox2.Text == "")
                {
                    e.Cancel = true;
                    Response.Write("<script>alert('页码不能为空')</script>");
                }
                if (RadioButtonList2.SelectedIndex == 1 && GridView4.SelectedIndex == -1)
                {
                    e.Cancel = true;
                    Response.Write("<script>alert('必须选择一个知识点')</script>");
                }
              //  MultiView3.ActiveViewIndex=0;
            }
            if (e.CurrentStepIndex == 2)
            {
                if (DropDownList2.SelectedIndex == -1) {
                    e.Cancel = true;
                    Response.Write("<script>alert('未选择类型')</script>");
                }
                #region
                DataClasses1DataContext db = new DataClasses1DataContext();
                uploadlinq new_upload = new uploadlinq();
                if (DropDownList2.SelectedValue.ToString().Equals("pic"))
                {
                    new_upload.类型 = "pic";
                }
                if (DropDownList2.SelectedValue.ToString().Equals("video"))
                {
                    new_upload.类型 = "video";
                }
                if (DropDownList2.SelectedValue.ToString().Equals("html"))
                {
                    new_upload.类型 = "html";
                }
                string path = Server.MapPath("~/upload/");
                new_upload.是否启用 = 1;
                new_upload.上传时间 = DateTime.Now;
                if (new_upload.类型 == "html")
                {
                    new_upload.路径 = CKEditor1.Text;
                    new_upload.备注 = TextBox1.Text;
                    try
                    {
                        db.uploadlinq.InsertOnSubmit(new_upload);
                        db.SubmitChanges();
                    }
                    catch (Exception err)
                    {
                        e.Cancel = true;
                        Response.Write("<script>alert('" + "保存出错" + err.Message.ToString() + "')</script>");
                        return;
                    }
                    Label7.Text = "<div width=\"400px\"   class=\"alert alert-success  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>成功！</strong></div>";
                    // Response.Write("<div class=\"alert alert-warning\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times; </a> <strong>警告！</strong>您的网络连接有问题。</div>");
                }
                if (FileUpload1.HasFile && new_upload.类型 != "html")
                {
                   
                    if (System.IO.Path.GetExtension(FileUpload1.FileName).ToLower() == "aspx")
                    {
                        e.Cancel = true;
                        Response.Write("<script>alert('文件非法')</script>");
                    }
                    else
                    {
                        try
                        {
                            string filename = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                            string savepath = path + filename;
                            FileUpload1.SaveAs(savepath);
                            // Uploadclass tmp = new Uploadclass();
                            //if (tmp.AddUpload(type, filename, TextBox_comment.Text) == 1) {
                            // Response.Write("<script>alert('成功')</script>");
                            //  FileUpload1.SaveAs(savepath);
                            //  Response.Redirect("Uploader.aspx");
                            // Response.Write("<script>alert('成功')</script>");
                            //}
                            new_upload.路径 = filename;
                            new_upload.备注 = TextBox1.Text;
                            db.uploadlinq.InsertOnSubmit(new_upload);
                            db.SubmitChanges();




                            // Response.Write(savepath+"");
                            // Response.Write(ResolveUrl("~/upload/f9ff34c2-89ea-45dd-b284-e052d4cdc716.PNG"));
                        }
                        catch (Exception e1)
                        {
                            e.Cancel = true;
                            Response.Write("<script>alert('" + "保存出错" + e1.Message.ToString() + "')</script>");
                        }


                    }
                }
                else if (FileUpload1.HasFile == false && new_upload.类型 != "html")
                {
                    e.Cancel = true;
                    Response.Write("<script>alert('您还没有选择文件')</script>");
                }
                    #endregion

                var result = from q in db.uploadlinq where q.上传时间 == new_upload.上传时间 select q;
                uploadlinq resultout=result.First();
                qrcode new_qr = new qrcode();
                string url_generated = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                new_qr.Url = url_generated;
                new_qr.生成时间 = DateTime.Now;
                new_qr.uploadId = resultout.uploadId;
                new_qr.备注 = DateTime.Now.ToString() + "生成";
                db.qrcode.InsertOnSubmit(new_qr);
                try
                {
                    db.SubmitChanges();
                   // Label_boot.Text = "<div width=\"400px\"   class=\"alert alert-success  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>成功</strong></div>";
                }
                catch (Exception err)
                {
                    e.Cancel = true;
                    Response.Write("<script>alert('"+err.Message+"')</script>");
                   
                }
                Session["url"] = url_generated;
                Image1.ImageUrl = "genqr.aspx?url=" + url_generated;

            }

          
            
            
        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList2.SelectedIndex == 0) {
                MultiView2.ActiveViewIndex = 0;
            }
            else if (RadioButtonList2.SelectedIndex == 1) {
                MultiView2.ActiveViewIndex = 1;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue.ToString().Equals("html"))
            {

                FileUpload1.Visible = false;
                CKEditor1.Visible = true;
                Label2.Text = "编辑网页";
            }
            else
            {
                FileUpload1.Visible = true;
                CKEditor1.Visible = false;
                Label2.Text = "选择文件";
            }
        }

        protected void CKEditor1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}