<%@ Page Title="Administración" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PanelArticulos.aspx.cs" Inherits="GestionCatalogo.Web.admin.PanelArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div style="display:flex; justify-content:space-between; align-items:center; margin-bottom:14px;">
        <h2 style="color:#2c3e50;">Administración de artículos</h2>
        <a class="boton" href="FormularioArticulo.aspx">+ Agregar artículo</a>
    </div>

    <div id="divAcceso" runat="server" class="mensaje-error" visible="false">Acceso restringido: esta sección es solo para administradores.</div>

    <asp:PlaceHolder ID="phPanel" runat="server">
        <table class="tabla-grilla">
            <thead>
                <tr>
                    <th>Imagen</th>
                    <th>Código</th>
                    <th>Nombre</th>
                    <th>Marca</th>
                    <th>Categoría</th>
                    <th>Precio</th>
                    <th style="text-align:center;">Acciones</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="repArticulos" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><img class="mini" src="<%# !string.IsNullOrEmpty((string)Eval("ImagenUrl")) ? (string)Eval("ImagenUrl") : "https://placehold.co/52x40?text=..." %>" alt="" onerror="this.onerror=null; this.src='https://placehold.co/52x40?text=...';" /></td>
                            <td><%# Eval("Codigo") %></td>
                            <td><%# Eval("Nombre") %></td>
                            <td><%# Eval("Marca") %></td>
                            <td><%# Eval("Categoria") %></td>
                            <td>$ <%# Eval("Precio", "{0:N0}") %></td>
                            <td style="text-align:center; white-space:nowrap;">
                                <a href="FormularioArticulo.aspx?id=<%# Eval("Id") %>" style="color:#2980b9; text-decoration:none;">Modificar</a> |
                                <asp:LinkButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="btnEliminar_Command" OnClientClick="return confirm('¿Eliminar este artículo?');" style="color:#c0392b; text-decoration:none;">Eliminar</asp:LinkButton>
                                | <a href='DetalleArticulo.aspx?id=<%# Eval("Id") %>' style="color:#54657c; text-decoration:none;">Ver</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </asp:PlaceHolder>

</asp:Content>
