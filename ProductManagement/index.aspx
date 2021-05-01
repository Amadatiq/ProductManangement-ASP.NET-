<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ProductManagement.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hfProductID" runat="server" />
            <table>
                <tr>
                    <td>
                        <asp:Label Text="Product" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtProduct" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Price" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtPrice" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Count" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtCount" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Description" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtDescription" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td colspan="3" class="auto-style1">
                        <asp:Button Text="Save" ID="btSave" runat="server" OnClick="btSave_Click"/>
                        <asp:Button Text="Delete" ID="btDelete" runat="server" OnClick="btDelete_Click" />
                        <asp:Button Text="Clear" ID="btClear" runat="server" OnClick="btClear_Click" />
                    </td>
                </tr>
                
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label Text="" ID="lblSuccessMessage" runat="server" ForeColor="Green" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label Text="" ID="lblErrorMessage" runat="server" ForeColor="Red" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="false" Width="248px"> 
                <Columns>
                    <asp:BoundField DataField="Product" HeaderText="Product" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="Count" HeaderText="Count" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton Text="Select" ID="lnkSelect" CommandArgument='<%# Eval("ProductID") %>' runat="server" OnClick="lnkSelect_OnClick"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
