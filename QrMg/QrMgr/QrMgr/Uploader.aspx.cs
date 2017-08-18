using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QrMgr
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string type = "";
            if (RadioButtonList1.SelectedValue == null)
            {
                Response.Write("<script>alert('还没有选择文件类型')</script>");
            }
            else{
            switch (RadioButtonList1.SelectedValue)
            {
                case "pic":type="pic" ; break;
                case "video": type="video"; break;
                case "html": type="html"; break;
                   
            }
           
            string path = Server.MapPath("~/upload/");
            if (FileUpload1.HasFile)
            {
                if (System.IO.Path.GetExtension(FileUpload1.FileName).ToLower() == "aspx") {
                    Response.Write("<script>alert('文件非法')</script>");
                }
                else{
                    try
                    {
                        string filename=Guid.NewGuid().ToString()+ System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                        string savepath=path + filename;
                       // FileUpload1.SaveAs(savepath);
                        Uploadclass tmp = new Uploadclass();
                        if (tmp.AddUpload(type, filename, TextBox_comment.Text) == 1) {
                           // Response.Write("<script>alert('成功')</script>");
                            FileUpload1.SaveAs(savepath);
                            Response.Redirect("Uploader.aspx");
                            Response.Write("<script>alert('成功')</script>");
                        }
                        else
                            Response.Write("<script>alert('失败')</script>");


                       // Response.Write(savepath+"");
                       // Response.Write(ResolveUrl("~/upload/f9ff34c2-89ea-45dd-b284-e052d4cdc716.PNG"));
                    }
                    catch (Exception e1) {
                        Response.Write("<script>alert('"+"保存出错" + e1.Message.ToString()+"')</script>");
                    }

                
                }
            }
            else
                Response.Write("<script>alert('您还没有选择文件')</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           // GridView1.SelectedDataKey[0].ToString
           // Response.Write("<script>alert(" +GridView1.SelectedDataKey[0].ToString() +")</script>" );
            int uploadid = Int32.Parse(GridView1.SelectedDataKey[0].ToString());

            Uploadclass tmp = new Uploadclass();
            if (tmp.setEnable(uploadid, 1) == 1)
            {
                Response.Write("<script>alert('成功')</script>"); GridView1.DataBind();
            }
            else
                Response.Write("<script>alert('失败')</script>");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int uploadid = Int32.Parse(GridView1.SelectedDataKey[0].ToString());

            Uploadclass tmp = new Uploadclass();
            if (tmp.setEnable(uploadid, 0) == 1)
            {
                Response.Write("<script>alert('成功')</script>");
                GridView1.DataBind();
            }

            else
                Response.Write("<script>alert('失败')</script>");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("qrcodemgr.aspx");
        }
        
      
    }
}