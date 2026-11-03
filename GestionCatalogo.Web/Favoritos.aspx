<%@ Page Title="Mis Favoritos" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="GestionCatalogo.Web.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 style="color:#2c3e50;">Mis favoritos</h2>
    <p style="color:#708699; margin:6px 0 18px;">Los artículos que marcaste como favoritos.</p>

    <div id="sinFavoritos" runat="server" visible="false" style="color:#708699; padding:14px 0;">
        Todavía no marcaste artículos como favoritos. Entrá a uno desde el catálogo y tocá "⭐ Agregar a favoritos".
    </div>

    <div class="fichero-grid">
        <asp:Repeater ID="repFavoritos" runat="server">
            <ItemTemplate>
                <div class="tarjeta">
                    <img class="portada" src="<%# Eval("ImagenUrl") %>" alt="<%# Eval("Nombre") %>"
                         onerror="this.onerror=null; this.src='https://placehold.co/270x150?text=Sin+imagen';" />
                    <h3><%# Eval("Nombre") %></h3>
                    <div class="desc"><%# Eval("Descripcion") %></div>
                    <div class="chips">
                        <span><%# Eval("Marca") %></span>
                        <span><%# Eval("Categoria") %></span>
                    </div>
                    <div class="meta">
                        <span class="precio">$ <%# Eval("Precio", "{0:N0}") %></span>
                        <span style="display:flex; gap:8px;">
                            <a class="boton" href="DetalleArticulo.aspx?id=<%# Eval("Id") %>">Ver</a>
                            <asp:LinkButton CssClass="boton rojo" CommandArgument='<%# Eval("Id") %>' OnCommand="btnQuitar_Command"
                                OnClientClick="return confirm('¿Quitar de favoritos?');" runat="server" CausesValidation="false">Quitar ✕</asp:LinkButton>
                        </span>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
