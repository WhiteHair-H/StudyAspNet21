<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmPage.aspx.cs" Inherits="TempleteWebApp.FrmPage" %>

<%@ Register Src="~/Navigator.ascx" TagPrefix="Nav" TagName="Navigator" %>
<%@ Register Src="~/CopyWriter.ascx" TagPrefix="Cop" TagName="CopyWriter" %>
<%@ Register Src="~/Categories.ascx" TagPrefix="Cat" TagName="Categories" %>
<%@ Register Src="~/Catalog.ascx" TagPrefix="tal" TagName="Catalog" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>웹사이트 뼈대</title>
    <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12" style="background-color: royalblue">
                    <Nav:Navigator runat="server" ID="NavMain" />
                </div>
            </div>
            <div class="row" style="height: 200px;">
                <div class="col-md-4" style="background-color: aquamarine">
                    <Cat:Categories runat="server" ID="CatM" />
                </div>
                <div class="col-md-8" style="background-color: coral">
                    <tal:Catalog runat="server" ID="talM" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12" style="background-color: darkcyan">
                    <Cop:CopyWriter runat="server" ID="CopM" />
                </div>
            </div>
        </div>

    </form>
</body>
</html>
