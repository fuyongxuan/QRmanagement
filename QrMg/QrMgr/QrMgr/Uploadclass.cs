using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace QrMgr
{
    public class Uploadclass
    {
        public Uploadclass() { }
        public int AddUpload(string type, string path, string comment)
        {//上传
            string ConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnStr);
            string sql = "insert into upload (类型,路径,备注,是否启用) values(@type,@path,@comment,0)";
            SqlParameter para_type = new SqlParameter("@type", type);
            SqlParameter para_path = new SqlParameter("@path", path);
            SqlParameter para_comment = new SqlParameter("@comment", comment);
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.Add(para_type);
            command.Parameters.Add(para_path);
            command.Parameters.Add(para_comment);
            conn.Open();
            try
            {
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
        public string getTypebyId(int id) {
            string ConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnStr);
            string sql = "select 类型 from upload where uploadId=@id";
            SqlParameter para_id = new SqlParameter("@id", id);
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.Add(para_id);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return reader[0].ToString();

            }
            catch (Exception e)
            {
                e.Message.ToString();
                return "";
            }
            conn.Close();
        }
        public int getEnable(int id)
        {
            string ConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnStr);
            string sql = "select 是否启用 from upload where uploadId=@id";
            SqlParameter para_id = new SqlParameter("@id", id);
            SqlCommand command = new SqlCommand(sql,conn);
            command.Parameters.Add(para_id);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return Int32.Parse(reader[0].ToString());

            }
            catch (Exception e)
            {
                e.Message.ToString();
                return -1;
            }
            conn.Close();
        }
        public int setEnable(int uploadid, int uel)
        {
            string ConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnStr);
            string sql = "update upload set 是否启用=@uel where uploadId=@uid";
            SqlParameter para_id = new SqlParameter("@uid", uploadid);
            SqlParameter pare_uel = new SqlParameter("@uel", uel);
            SqlCommand command = new SqlCommand(sql,conn);
            command.Parameters.Add(para_id);
            command.Parameters.Add(pare_uel);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return 1;

            }
            catch (Exception e)
            {
                e.Message.ToString();
                return -1;
            }
            conn.Close();
        }
        public string getPathbyId(int id) {
            string ConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnStr);
            string sql = "select 路径 from upload where uploadId=@id";
            SqlParameter para_id = new SqlParameter("@id", id);
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.Add(para_id);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return reader[0].ToString();

            }
            catch (Exception e)
            {
                e.Message.ToString();
                return "";
            }
            conn.Close();
        
        }
    }
}