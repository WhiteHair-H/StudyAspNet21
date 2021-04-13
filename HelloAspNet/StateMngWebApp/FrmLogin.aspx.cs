using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateMngWebApp
{
    public partial class FrmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // 최초로드
            {
                if (Request.Cookies["UserID"] != null)
                {
                    ChkSaveUserID.Checked = true;
                    TxtUserID.Text = Request.Cookies["UserID"].Value;
                    Page.SetFocus(TxtPassword);
                }
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (ChkSaveUserID.Checked)
            {
                HttpCookie cookie = new HttpCookie("UserID" , TxtUserID.Text);
                cookie.Expires = DateTime.Now.AddDays(10); // 10일간 쿠키저장
                Response.Cookies.Add(cookie);
            }
            else
            {
                HttpCookie cookie = new HttpCookie("UserID", TxtUserID.Text);
                cookie.Expires = DateTime.Now.AddDays(-1); // 쿠키삭제
                Response.Cookies.Add(cookie);
            }
            Response.Write("<script>alert('로그인성공!')</script>");
        }
    }
}