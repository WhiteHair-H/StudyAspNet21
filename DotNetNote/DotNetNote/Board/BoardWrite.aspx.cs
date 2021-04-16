using DotNetNote.Models;
using Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.Board
{
    public partial class BoardWrite : System.Web.UI.Page
    {
        public BoardWriteFormType FormType { get; set; }//기본값 : 글쓰기

        private string _Id;//앞(리스트)에서 넘겨져 온 번호 저장
        // private string _Mode; // 뷰에서 넘겨주는 모드값 // Edit , Reply



        private string _BaseDir = String.Empty;//파일 업로드 폴더
        private string _FileName = String.Empty;//파일명 저장 필드
        private int _FileSize = 0;//파일크기 저장 필드


        protected void Page_Load(object sender, EventArgs e)
        {
            _Id = Request["Id"];

            if (!Page.IsPostBack) // 처음 로드할 때만 바인딩
            {
                ViewState["_Mode"] = Request["Mode"]; // Edit
                if (ViewState["_Mode"].ToString() == "Edit") FormType = BoardWriteFormType.Modify;
                else if (ViewState["_Mode"].ToString() == "Reply") FormType = BoardWriteFormType.Reply;
                else FormType = BoardWriteFormType.Write;

                switch (FormType)
                {
                    case BoardWriteFormType.Write:
                        LblTitleDes.Text =
                            "글 쓰기 - 다음 필드들을 채워주세요.";
                        break;
                    case BoardWriteFormType.Modify:
                        LblTitleDes.Text =
                            "글 수정 - 아래 항목을 수정하세요.";
                        DisplayDataForModify();
                        break;
                    case BoardWriteFormType.Reply:
                        LblTitleDes.Text =
                            "글 답변 - 다음 필드들을 채워주세요.";
                        DisplayDataForReply();
                        break;
                }

            }
        }
        private void DisplayDataForModify()
        {
            var repo = new DbRepository();
            Note note = repo.GetNoteById(Convert.ToInt32(_Id));
            txtName.Text = note.Name;
            txtEmail.Text = note.Email;
            txtHomepage.Text = note.Homepage;
            txtContent.Text = note.Content;

            //Encoding

            string encoding = note.Encoding;
            if (encoding == "Text") rdoEncoding.SelectedIndex = 0;
            else if (encoding == "Mixed") rdoEncoding.SelectedIndex = 2;
            else rdoEncoding.SelectedIndex = 1;


            // TODO : 파일처리



        }

        private void DisplayDataForReply()
        {
            var repo = new DbRepository();
            Note note = repo.GetNoteById(Convert.ToInt32(_Id));

            txtTitle.Text = $"답변 : {note.Title}";
            txtContent.Text = $"\n\n작성일 : {note.PostDate} , 작성자 : '{note.Name}'\n--------------------\n" +
                $"{note.Content.Replace("\n", "\n>")}\n--------------------\n";
                 

        }


        protected void chkUpload_CheckedChanged(object sender, EventArgs e)
        {
            pnlFile.Visible = !pnlFile.Visible;
        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {
            if (IsImageTextCorrect())
            {
                if (ViewState["_Mode"].ToString() == "Edit") FormType = BoardWriteFormType.Modify;
                else if (ViewState["_Mode"].ToString() == "Reply") FormType = BoardWriteFormType.Reply;
                else FormType = BoardWriteFormType.Write;

                Note note = new Note();
                note.Id = Convert.ToInt32(_Id);
                note.Name = txtName.Text;
                note.Email = txtEmail.Text;
                note.Title = txtTitle.Text;
                note.Homepage = txtHomepage.Text;
                note.Content = txtContent.Text;
                note.FileName = "";
                note.FileSize = 0;
                note.Password = txtPassword.Text;
                note.PostIp = Request.UserHostAddress;
                note.Encoding = rdoEncoding.SelectedValue;

                DbRepository repo = new DbRepository();

                switch (FormType)
                {
                    case BoardWriteFormType.Write:
                        repo.Add(note);
                        Response.Redirect("BoardList.aspx");
                        break;
                    case BoardWriteFormType.Modify:
                        note.ModifyIp = Request.UserHostAddress;
                        // TODO : 파일처리
                        if (repo.UpdateNote(note) > 0) Response.Redirect($"BoardView.aspx?Id{_Id}");
                        else lblError.Text = "업데이트 실패, 암호를 확인하세요";
                        break;
                    case BoardWriteFormType.Reply:
                        note.ParentNum = Convert.ToInt32(_Id);
                        repo.ReplyNote(note);
                        Response.Redirect("BoardList.aspx");
                        break;
                    default:
                        repo.Add(note);
                        Response.Redirect("BoardList.aspx");
                        break;
                }


            }
            else
            {
                lblError.Text = "보안코드가 틀립니다. 다시 입력하세요.";
            }

        }
        private void UploadProcess()
        {
            // 파일 업로드 처리 시작
            _BaseDir = Server.MapPath("./MyFiles");
            _FileName = String.Empty;
            _FileSize = 0;
            if (txtFileName.PostedFile != null)
            {
                if (txtFileName.PostedFile.FileName.Trim().Length > 0
                    && txtFileName.PostedFile.ContentLength > 0)
                {
                    if (FormType == BoardWriteFormType.Modify)
                    {
                        ViewState["FileName"] =
                            FileUtility.GetFileNameWithNumbering(
                                _BaseDir, Path.GetFileName(txtFileName.PostedFile.FileName));
                        ViewState["FileSize"] =
                            txtFileName.PostedFile.ContentLength;
                        //업로드 처리 : SaveAs()
                        txtFileName.PostedFile.SaveAs(
                            Path.Combine(_BaseDir,
                                ViewState["FileName"].ToString()));
                    }
                    else // BoardWrite, BoardReply
                    {
                        _FileName =
                            FileUtility.GetFileNameWithNumbering(
                                _BaseDir,
                                    Path.GetFileName(
                                        txtFileName.PostedFile.FileName));
                        _FileSize = txtFileName.PostedFile.ContentLength;
                        // 업로드 처리 : SaveAs()
                        txtFileName.PostedFile.SaveAs(
                            Path.Combine(_BaseDir, _FileName));
                    }
                }
            }// 파일 업로드 처리 끝


        }

        private bool IsImageTextCorrect()
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                return true;
            }
            else
            {
                if (Session["ImageText"] != null)
                {
                    return (txtImageText.Text == Session["ImageText"].ToString());
                }
            }
            return false; // 보안 코드를 통과하지 못함

        }
    }
}