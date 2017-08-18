using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QrMgr
{
    public partial class book : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Loggedin"] == null || !Session["Loggedin"].Equals("1"))
            {
                Response.Redirect("login.aspx");
                return;
            }
            if (Request.QueryString["action"] == "add"){
                MultiView1.ActiveViewIndex = 0;
                foreach (TreeNode a in TreeView1.Nodes) {
                    foreach(TreeNode b in a.ChildNodes){
                        if (b.Text == "添加教材")
                            b.Selected = true;
                    }
                    

                }
            }
            else if (Request.QueryString["action"] == "edit" & !IsPostBack){
                foreach (TreeNode a in TreeView1.Nodes)
                {
                    foreach (TreeNode b in a.ChildNodes)
                    {
                        if (b.Text == "编辑教材")
                            b.Selected = true;
                    }

                    MultiView1.ActiveViewIndex = 1;
                }
               
                if (Request.QueryString["isbn"] != null) {
                    MultiView1.ActiveViewIndex = 2;
                    String isbn = Request.QueryString["isbn"];
                    DataClasses1DataContext db=new DataClasses1DataContext();
                    int result = (from q in db.book where _Book_ISBN == isbn select q).Count();
                    if (result != 0)
                    {
                        Response.Write("<script>alert('ISBN无效')</script>");
                        return;
                    }
                    else {
                        var query = from q in db.book where q.Book_ISBN == isbn select q;
                        foreach (var item in query) {
                            TextBox5.Text = item.Book_Title;
                            TextBox6.Text = item.Book_ISBN;
                            TextBox6.Enabled = false;
                            TextBox7.Text = item.Book_Author;
                            Calendar2.SelectedDate = (DateTime)item.Book_Date;
                            TextBox_newbrief.Text= item.Book_Brief;
                        }
                    }

                }
            }
            else {
                MultiView1.ActiveViewIndex = 1;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string filename ="";
            string path = "";
            string savepath = "";
            if (TextBox2.Text == "" || TextBox2.Text == null || Calendar2.SelectedDate == null) {
                Response.Write("<script>alert('必须输入ISBN和出版日期')</script>");
            }
            if (FileUpload1.HasFile == false)
            {
                Response.Write("<script>alert('您还没有选择封面图片')</script>");
                return;
            }
            else {
                 path = Server.MapPath("~/upload/");
                filename = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                 savepath = path + filename;
               
            }
            String Book_name = TextBox1.Text;
            String Book_ISBN = TextBox2.Text;
            String Book_Author = TextBox3.Text;
            String Book_brief = TextBox4.Text;
            DateTime Book_Date = Calendar1.SelectedDate.Date;
            String Book_coverpath = filename;
            //Response.Write(Book_name + Book_ISBN + Book_Date + Book_Author);
            DataClasses1DataContext db = new DataClasses1DataContext();
            int result = (from q in db.book where q.Book_ISBN == Book_ISBN select q).Count();
            if (result !=0) {
                Response.Write("<script>alert('ISBN重复')</script>");
                return;
            }
            book newBook = new book();
            newBook._Book_Author = Book_Author;
            newBook.Book_ISBN = Book_ISBN;
            newBook.Book_Title = Book_name;
            newBook.Book_Date = Book_Date;
            newBook._Book_Brief = Book_brief;
            newBook.Book_coverpath = Book_coverpath;
            newBook.Book_addDate = DateTime.Now;
            db.book.InsertOnSubmit(newBook);
            try
            {
                db.SubmitChanges();
                FileUpload1.SaveAs(savepath);
            }
            catch (Exception a) 
            {
                Response.Write("<script>alert('" + a.Message + "')</script>");
            }
            Response.Redirect("book.aspx");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex == -1)
            {
                Response.Write("<script>alert('请选择一本教材')</script>");
            }
            else
            {
                String Selected_ISBN = GridView1.SelectedDataKey[0].ToString();
                Response.Redirect("book.aspx?action=edit&isbn=" + Selected_ISBN);
            }


              
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String isbn=TextBox6.Text;
            DataClasses1DataContext db=new DataClasses1DataContext();

            var newbook = db.book.SingleOrDefault( a=> a.Book_ISBN.Equals(TextBox6.Text));
            newbook.Book_Title = TextBox5.Text;
            newbook.Book_Author = TextBox7.Text;
            newbook.Book_Date = Calendar2.SelectedDate;
            newbook.Book_Brief = TextBox_newbrief.Text;
            db.SubmitChanges();



        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string isbn = GridView1.Rows[e.RowIndex].Cells[2].Text;
            DataClasses1DataContext db = new DataClasses1DataContext();
            var result = from q in db.position where q.Book_ISBN == isbn select q;
            int count = result.Count();
            if (count > 0) {
                e.Cancel = true;
                Response.Write("<script>alert('无法删除已有知识点的教材')</script>");
            }

           // e.Cancel = true;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ArrayList a = new ArrayList();
            String book_isbn = GridView1.SelectedDataKey[0].ToString();
            if (book_isbn != null)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                //var result=from q in db.
                //select Url from qrcode where qrId in (select qrid from position where book_isbn='xxxxxxxxx')
                //var result=from q in db.position where Book_ISBN==book_isbn select q.qrid;
                //foreach(var a in result){
                //    var result2 = from q in db.qrcode where q.qrId == a.Value select q;
                //}
                //var result=from q in db.qrcode where (from q1 in db.position where q1.Book_ISBN==book_isbn select q1.qrid).Contains(q.qrId) select q;
                //string url = "";
                //foreach (qrcode a in result) {
                //    url = url + a.Url+"|";
                //}
                var result = from q in db.qrcode join q2 in db.position on q.qrId equals q2.qrid where q2.Book_ISBN==book_isbn select new { 
                    result_isbn=q2.Book_ISBN,
                    result_pos=q2.Pos,
                    result_seq=q2.seq,
                    result_url=q.Url

                };
                foreach (var result1 in result) {
                   // a.Add(result1);
                    zipcommand newcommand = new zipcommand(result1.result_isbn, result1.result_pos, (int)result1.result_seq, result1.result_url);
                    //zipcommand newcommand = new zipcommand();

                    a.Add(newcommand);


                }
                String result_serial = SerializeObj.Serialize(a);
                Session["zipcommand"] = result_serial;
                Response.Redirect("getzip.aspx");
            }
        }
    }
}