<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmControls.aspx.cs" Inherits="FirstWebApp.FrmControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>대체 컨트롤</title>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="CtlHidden" runat="server" />
            <asp:Button ID="BtnOk" runat="server" Text="히든필드값 출력" OnClick="BtnOk_Click" /><br />

            <asp:HyperLink ID="LnkMicrosoft" NavigateUrl="https://www.microsoft.com" Text="MS" runat="server" ></asp:HyperLink>

            <asp:Image ID="ImgChange" runat="server" ImageUrl="~/img/ASP-NET-Banners-01.png" />
            <asp:Button ID="BtnChage" runat="server" OnClick="BtnChage_Click"  Text="이미지 변경"/>

            <br />

            <asp:DropDownList ID="CboPhoneNum" runat="server">
                <asp:ListItem Text="010"></asp:ListItem>
                <asp:ListItem>019</asp:ListItem>
                <asp:ListItem Value ="018"></asp:ListItem>
                <asp:ListItem Value ="011" Text="011"></asp:ListItem>
            </asp:DropDownList>

            <asp:ListBox ID="LsbHobby" runat="server">
                <asp:ListItem Text="축구"></asp:ListItem>
                <asp:ListItem Text="야구"></asp:ListItem>
                <asp:ListItem Text="농구"></asp:ListItem>
                <asp:ListItem Text="당구"></asp:ListItem>
            </asp:ListBox>





        </div>
    </form>
</body>
</html>
