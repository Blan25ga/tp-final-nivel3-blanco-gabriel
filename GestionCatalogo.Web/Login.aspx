<%@ Page Title="Ingresar" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GestionCatalogo.Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="formularios">
        <h2>Iniciar sesión</h2>

        <div id="divMensaje" runat="server" class="mensaje-error" visible="false"></div>

        <label>Nombre de usuario (email)</label>
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" placeholder="ej. email@dominio.com" MaxLength="50"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
            ErrorMessage="Formato de email inválido." CssClass="error-texto" Display="Dynamic"
            ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" CssClass="error-texto" Display="Dynamic" ErrorMessage="Debes completar el email."></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revEmailMax" runat="server" ControlToValidate="txtEmail"
            MaxLength="50"></asp:RegularExpressionValidator>

        <label>Contraseña</label>
        <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPass" runat="server" ControlToValidate="txtPass" CssClass="error-texto" Display="Dynamic" ErrorMessage="Debes completar la contraseña."></asp:RequiredFieldValidator>

        <p style="margin-top:20px; display:flex; gap:8px; align-items:center;">
            <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="boton" OnClick="btnLogin_Click" />
            <a href="Registro.aspx" style="color:#2980b9;">¿No tenés cuenta? Crear una</a>
        </p>
    </div>
</asp:Content>
