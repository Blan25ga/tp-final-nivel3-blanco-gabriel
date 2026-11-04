<%@ Page Title="Panel de Artículos" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PanelArticulos.aspx.cs" Inherits="GestionCatalogo.Web.admin.PanelArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="color:#2c3e50;">Panel de administración</h2>
    <p style="color:#708699; margin:6px 0 18px;">Gestioná los artículos del catálogo.</p>
    <div id="divAcceso" runat="server" visible="false" class="mensaje-error">
        <p>Acceso restringido. Debías iniciar sesión como administrador.</p>
        <a href="~/Login.aspx">Iniciar sesión</a>
    </div>
    <div runat="server" id="phPanel" visible="true">
        <div style="display:flex; justify-content:space-between; align-items:center; margin-bottom:16px; flex-wrap:wrap; gap:10px;">
            <a href="FormularioArticulo.aspx" style="padding:8px 14px; background:#2c3e50; color:#fff; text-decoration:none; border-radius:8px;">Nuevo artículo</a>
            <div style="color:#708699; font-size:.85rem;">
                <asp:Label ID="lblPaginacion" runat="server" Text="Página 1 de 1"></asp:Label>
            </div>
        </div>
        <div style="overflow-x:auto;">
            <table class="tabla" style="width:100%; border-collapse:collapse; min-width:800px;">
                <thead>
                    <tr style="background:#2c3e50; color:#fff;">
                        <th style="padding:10px; text-align:left; cursor:pointer;" commandname="Ordenar" commandargument="Nombre">Nombre <asp:Label ID="lblNombreSort" runat="server"></asp:Label></th>
                        <th style="padding:10px; text-align:left; cursor:pointer;" commandname="Ordenar" commandargument="Marca">Marca <asp:Label ID="lblMarcaSort" runat="server"></asp:Label></th>
                        <th style="padding:10px; text-align:left; cursor:pointer;" commandname="Ordenar" commandargument="Precio">Precio <asp:Label ID="lblPrecioSort" runat="server"></asp:Label></th>
                        <th style="padding:10px; text-align:left; cursor:pointer;" commandname="Ordenar" commandargument="Categoria">Categoría <asp:Label ID="lblCategoriaSort" runat="server"></asp:Label></th>
                        <th style="padding:10px; text-align:right;">Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="repArticulos" runat="server">
                        <ItemTemplate>
                            <tr style="border-bottom:1px solid #e2e8f0;">
                                <td style="padding:10px;"><%# Eval("Nombre") %></td>
                                <td style="padding:10px;"><%# Eval("Marca") %></td>
                                <td style="padding:10px; text-align:right;">$ <%# Eval("Precio", "{0:N0}") %></td>
                                <td style="padding:10px;"><%# Eval("Categoria") %></td>
                                <td style="padding:10px; text-align:center;">
                                    <a class="boton" href="FormularioArticulo.aspx?id=<%# Eval("Id") %>" style="padding:4px 8px; border:1px solid #cbd5e1; border-radius:6px; text-decoration:none; color:#54657c; font-size:.82rem;">Editar</a>
                                    <a class="boton-eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' style="padding:4px 8px; border:1px solid #f56565; border-radius:6px; text-decoration:none; color:#fff; font-size:.82rem; background:#fef2f2;">Eliminar</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <div style="display:flex; justify-content:center; gap:10px; margin-top:20px; align-items:center;">
            <asp:LinkButton ID="btnPaginaPrimera" runat="server" CommandArgument="1">|<</asp:LinkButton>
            <asp:LinkButton ID="btnPaginaAnterior" runat="server" CommandArgument="0" Enabled="false">Anterior</asp:LinkButton>
            <asp:Label ID="lblPaginacion" runat="server" Text="Página 1 de 1"></asp:Label>
            <asp:LinkButton ID="btnPaginaSiguiente" runat="server" CommandArgument="1">Siguiente</asp:LinkButton>
            <asp:LinkButton ID="btnPaginaUltima" runat="server" CommandArgument="99">>|</asp:LinkButton>
        </div>
    </div>
</asp:Content>