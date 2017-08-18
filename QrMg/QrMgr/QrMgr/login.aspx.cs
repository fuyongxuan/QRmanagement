using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QrMgr
{
    public partial class super_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void enter_Click(object sender, EventArgs e)
        {
            
            //string test = "admin";
            //string hd5 = getHD5Str(test);
            //MD5 md5 = new MD5CryptoServiceProvider();
            //string by= md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(test)).ToString();
            //Console.Write(by);
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            SqlConnection con = new SqlConnection(conn);
            string sql = "select 密码 from tbluser where 用户名=@user";
            SqlParameter userr = new SqlParameter("@user",userName.Text);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(userr);
            con.Open();
            try
            {
                string str = "";
                if (Session["code"] != null)
                {
                    str = Session["Code"].ToString();
                }
                else
                {
                    Response.Write("<script language=javascript>alert(\"请点击验证码重试\")</script>");
                }
                if (String.Equals(txtCode.Text.Trim(),Session["Code"].ToString(), StringComparison.CurrentCultureIgnoreCase))

                {

                    SqlDataReader reader = cmd.ExecuteReader();
                    string passHd5 = getHD5Str(password.Text);
                    if (reader.Read())
                    {
                        if (reader[0].ToString().Trim().Equals(passHd5))
                        {
                            DataClasses1DataContext db = new DataClasses1DataContext();
                            var result = from q in db.tbluser where q.用户名 == userName.Text select q;
                            tbluser resultout = result.First();
                            int flag = (int)resultout.userflag;

                            Session["Loggedin"] = "1";
                            Session["userflag"] = flag.ToString();
                            Session["username"] = userName.Text;
                            //Response.Write("<script>alert(\"登入成功\")</script>");
                            Response.Redirect("admin.aspx");
                            //Session["Loggedin"] = "1";
                            // Response.Redirect("www.baidu.com");
                        }
                        else
                        {
                            Response.Write("<script language=javascript>alert(\"登入失败\")</script>");
                            password.Text = "";
                        }
                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert(\"登入失败\")</script>");
                        userName.Text = "";
                    }

                }

                else

                {
                    Response.Write("<script language=javascript>alert(\"验证码输入错误！请重新输入\")</script>");
                    password.Text = "";
                    userName.Text = "";

                }

            }
            catch (Exception e1)
            {
                Response.Write("<script language=javascript>alert(\""+e1.Message.ToString()+"\")</script>");


            }
            con.Close();
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

        protected void exit_Click(object sender, EventArgs e)
        {
           
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

    }
}


