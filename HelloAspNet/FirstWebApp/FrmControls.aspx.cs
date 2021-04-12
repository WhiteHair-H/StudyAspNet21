using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWebApp
{
    public partial class FrmControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CtlHidden.Value = DateTime.Now.ToString();
            }
        }

        protected void BtnChage_Click(object sender, EventArgs e)
        {
            ImgChange.ImageUrl = "~/img/ASP-NET-Banners-02.png";

           
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            Response.Write(CtlHidden.Value);
        }
    }
}