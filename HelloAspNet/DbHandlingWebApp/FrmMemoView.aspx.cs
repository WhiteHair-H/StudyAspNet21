using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DbHandlingWebApp
{
    public partial class FrmMemoView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Request["Num"]))
            {
                Response.Write("잘못된 요청입니다");
                Response.End();
            }
            else
            {
                var connstring = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

                using (var conn = new SqlConnection(connstring))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    try
                    {
                        SqlCommand cmd = new SqlCommand("ViewMemo", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Num", Convert.ToInt32(Request["Num"]));

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            LblNum.Text = Request["Num"];
                            LblName.Text = reader["Name"].ToString();
                            LblEmail.Text = reader["Email"].ToString();
                            LblTitle.Text = reader["Title"].ToString();
                            LblPostDate.Text = reader["PostDate"].ToString();
                            LblPostIP.Text = reader["PostIP"].ToString();
                        }

                        reader.Close();
                    }

                    catch (Exception ex)
                    {
                        Response.Write($"예외발생 : {ex}");
                    }

                }
            }

        }

    }
}