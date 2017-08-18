using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QrMgr
{
    public partial class useradmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Loggedin"] == null || !Session["Loggedin"].Equals("1"))
            {
                Response.Redirect("login.aspx");
                return;
            }
            foreach (TreeNode a in TreeView1.Nodes)
            {
                foreach (TreeNode b in a.ChildNodes)
                {
                    if (b.Text == "修改密码")
                        b.NavigateUrl = "useradmin.aspx?action=edit&username=" + getusername();
                }


            }
            
            if (Request.QueryString["action"] == "edit" &Request.QueryString["username"]!=null&Request.QueryString["username"]!="")
            {
                foreach (TreeNode a in TreeView1.Nodes)
                {
                    foreach (TreeNode b in a.ChildNodes)
                    {
                        if (b.Text == "修改密码")
                            b.Selected = true;
                    }


                }
                MultiView1.ActiveViewIndex = 1;
            }
            else if (Request.QueryString["action"] == "add") {
                MultiView1.ActiveViewIndex = 2;
                foreach (TreeNode a in TreeView1.Nodes)
                {
                    foreach (TreeNode b in a.ChildNodes)
                    {
                        if (b.Text == "添加用户")
                            b.Selected = true;
                    }


                }
            }
            else
            {
                MultiView1.ActiveViewIndex = 0;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                String isEnable = e.Row.Cells[2].Text.Trim();
                if (isEnable.Equals("0"))
                {
                    e.Row.Cells[2].Text = "超级管理员";
                }
                else if (isEnable.Equals("1"))
                {
                    e.Row.Cells[2].Text = "普通用户";
                }
               
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex == -1)
            {
                Label_boot.Text = "<div width=\"400px\"   class=\"alert alert-warning  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>请选择要修改密码的账户</strong></div>";
            }
            else {
                Response.Redirect("useradmin.aspx?action=edit&username=" + GridView1.SelectedDataKey[0].ToString());
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var result = from q in db.tbluser where q.用户名 == Session["username"] select q;
                tbluser resultout = result.First();
                if (resultout.userflag != 0&&!Session["username"].Equals(Request.QueryString["username"])) {
                    Label_boot_2.Text = "<div width=\"400px\"   class=\"alert alert-warning  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>普通用户只能修改自己的密码</strong></div>";
                    return;
                }
            }
            else {
                Label_boot_2.Text = "<div width=\"400px\"   class=\"alert alert-warning  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>未登陆</strong></div>";
                return;
            }
            if (!TextBox1.Text.Equals(TextBox2.Text))
            {
                Label_boot_2.Text = "<div width=\"400px\"   class=\"alert alert-warning  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>输入密码不一致</strong></div>";
            }
            else {

                DataClasses1DataContext db = new DataClasses1DataContext();
                var result = from q in db.tbluser where q.用户名 == Request.QueryString["username"] select q;
                tbluser resultout = result.First();
                resultout.密码 = getHD5Str(TextBox1.Text);
                try
                {
                    db.SubmitChanges();
                    Label_boot_2.Text = "<div width=\"400px\"   class=\"alert alert-success  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>成功</strong></div>";
                }
                catch (Exception err) {
                    Label_boot_2.Text = "<div width=\"400px\"   class=\"alert alert-warning  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>"+err.Message+"</strong></div>";
                }
            }
        }
        public static string getHD5Str(string ConvertString)//获取加密后的字符串
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(ConvertString));//字节型

            StringBuilder sb = new StringBuilder(16);//
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString());//转换成字符串型
            }
            return sb.ToString().ToUpper();//返回大写形式字符串
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var result = from q in db.tbluser where q.用户名 == TextBox_username.Text select q;
            int cout = result.Count();
            if (cout != 0)
            {
                Label_boot_3.Text = "<div width=\"400px\"   class=\"alert alert-warning  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong> 用户名已存在</strong></div>";
            }
            else {
                tbluser new_user = new tbluser();
                new_user.用户名 = TextBox_username.Text;
                new_user.密码 = getHD5Str(TextBox4_password.Text);
                new_user.userflag = 1;
                db.tbluser.InsertOnSubmit(new_user);
                try
                {
                    db.SubmitChanges();
                    Label_boot_3.Text = "<div width=\"400px\"   class=\"alert alert-success  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong> 成功</strong></div>";
                }
                catch (Exception err) {
                    Label_boot_2.Text = "<div width=\"400px\"   class=\"alert alert-warning  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>" + err.Message + "</strong></div>";
                }
            }
        }
        public string getusername() {
            if (Session["username"] == null) {
                return "";
            }
            else
            return Session["username"].ToString();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String deletinguser = GridView1.Rows[e.RowIndex].Cells[1].Text;
            if (deletinguser.Equals(getusername()))
            {
                Label_boot.Text = "<div width=\"400px\"   class=\"alert alert-warning  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>您不能删除自己</strong></div>";
                e.Cancel = true;
                return;
            }
            DataClasses1DataContext db = new DataClasses1DataContext();
            var result = from q in db.tbluser where q.用户名 == Session["username"] select q;
            tbluser resultout = result.First();
            if (resultout.userflag != 0 )
            {
                Label_boot.Text = "<div width=\"400px\"   class=\"alert alert-warning  alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\"  aria-label=\"close\">&times; </a> <strong>非管理员用户不能删除用户</strong></div>";
                e.Cancel = true;
                return;
            }
            
        }
    }
}