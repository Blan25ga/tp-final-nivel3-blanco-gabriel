<%@ Page Title="Mi Perfil" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="GestionCatalogo.Web.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="formularios">
        <h2>Mi Perfil</h2>

        <div id="divMensaje" runat="server" class="mensaje-error" visible="false"></div>

        <label>Email</label>
        <asp:TextBox ID="txtEmail" runat="server" Enabled="false" BackColor="#eef2f6"></asp:TextBox>

        <label>Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
            CssClass="error-texto" Display="Dynamic" ErrorMessage="El nombre es obligatorio."></asp:RequiredFieldValidator>

        <label>Apellido</label>
        <asp:TextBox ID="txtApellido" runat="server" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido"
            CssClass="error-texto" Display="Dynamic" ErrorMessage="El apellido es obligatorio."></asp:RequiredFieldValidator>

        <label>Contraseña (dejar en blanco para no cambiarla)</label>
        <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
        <asp:CustomValidator ID="cvPass" runat="server" ControlToValidate="txtPass"
            CssClass="error-texto" Display="Dynamic" ErrorMessage="La contraseña debe tener al menos 4 caracteres."
            OnServerValidate="validarPass"></asp:CustomValidator>

        <label>URL de imagen de perfil</label>
        <asp:TextBox ID="txtImagenPerfil" runat="server" MaxLength="300"></asp:TextBox>

        <div style="margin-top:10px;">
            <img id="imgPerfil" runat="server" style="width:110px; height:110px; object-fit:cover; border-radius:50%; background:#eef2f6;" alt="Foto de perfil"
                 onerror="this.onerror=null; this.src='https://placehold.co/110x110?text=%3A%29';" />
        </div>

        <p style="margin-top:22px;">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" CssClass="boton" OnClick="btnGuardar_Click" />
        </p>
    </div>
</asp:Content>
