using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace QrMgr
{
    public class QrCode
    {
        private int Id;
        private string Url;
        private string Time;
        private string Comment;
        private int UploadId;

        public int Id1
        {
            get
            {
                return Id;
            }

            set
            {
                Id = value;
            }
        }

        public string Url1
        {
            get
            {
                return Url;
            }

            set
            {
                Url = value;
            }
        }

        public string Time1
        {
            get
            {
                return Time;
            }

            set
            {
                Time = value;
            }
        }

        public string Comment1
        {
            get
            {
                return Comment;
            }

            set
            {
                Comment = value;
            }
        }

        public int UploadId1
        {
            get
            {
                return UploadId;
            }

            set
            {
                UploadId = value;
            }
        }

        public QrCode() { }

        //添加二维码
        public int AddQrCode(string UrlIn, string Comment)
        {
            string ConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnStr);
            string sql = "insert into qrcode (Url,备注,uploadId) values(@url,@comment,null)";//@njo,参数传递
            SqlParameter para_url = new SqlParameter("@url", UrlIn);
            SqlParameter para_comment = new SqlParameter("@comment", Comment);
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.Add(para_url);
            command.Parameters.Add(para_comment);
            conn.Open();
            try
            {//测试数据是否正常传递
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                reader.Close();
                return 1;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                return -1;
            }
            conn.Close();
        }
        //更新
        public int UpdateUploadId(string url, int UploadId)
        {
            string ConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnStr);
            string sql = "update qrcode set uploadId=@UploadId where Url=@url ";//更新数据
            SqlParameter para_uploadid = new SqlParameter("@UploadId", UploadId);
            SqlParameter para_url = new SqlParameter("@url", url);
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.Add(para_url);
            command.Parameters.Add(para_uploadid);
            conn.Open();
            try//测试
            {
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                reader.Close();
                return 1;
            }
            catch (Exception e)
            {
                return -1;
                e.Message.ToString();
            }
            conn.Close();
        }
        public int ClearUploadId(string url)
        {
            string ConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnStr);
            string sql = "update qrcode set uploadId=null where Url=@url ";//更新数据
        
            SqlParameter para_url = new SqlParameter("@url", url);
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.Add(para_url);
           
            conn.Open();
            try//测试
            {
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                reader.Close();
                return 1;
            }
            catch (Exception e)
            {
                return -1;
                e.Message.ToString();
            }
            conn.Close();
        }
        //get path by url
        public string select_url(string Url)
        {
            string ConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnStr);
            string sql = "select 路径 from qrcode,upload where qrcode.uploadId=upload.uploadId and Url=@url";
            SqlParameter para_url = new SqlParameter("@url", Url);
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.Add(para_url);
            conn.Open();
            try//测试
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return reader[0].ToString();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                return "";
                e.Message.ToString();
            }
            conn.Close();

        }
        public string select_id_url(string Url)
        {
            string ConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnStr);
            string sql = "select upload.uploadId from qrcode,upload where qrcode.uploadId=upload.uploadId and Url=@url";
            SqlParameter para_url = new SqlParameter("@url", Url);
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.Add(para_url);
            conn.Open();
            try//测试
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return reader[0].ToString();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                return "";
                e.Message.ToString();
            }
            conn.Close();

        }
    }
}