<%@ Page Title="Crear cuenta" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="GestionCatalogo.Web.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="formularios">
        <h2>Crear cuenta</h2>

        <div id="divMensaje" runat="server" class="mensaje-error" visible="false"></div>

        <label>Email</label>
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" placeholder="ej. email@dominio.com"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
            ErrorMessage="Formato de email inválido." CssClass="error-texto" Display="Dynamic"
            ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
            CssClass="error-texto" Display="Dynamic" ErrorMessage="Debes completar el email."></asp:RequiredFieldValidator>

        <label>Contraseña</label>
        <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
        <asp:CustomValidator ID="cvPass" runat="server" ControlToValidate="txtPass"
            CssClass="error-texto" Display="Dynamic" ErrorMessage="La contraseña debe tener al menos 4 caracteres."
            OnServerValidate="validarPass"></asp:CustomValidator>

        <label>Repetir contraseña</label>
        <asp:TextBox ID="txtRePass" runat="server" TextMode="Password"></asp:TextBox>
        <asp:CompareValidator ID="cuvPass" runat="server" ControlToValidate="txtRePass" ControlToCompare="txtPass"
            CssClass="error-texto" Display="Dynamic" ErrorMessage="Las contraseñas no coinciden."></asp:CompareValidator>

        <p style="margin-top:22px;">
            <asp:Button ID="btnCrear" runat="server" Text="Crear cuenta" CssClass="boton" OnClick="btnCrear_Click" />
            <a href="Login.aspx" style="margin-left:14px; color:#2980b9;">¿Ya tenés cuenta? Ingresar</a>
        </p>
    </div>
</asp:Content>
