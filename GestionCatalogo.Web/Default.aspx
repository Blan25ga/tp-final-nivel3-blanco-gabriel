<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GestionCatalogo.Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 style="color:#2c3e50;">Catálogo de productos</h2>
    <p style="color:#708699; margin:6px 0 18px;">Explorá el catálogo y filtrá por nombre, marca, categoría o precio.</p>

    <div id="alertaError" runat="server" class="mensaje-error" visible="false"></div>

    <div style="display:flex; flex-wrap:wrap; gap:12px; align-items:flex-end; margin-bottom:22px;">
        <div>
            <label style="display:block; font-size:.82rem; color:#54657c;">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" placeholder="Buscar..." AutoPostBack="true" OnTextChanged="txtNombre_TextChanged" style="padding:8px 10px; border:1px solid #cbd5e1; border-radius:8px;"></asp:TextBox>
        </div>
        <div>
            <label style="display:block; font-size:.82rem; color:#54657c;">Marca</label>
            <asp:DropDownList ID="ddlMarca" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged" style="min-width:130px; padding:8px; border:1px solid #cbd5e1; border-radius:8px;"></asp:DropDownList>
        </div>
        <div>
            <label style="display:block; font-size:.82rem; color:#54657c;">Categoría</label>
            <asp:DropDownList ID="ddlCategoria" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" style="min-width:130px; padding:8px; border:1px solid #cbd5e1; border-radius:8px;"></asp:DropDownList>
        </div>
        <div>
            <label style="display:block; font-size:.82rem; color:#54657c;">Precio máx.</label>
            <asp:TextBox ID="txtPrecioMax" runat="server" AutoPostBack="true" OnTextChanged="txtPrecioMax_TextChanged" placeholder="Ej: 1000" style="width:110px; padding:8px 10px; border:1px solid #cbd5e1; border-radius:8px;"></asp:TextBox>
        </div>
        <a href="Default.aspx" style="padding:8px 14px; border:1px solid #cbd5e1; border-radius:8px; text-decoration:none; color:#54657c; font-size:.85rem;">Limpiar</a>
    </div>

    <div id="divCargando" runat="server" style="display:none; text-align:center; padding:40px; color:#708699;">
        <div class="cargando">
            <div class="caja"></div>
            <span>Cargando artículos...</span>
        </div>
    </div>

    <div class="fichero-grid">
        <asp:Repeater ID="repArticulos" runat="server">
            <ItemTemplate>
                <div class="tarjeta">
                    <img class="portada" src="<%# Eval("ImagenUrl") %>" alt="<%# Eval("Nombre") %>" onerror="this.onerror=null; this.src='https://placehold.co/270x150?text=Sin+imagen';" />
                    <h3><%# Eval("Nombre") %></h3>
                    <div class="desc"><%# Eval("Descripcion") %></div>
                    <div class="chips">
                        <span><%# Eval("Marca") %></span>
                        <span><%# Eval("Categoria") %></span>
                    </div>
                    <div class="meta">
                        <span class="precio">$ <%# Eval("Precio", "{0:N0}") %></span>
                        <a class="boton" href="DetalleArticulo.aspx?id=<%# Eval("Id") %>">Ver</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <p id="sinResultados" runat="server" visible="false" style="color:#708699; padding:20px 0;">No encontramos artículos con esos filtros.</p>

    <div style="display:flex; justify-content:center; gap:10px; margin-top:20px; align-items:center;">
        <asp:LinkButton ID="btnPaginaAnterior" runat="server" CommandArgument="0" OnClick="btnPaginaAnterior_Click" Enabled="false">Anterior</asp:LinkButton>
        <asp:Label ID="lblPaginacion" runat="server" Text="Página 1 de 1"></asp:Label>
        <asp:LinkButton ID="btnPaginaSiguiente" runat="server" CommandArgument="1" OnClick="btnPaginaSiguiente_Click">Siguiente</asp:LinkButton>
    </div>

</asp:Content>
