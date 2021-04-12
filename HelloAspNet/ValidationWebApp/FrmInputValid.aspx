<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmInputValid.aspx.cs" Inherits="ValidationWebApp.FrmInputValid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>유효성검사</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>범위 확인 유효성 검사 컨트롤</h3>

            <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
            <asp:RangeValidator ID="valAge" runat="server"
                ControlToValidate="txtAge"
                ErrorMessage="나이는 1~150 사이의 정수입니다."
                MinimumValue="1" MaximumValue="150" Type="Integer"
                Display="Static"
                SetFocusOnError="true"></asp:RangeValidator>
            <br />

            <asp:TextBox ID="txtScore" runat="server"></asp:TextBox>
            <asp:RangeValidator ID="valScore" runat="server"
                ControlToValidate="txtScore"
                ErrorMessage="학점은 A부터 F까지입니다."
                MinimumValue="A" MaximumValue="F" Type="String"></asp:RangeValidator>
            <br />

            <asp:TextBox ID="TxtUserId" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ValUserId" runat="server" ControlToValidate="TxtUserId"
                ErrorMessage="아이디를 입력하세요" Display="Dynamic" ForeColor="Yellow"></asp:RequiredFieldValidator>(필수)<br />
            <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ValPassword" runat="server" ControlToValidate="TxtPassword"
                ErrorMessage="암호를 입력하세요" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>(필수)<br />
            <asp:TextBox ID="txtPasswordConfirm" runat="server"
                TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="varPasswordConfirm" runat="server"
                ControlToValidate="txtPasswordConfirm"
                ControlToCompare="TxtPassword"
                SetFocusOnError="true"
                ErrorMessage="암호를 다시 확인해 주세요."></asp:CompareValidator>
            <hr />
            <asp:Button ID="btnConfirm" runat="server" Text="확인" />

            <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" Text="로그인" />


            <h3>정규식 확인 유효성 검사 컨트롤</h3>
            이메일:
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="valEmail" runat="server"
                ErrorMessage="이메일을 정확히 입력하시오."
                ControlToValidate="txtEmail"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br />
            홈페이지:
    <asp:TextBox ID="txtHomePage" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="valHomePage" runat="server"
                ErrorMessage="홈페이지를 정확히 입력하시오."
                ControlToValidate="txtHomePage"
                ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"></asp:RegularExpressionValidator>
            <hr />
            <asp:LinkButton ID="btnOK" runat="server" >확인</asp:LinkButton>
            <asp:Label ID="LblOk" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>
