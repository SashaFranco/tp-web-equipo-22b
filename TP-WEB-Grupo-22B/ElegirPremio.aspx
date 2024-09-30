<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ElegirPremio.aspx.cs" Inherits="TP_WEB_Grupo_22B.ElegirPremio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%foreach (dominio.Articulo art in ListaArticulo)
            { %>

        <div class="col">
            <div class="card h-100">
                <img src="<%: art.Imagen %>" class="card-img-top" alt="..." height ="400px">
                <div class="card-body">
                    <h5 class="card-title"><%: art.Nombre %></h5>
                    <p class="card-text"><%: art.Descripcion %></p>
                    <a href="Formulario.aspx?id=<%:art.Id %>">Elegir</a>
                </div>
            </div>
        </div>

        <% }%>

    </div>

</asp:Content>
