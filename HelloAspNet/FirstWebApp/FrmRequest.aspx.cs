using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWebApp
{
    public partial class FrmRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strUserId = "";
            string strPassword = string.Empty;
            string strName = "";
            string strAge = "";

            // GET 값은 웬만하면 쓰지않기 - 위치 - URL부분

            strUserId = Request.Params["TxtUserID"];  // Request.QueryString["TxtUserID"]; // GET 형식 가져올때
            strPassword = Request.Params["TxtPassword"]; //GET/POST 뭐든지 불러옴 , 일반적으로 쓰임(1)
            strName = Request.Form["TxtName"]; // Post 형식 , 안에 있는 내용들만 넘어옴
            strAge = Request["TextAge"]; // 일반적으로 쓰임(2)

            var result = $@"입력하신 아이디는 {strUserId}이고<br />
                            암호는 {strPassword} 입니다.<br />
                            이름은 {strName}입니다.<br />
                            나이는 {strAge}입니다.<br />
                                    ";

            LblResult.Text = result;

            LblIpAddress.Text = Request.UserHostAddress;

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}