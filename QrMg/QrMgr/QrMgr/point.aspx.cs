using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QrMgr
{
    public partial class point : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Loggedin"] == null || !Session["Loggedin"].Equals("1"))
            //{
            //    Response.Redirect("login.aspx");
            //    return;
            //}
            int id;
            if (Request.QueryString["action"] == "add") {
                foreach (TreeNode a in TreeView1.Nodes)
                {
                    foreach (TreeNode b in a.ChildNodes)
                    {
                        if (b.Text == "添加知识点")
                            b.Selected = true;
                    }


                }
                MultiView1.ActiveViewIndex = 0;
            }
            else if (Request.QueryString["action"] == "edit" && Request.QueryString["id"] != null)
            {
                foreach (TreeNode a in TreeView1.Nodes)
                {
                    foreach (TreeNode b in a.ChildNodes)
                    {
                        if (b.Text == "编辑知识点")
                            b.Selected = true;
                    }


                }
                try
                {
                     id = Int32.Parse(Request.QueryString["id"]);

                }
                catch (Exception err){
                    Response.Write("<script>alert('id错误')</script>");
                    return;
                }

                MultiView1.ActiveViewIndex = 2;
                DataClasses1DataContext db = new DataClasses1DataContext();
                var result=from q in db.position where q.Id==id select q;
                position resultout=result.First();
                TextBox2.Text = resultout.Book_ISBN;
                TextBox2.Enabled = false;
                TextBox3.Text = resultout.Pos;
                TextBox_edit_position_name.Text = resultout.name;



            }
            else
            {
                if (Request.QueryString["isbn"] != null) {
                    string isbn = Request.QueryString["isbn"];
                    SqlDataSource2.SelectCommand = "SELECT * FROM [position] where Book_ISBN ='" + isbn + "'";
                    
                }
                foreach (TreeNode a in TreeView1.Nodes)
                {
                    foreach (TreeNode b in a.ChildNodes)
                    {
                        if (b.Text == "编辑知识点")
                            b.Selected = true;
                    }


                }
                MultiView1.ActiveViewIndex = 1;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedDataKey == null||GridView3.SelectedDataKey==null)
            {
                Response.Write("<script>alert('必须选择一本教材和二维码')</script>");
            
                return;

            }
            else 
            {
                String ISBN_selected=GridView1.SelectedDataKey[0].ToString();
                String pos=TextBox1.Text;
                int seq_tmp=0;
                DataClasses1DataContext db = new DataClasses1DataContext();
                position a = new position();
                a.Book_ISBN = ISBN_selected;
                a.Pos = pos;
                var result= from tmp in db.position where tmp.Book_ISBN==ISBN_selected where tmp.Pos==pos select tmp;
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
                a.qrid = Int32.Parse(GridView3.SelectedDataKey[0].ToString());
                if (TextBox_position_name.Text != "")
                    a.name = TextBox_position_name.Text;
                else
                    a.name = "";
                db.position.InsertOnSubmit(a);
                try
                {
                    db.SubmitChanges();
                }
                catch (Exception err)
                {
                    Response.Write("<script>alert('" + err.Message + "')</script>");
                }
                Response.Redirect("point.aspx");
            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String id = GridView2.SelectedDataKey[0].ToString(); //master key
            Response.Redirect("point.aspx?action=edit&id=" + id);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            String isbn = TextBox2.Text;
            String new_pos = TextBox3.Text;
            int new_seq = 0;
            int seq_tmp = 0;
            var result = from tmp in db.position where tmp.Book_ISBN == isbn where tmp.Pos == new_pos select tmp;
            if (result == null)
            {
                new_seq = 0;
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
                new_seq = seq_tmp;
            }
            int  id = Int32.Parse(Request.QueryString["id"]);
           
            var result1 = from q in db.position where q.Id == id select q;
            position resultout = result1.First();
            resultout.Pos = new_pos;
            resultout.seq = new_seq;
            resultout.qrid=Int32.Parse(GridView4.SelectedDataKey[0].ToString());
            if (TextBox_edit_position_name.Text != "")
                resultout.name = TextBox_edit_position_name.Text;
            else
                resultout.name = TextBox_edit_position_name.Text;
            try
            {
                db.SubmitChanges();
                Response.Write("<script>alert(\"成功\")</script>");
            }
            catch (Exception err) {
                Response.Write("<script>alert('" + err.Message + "')</script>");
            }
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //if (GridView2.Rows[e.RowIndex].Cells[4].Text == "")
            //{
            //    Response.Write("<script>alert(\"无法删除已关联二维码知识点\")</script>");
                
            //    e.Cancel = true;

            //}
        }
    }
}