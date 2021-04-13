using DbHandlingWebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DbHandlingWebApp
{
    public partial class FrmMemoWrite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnWrite_Click(object sender, EventArgs e)
        {
            Memos memos = new Memos();
            memos.Name = TxtName.Text;
            memos.Email = TxtEmail.Text;
            memos.Title = TxtTitle.Text;
            memos.PostDate = DateTime.Now;
            memos.PostIP = Request.UserHostAddress;

            var connstring = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            using (var conn = new SqlConnection(connstring))
            {
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("WriteMemo", conn); // 저장프로시져
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", memos.Name);
                    cmd.Parameters.AddWithValue("@Email", memos.Email);
                    cmd.Parameters.AddWithValue("@Title", memos.Title);
                    cmd.Parameters.AddWithValue("@PostDate", memos.PostDate);
                    cmd.Parameters.AddWithValue("@PostIP", memos.PostIP);

                    cmd.ExecuteNonQuery();

                    lblDisplay.Text = "저장되었습니다!";
                }
                catch (Exception ex)
                {
                    lblDisplay.Text = $"예외발생 {ex}";
                }
            }
        }

        protected void BtnList_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmMemoList.aspx");
        }
    }
}