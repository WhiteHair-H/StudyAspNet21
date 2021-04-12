<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmFileUpload.aspx.cs" Inherits="FirstWebApp.FrmFileUpload" %>
<%@ OutputCache Duration="60" VaryByParam="None"  %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>파일업로드 컨트롤</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:FileUpload ID="ctlFileUpload" runat="server" />
            <br />
            <asp:LinkButton ID="btnUpload" runat="server"
                OnClick="btnUpload_Click">파일업로드</asp:LinkButton>
            <br />
            <asp:Label ID="lblResult" runat="server"></asp:Label>
            <div>
                <asp:Label ID="LblCached" runat="server" ></asp:Label><br />
                <asp:Substitution ID="SsMain" runat="server" MethodName="GetCurrentTime" />

            </div>
            <div>
                <asp:Localize ID="LblLocal" runat="server" Text="안녕하세요"></asp:Localize>
                <br />
                <asp:Localize ID="LblLoca2" runat="server" Text="<hr /><b>안녕하세요<b/>" Mode="Transform"></asp:Localize>


            </div>


        </div>
    </form>
</body>
</html>
