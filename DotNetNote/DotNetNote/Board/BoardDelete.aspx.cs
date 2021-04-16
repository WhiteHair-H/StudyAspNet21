using DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.Board
{
    public partial class BoardDelete : System.Web.UI.Page
    {
        private string _id; // 현재 게시글 번호



        protected void Page_Load(object sender, EventArgs e)
        {
            _id = Request["Id"];
            lnkCancel.NavigateUrl = $"BoardView.aspx?Id={_id}";

            lblId.Text = _id;
            // TODO : 버튼 clienClick
            btnDelete.Attributes["onclick"] = "return ConfirmDelete();"; // 같음 OnClientClick="return ConfirmDelete();"



            if (string.IsNullOrEmpty(_id))
            {
                Response.Redirect("BoardList.aspx");

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //  현재글의 ID 와 비밀번호 일치하면 삭제

            var repo = new DbRepository();

            if (repo.DeleteNote(Convert.ToInt32(_id), txtPassword.Text) > 0)
            {
                Response.Redirect("BoardList.aspx");

            }
            else
            {
                lblMessage.Text = "삭제되지않았습니다. 비밀번호를 확인하세요";

            }
        }
    }
}