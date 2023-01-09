<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="EmployeeApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <div class="jumbotron">
    <h1>Welcome to Cybage Assignment</h1>
  </div>
  <br />
  <asp:Panel ID="Panel1" runat="server" GroupingText="Employee Application" Font-Italic="True" ForeColor="Blue">
  </asp:panel>
  <br />
  <table border='0' width='480px' cellpadding='0' cellspacing='0' align='center'>
    <tr>
      <td align='center'>Name:</td>
      <td>
        <asp:textbox id="name" runat="server"></asp:textbox>
      </td>
      <td>
        <asp:RequiredFieldValidator ID="validuser" runat="server" ControlToValidate="name" ErrorMessage="Required!" ForeColor="Red" ValidationGroup="First"></asp:RequiredFieldValidator>
      </td>
    </tr>
    <tr>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td align='center'>Email:</td>
      <td>
        <asp:TextBox ID="email" runat="server" TextMode="Email"></asp:TextBox>
      </td>
      <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="email" ErrorMessage="Required!" ForeColor="Red" ValidationGroup="First"></asp:RequiredFieldValidator>
      </td>
      <td>
        <asp:RequiredFieldValidator ID="validemail" runat="server" ControlToValidate="email" ErrorMessage="Required!" ForeColor="Red" ValidationGroup="second"></asp:RequiredFieldValidator>
      </td>
    </tr>
    <tr>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td align='center'>Address:</td>
      <td>
        <asp:TextBox ID="address" runat="server" TextMode="MultiLine"></asp:TextBox>
      </td>
      <td>
        <asp:RequiredFieldValidator ID="validaddress" runat="server" ControlToValidate="address" ErrorMessage="Required!" ForeColor="Red" ValidationGroup="First"></asp:RequiredFieldValidator>
      </td>
    </tr>
    <tr>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td align='center'>Contact No:</td>
      <td>
        <asp:TextBox ID="contact" runat="server" TextMode="Phone"></asp:TextBox>
      </td>
      <td>
        <asp:RequiredFieldValidator ID="validmobile" runat="server" ErrorMessage="Required!" ForeColor="Red" ControlToValidate="contact" ValidationGroup="First"></asp:RequiredFieldValidator>
      </td>
      <td>
        <asp:RegularExpressionValidator ID="validatemobile" runat="server" ErrorMessage="Invalid Mobile Number." ValidationExpression="[0-9]{10}" ControlToValidate="contact" ValidationGroup="First" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
      </td>
    </tr>
    <tr>
      <td>&nbsp;</td>
    </tr>
  </table>
  <table border='0' cellpadding='0' cellspacing='0' width='480px' align='center'>
    <tr>
      <td align='left'>
        <asp:Button ID="btn1" runat="server" Text="Add/Update" BackColor="Lime" BorderColor="Lime" ForeColor="Black" OnClick="Savebtn_Click" ValidationGroup="First"></asp:Button>
        <asp:Button ID="btn2" runat="server" Text="Delete" BackColor="Red" BorderColor="Red" ForeColor="White" OnClick="Deletebtn_Click" ValidationGroup="second"></asp:Button>
        <asp:Button ID="btn3" runat="server" Text="Show" BackColor="#99CCFF" BorderColor="#0000CC" ForeColor="#0000CC" OnClick="Showbtn_Click" ValidationGroup="second"></asp:Button>
      </td>
    </tr>
  </table>
  <br />
  <br />
  <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" style="margin-right: 602px; margin-left: 0px;" Width="761px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
    <Columns>
      <asp:ButtonField CommandName="Select" HeaderText="View" ShowHeader="True" Text="view" />
    </Columns>
    <FooterStyle BackColor="White" ForeColor="#333333" />
    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="White" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F7F7F7" />
    <SortedAscendingHeaderStyle BackColor="#487575" />
    <SortedDescendingCellStyle BackColor="#E5E5E5" />
    <SortedDescendingHeaderStyle BackColor="#275353" />
  </asp:GridView>
</asp:Content>



