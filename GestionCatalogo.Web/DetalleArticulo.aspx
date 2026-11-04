<%@ Page Title="Detalle" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="GestionCatalogo.Web.DetalleArticulo" %>
<%@ Import Namespace="negocio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:PlaceHolder ID="phDetalle" runat="server">
        <div style="display:flex; gap:30px; flex-wrap:wrap; align-items:flex-start;">
            <img id="imgPortada" runat="server" style="width:420px; max-width:100%; height:280px; object-fit:cover; border-radius:12px; background:#eef2f6;" alt="Imagen del artículo" />
            <div style="flex:1; min-width:280px;">
                <h1 id="lblNombre" runat="server" style="color:#2c3e50;"></h1>
                <p><asp:Label ID="lblDescripcion" runat="server" ForeColor="#6b7684"></asp:Label></p>
                <p style="margin-top:14px;">
                    <span style="color:#54657c; font-size:.85rem;">Código:</span> <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                </p>
                <p>
                    <span style="color:#54657c; font-size:.85rem;">Marca:</span> <asp:Label ID="lblMarca" runat="server"></asp:Label>
                </p>
                <p>
                    <span style="color:#54657c; font-size:.85rem;">Categoría:</span> <asp:Label ID="lblCategoria" runat="server"></asp:Label>
                </p>
                <p style="margin-top:18px;">
                    <span class="precio" style="font-weight:700; color:#1d8348; font-size:1.5rem;"><asp:Label ID="lblPrecio" runat="server"></asp:Label></span>
                </p>
                <p style="margin-top:20px; display:flex; gap:10px;">
                    <a class="boton" href="Default.aspx" style="background:#64748b; color:white; padding:10px 20px; border-radius:8px; text-decoration:none;">← Volver al catálogo</a>
                    <% if (Seguridad.sesionActiva(Session["user"])) { %>
                        <asp:Button ID="btnFavorito" runat="server" CausesValidation="false" CssClass="boton fav" OnClick="btnFavorito_Click" style="padding:10px 20px; border-radius:8px; border:none; cursor:pointer;" />
                    <% } %>
                </p>
            </div>
        </div>
    </asp:PlaceHolder>

    <div id="divNoEncontrado" runat="server" visible="false" class="mensaje-error">El artículo solicitado no existe.</div>

</asp:Content>
