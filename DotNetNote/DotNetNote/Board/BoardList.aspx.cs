using DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.Board
{
    public partial class BoardList : System.Web.UI.Page
    {
        private DbRepository _repo;

        //검색모드 이면 true, 보통 false
        public bool SearchMode { get; set; } = false;

        public int RecordCount = 0;

        public int PageIndex = 0; // 페이지할때 필요한 값, 현재 보여줄 페이지 번호

        public BoardList()
        {
           _repo = new DbRepository(); // splconnection 생성
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SearchMode)
            {
                RecordCount = _repo.GetCountAll();
            }
            LblTotalRecord.Text = $"Total Record : {RecordCount}";

            if(Request["Page"] != null)
            {
                PageIndex = Convert.ToInt32(Request["Page"]) - 1;
            }
            else
            {
                PageIndex = 0; // 1페이지
            }

            // TODO : 쿠키 사용해서 리스트 페이지 번호 유지

            // 페이징 처리
            PagingControl.PageIndex = PageIndex;
            PagingControl.RecordCount = RecordCount;


            if (!Page.IsPostBack)
            {
                DisplayData();
            }
        }

        private void DisplayData()
        {
            if (!SearchMode)
            {
                GrvNotes.DataSource = _repo.GetAll(PageIndex);
            }
            GrvNotes.DataBind(); // 데이터바인딩 끝
        }
    }
}