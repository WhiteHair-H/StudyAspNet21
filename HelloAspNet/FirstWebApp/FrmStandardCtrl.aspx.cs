using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWebApp
{
    public partial class FrmStandardCtrl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblDateTime.Text = DateTime.Now.ToString();
            BtnHtml.Value = "HTML 서버컨트롤 - 버튼";
            BtnServer.Text = "표준 컨트롤 - 버튼";

            var result = $"유저아이디 : {TxtUserId.Text}" +
                         $"패스워드 : {TxtUserPasswrod.Text}" +
                         $"설명 : {TxtDesc.Text}";
            Response.Write(result);


        }
    }
}