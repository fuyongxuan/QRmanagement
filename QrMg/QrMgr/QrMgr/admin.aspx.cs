using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QrMgr
{
    public partial class admin1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userflag = "";
            if (Session["Loggedin"] == null || !Session["Loggedin"].Equals("1"))
            {
                Response.Redirect("login.aspx");
                return;
            }
            else {
                if (Session["userflag"].Equals("0"))
                    userflag = "超级管理员";
                else
                    userflag = "普通用户";

                Label_username.Text = "欢迎使用系统 " +userflag +" " +Session["username"].ToString();
            }
            DataClasses1DataContext db = new DataClasses1DataContext();
            int counter = 0;
            var result = (from q in db.book orderby q.Book_addDate select q).Take(6);
            foreach (book q in result) {
                 if (q.Book_coverpath != null) { 
                switch (counter)
                {
                    case 0:
                        ImageButton1.ImageUrl = ResolveUrl("~/upload/" + q.Book_coverpath);
                        ImageButton1.PostBackUrl = "Handler1.ashx?isbn=" + q.Book_ISBN;
                        break;
                    case 1:
                        ImageButton2.ImageUrl = ResolveUrl("~/upload/" + q.Book_coverpath);
                        ImageButton2.PostBackUrl = "Handler1.ashx?isbn=" + q.Book_ISBN;
                        break;
                    case 2:
                        ImageButton3.ImageUrl = ResolveUrl("~/upload/" + q.Book_coverpath);
                        ImageButton3.PostBackUrl = "Handler1.ashx?isbn=" + q.Book_ISBN;
                        break;
                    case 3:
                        ImageButton4.ImageUrl = ResolveUrl("~/upload/" + q.Book_coverpath);
                        ImageButton4.PostBackUrl = "Handler1.ashx?isbn=" + q.Book_ISBN;
                        break;
                    case 4:
                        ImageButton5.ImageUrl = ResolveUrl("~/upload/" + q.Book_coverpath);
                        ImageButton5.PostBackUrl = "Handler1.ashx?isbn=" + q.Book_ISBN;
                        break;
                    case 5:
                        ImageButton6.ImageUrl = ResolveUrl("~/upload/" + q.Book_coverpath);
                        ImageButton6.PostBackUrl = "Handler1.ashx?isbn=" + q.Book_ISBN;
                        break;

                }
                 }
                if (q.Book_coverpath == null) {
                    switch (counter)
                    {
                        case 0:
                            ImageButton1.ImageUrl = ResolveUrl("~/upload/notfound.png");
                              ImageButton1.PostBackUrl = "Handler1.ashx?isbn=" + q.Book_ISBN;
                            break;
                        case 1:
                            ImageButton2.ImageUrl = ResolveUrl("~/upload/notfound.png");
                             ImageButton2.PostBackUrl = "Handler1.ashx?isbn=" + q.Book_ISBN;
                            break;
                        case 2:
                            ImageButton3.ImageUrl = ResolveUrl("~/upload/notfound.png");
                            ImageButton3.PostBackUrl = "Handler1.ashx?isbn=" + q.Book_ISBN;
                            break;
                        case 3:
                            ImageButton4.ImageUrl = ResolveUrl("~/upload/notfound.png");
                              ImageButton4.PostBackUrl = "Handler1.ashx?isbn=" + q.Book_ISBN;
                            break;
                        case 4:
                            ImageButton5.ImageUrl = ResolveUrl("~/upload/notfound.png");
                             ImageButton5.PostBackUrl = "Handler1.ashx?isbn=" + q.Book_ISBN;
                            break;
                        case 5:
                            ImageButton6.ImageUrl = ResolveUrl("~/upload/notfound.png");
                             ImageButton6.PostBackUrl = "Handler1.ashx?isbn=" + q.Book_ISBN;
                            break;
                    }
                }

                counter++;
                    
                }
                
            }

        

      


    }
}