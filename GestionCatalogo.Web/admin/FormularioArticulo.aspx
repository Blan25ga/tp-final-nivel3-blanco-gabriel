<%@ Page Title="Formulario artículo" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="GestionCatalogo.Web.admin.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="formularios" style="max-width:560px; text-align:left;">
        <h2 id="tituloPantalla" runat="server">Agregar artículo</h2>

        <div id="divAcceso" runat="server" class="mensaje-error" visible="false">Acceso restringido: esta sección es solo para administradores.</div>

        <asp:PlaceHolder ID="phForm" runat="server">
            <label>Código *</label>
            <asp:TextBox ID="txtCodigo" runat="server" MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCodigo" CssClass="error-texto" Display="Dynamic" ErrorMessage="El código es obligatorio."></asp:RequiredFieldValidator>

            <label>Nombre *</label>
            <asp:TextBox ID="txtNombre" runat="server" MaxLength="80"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre" CssClass="error-texto" Display="Dynamic" ErrorMessage="El nombre es obligatorio."></asp:RequiredFieldValidator>

            <label>Descripción</label>
            <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="3" MaxLength="300"></asp:TextBox>

            <label>Marca *</label>
            <asp:DropDownList ID="ddlMarca" runat="server"></asp:DropDownList>
            <asp:CustomValidator runat="server" ID="cvMarca" CssClass="error-texto" Display="Dynamic" ErrorMessage="Debes elegir una marca." OnServerValidate="validarMarca"></asp:CustomValidator>

            <label>Categoría *</label>
            <asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList>
            <asp:CustomValidator runat="server" ID="cvCategoria" CssClass="error-texto" Display="Dynamic" ErrorMessage="Debes elegir una categoría." OnServerValidate="validarCategoria"></asp:CustomValidator>

            <label>URL de imagen</label>
            <asp:TextBox ID="txtImagenUrl" runat="server" MaxLength="300"></asp:TextBox>
            <div style="margin-top:8px;">
                <img id="imgPrevisualizacion" runat="server" style="width:220px; height:130px; object-fit:cover; border-radius:8px; background:#eef2f6;" alt="Previsualización" onerror="this.onerror=null; this.src='https://placehold.co/220x130?text=Sin+imagen';" />
            </div>

            <label>Precio *</label>
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            <asp:CustomValidator runat="server" ID="cvPrecio" CssClass="error-texto" Display="Dynamic" ErrorMessage="El precio debe ser numérico y no negativo." OnServerValidate="validarPrecio"></asp:CustomValidator>

<p style="margin-top:22px; display:flex; gap:12px;">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="boton" OnClick="btnAceptar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="boton rojo" OnClick="btnCancelar_Click" CausesValidation="false" />
            </p>
            <p>
                <a href="FormularioArticulo.aspx?id=<%# Eval("Id") %>" style="color:#c0392b; text-decoration:none;">Eliminar artículo</a>
            </p>
        </asp:PlaceHolder>
    </div>
</asp:Content>
