<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KVDataBoundDDL.Location" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--OnSelectedIndexChanged is a cached event so set auto postback to true so the page will refresh and show countries DDL --%>
            <asp:DropDownList ID="ddlContinents" width="200px" runat="server" AutoPostBack ="true"
                datatextfield="ContinentName" datavaluefield="ContinentId" OnSelectedIndexChanged="ddlContinents_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <asp:DropDownList ID="ddlCountries" width="200px" runat="server" AutoPostBack="true" 
                datatextfield="CountryName" datavaluefield="CountryId" OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <asp:DropDownList ID="ddlCities" width="200px" runat="server"
                datatextfield="CityName" datavaluefield="CityId">
            </asp:DropDownList>
            <br />
        </div>
    </form>
</body>
</html>
