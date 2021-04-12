using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWebApp
{
    public partial class FrmFileUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 캐싱 출력
            LblCached.Text = DateTime.Now.ToLongTimeString();
            
        }

        public static string GetCurrentTime(HttpContext context)
        {
            return DateTime.Now.ToLongTimeString();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (ctlFileUpload.HasFile)
            {
                // [2] App_Data 폴더로 파일 업로드
                ctlFileUpload.SaveAs(Server.MapPath(".")
                    + "\\Files\\" + ctlFileUpload.FileName);
                // [3] 다운로드 링크 만들기
                lblResult.Text = String.Format("<a href='{0}{1}'>{1}</a>"
                    , "./Files/"
                    , Server.UrlEncode(ctlFileUpload.FileName));
            }

        }
    }
}