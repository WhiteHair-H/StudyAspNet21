<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmRichControls.aspx.cs" Inherits="FirstWebApp.FrmRichControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Calendar runat="server" ID="CalMain" BackColor="Yellow" BorderColor="Orange"
                BorderWidth="1px" DayHeaderStyle-BackColor="Turquoise" OnSelectionChanged="CalMain_SelectionChanged"></asp:Calendar>
        </div>
    </form>
</body>
</html>
