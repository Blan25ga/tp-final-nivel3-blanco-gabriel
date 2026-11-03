<%@ Page Title="Error" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="GestionCatalogo.Web.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="formularios" style="max-width:600px;">
        <h2>⚠️ Oops, ocurrió un error</h2>
        <div class="mensaje-error" style="white-space:pre-wrap; word-break:break-word;">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </div>
        <a class="boton" href="Default.aspx">← Volver al inicio</a>
    </div>
</asp:Content>
