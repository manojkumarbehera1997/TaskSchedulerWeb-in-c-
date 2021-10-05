<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskScheduler.aspx.cs" Inherits="TaskSchedulerWeb.TaskScheduler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Task Scheduler</h1>
        <div>
            <table>
                <tr>
                    <td>Program Name:</td>
                    <td>
                        <asp:TextBox ID="txtProgramName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Start Date:</td>
                    <td>
                        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Time</td>
                    <td>
                        <asp:TextBox ID="txtTime" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Create" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
