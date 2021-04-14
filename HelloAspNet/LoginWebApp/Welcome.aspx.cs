using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginWebApp
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                // [!] 인증 이름 출력
                lblName.Text = Page.User.Identity.Name;
            }
            else
            {
                Response.Redirect("~/Login.aspx"); // 로그인 페이지로 이동
            }

        }
    }
}