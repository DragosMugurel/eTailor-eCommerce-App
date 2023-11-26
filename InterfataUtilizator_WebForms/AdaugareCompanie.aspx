<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdaugareCompanie.aspx.cs" Inherits="InterfataUtilizator_WebForms.AdaugareCompanie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        Adaugare Companie<br /> 
        
        <table Height="55px">
            <tr>
                <td>Nume</td>
                <td><asp:TextBox ID="txtNume" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Introduceti numele" ControlToValidate="txtNume"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="height: 22px">Email</td>
                <td style="height: 22px"><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                <td style="height: 22px"><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Introduceti email valid" ControlToValidate="txtEmail" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td>Telefon</td>
                <td><asp:TextBox ID="txtTelefon" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Adresa</td>
                <td><asp:TextBox ID="txtAdresa" runat="server"></asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnAdauga" runat="server" OnClick="btnAdauga_Click" Text="Adauga" />
                    <asp:Button ID="btnAfiseaza" runat="server" OnClick="btnAfiseaza_Click" Text="Afiseaza" CausesValidation="false" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Label ID="lblMesaj" runat="server"></asp:Label></td>
            </tr>
        </table>
        <br />
        <br />


    </asp:Panel>

</asp:Content>
