using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QrMgr
{
    public partial class QrCodemgr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox_urlinput.Enabled = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedItem== null) {
                Response.Write("<script>alert('请选自定义或自动生成')</script>");
                }
            else
            {
                if (RadioButtonList1.SelectedValue == "customized")
                {
                    QrCode tmp = new QrCode();
                    if(tmp.AddQrCode(TextBox_urlinput.Text, TextBox_comment.Text)==1)
                         Response.Write("<script>alert('成功')</script>");
                    else
                         Response.Write("<script>alert('失败')</script>");
                }
                if (RadioButtonList1.SelectedValue == "generated")
                {
                    string url_generated = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                    QrCode tmp = new QrCode();
                   if( tmp.AddQrCode(url_generated, TextBox_comment.Text)==1)
                       Response.Write("<script>alert('成功')</script>");
                    else
                       Response.Write("<script>alert('失败')</script>");
                      
                }
            }
            GridView1.DataBind();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "customized")
                TextBox_urlinput.Enabled = true;
            else
                TextBox_urlinput.Enabled = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex == -1 || GridView2.SelectedIndex == -1) {
                Response.Write("<script>alert('请选择要关联的选项')</script>");
            }
            else
            {
                string SelectedQrcodeUrl = GridView1.SelectedRow.Cells[3].Text;
                string testUploadId = GridView1.SelectedRow.Cells[2].Text;
                if (testUploadId == "&nbsp;")
                {
                    int SelectedUploadId = Int32.Parse(GridView2.SelectedDataKey[0].ToString());
                    QrCode tmp = new QrCode();
                    //Response.Write(SelectedUploadId.ToString() + SelectedQrcodeUrl);
                    if (tmp.UpdateUploadId(SelectedQrcodeUrl, SelectedUploadId) == 1)
                        Response.Write("<script>alert('成功')</script>");
                    else
                        Response.Write("<script>alert('失败')</script>");
                    GridView1.DataBind();
                }
                else
                {

                    Response.Write("<script>alert('请先解除关联')</script>");

                }
            }
        }

        protected void Button_disassociate_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex == -1 )
            {
                Response.Write("<script>alert('请选择要解除关联的选项')</script>");
            }
            else
            {
                string SelectedQrcodeUrl = GridView1.SelectedRow.Cells[3].Text;
                //int SelectedUploadId = Int32.Parse(GridView2.SelectedDataKey[0].ToString());
                QrCode tmp = new QrCode();
                //Response.Write(SelectedUploadId.ToString() + SelectedQrcodeUrl);
                if (tmp.ClearUploadId(SelectedQrcodeUrl) == 1)
                    Response.Write("<script>alert('成功')</script>");
                else
                    Response.Write("<script>alert('失败')</script>");
                GridView1.DataBind();
            }
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            GridView1.SelectedIndex = -1;
            GridView1.SelectedIndex = -1;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("uploader.aspx");
        }
    }
}