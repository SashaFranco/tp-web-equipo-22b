<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ElegirPremio.aspx.cs" Inherits="TP_WEB_Grupo_22B.ElegirPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <% foreach (dominio.Articulo art in ListaArticulo)
            { %>
        <div class="col">
            <div class="card h-100">
                <% if (art.Imagenes != null && art.Imagenes.Count > 1)
                    { %>
                <div id="carousel<%: art.Id %>" class="carousel slide" data-bs-ride="carousel">
                    <div class="carousel-inner">
                        <% for (int i = 0; i < art.Imagenes.Count; i++)
                            { %>
                        <div class="carousel-item <%: (i == 0 ? "active" : "") %>">
                            <img src="<%: art.Imagenes[i] %>" class="d-block w-100" height="400px" alt="...">
                        </div>
                        <% } %>
                    </div>
                    <button class="carousel-control-prev" type="button" data-bs-target="#carousel<%: art.Id %>" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carousel<%: art.Id %>" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>
                <% }
                else
                { %>
                <img src="<%: art.Imagen %>" class="card-img-top" alt="..." height="400px">
                <% } %>
                <div class="card-body">
                    <h5 class="card-title"><%: art.Nombre %></h5>
                    <p class="card-text"><%: art.Descripcion %></p>
                    <a href="Formulario.aspx?id=<%: art.Id %>" class="btn btn-primary">Elegir</a>
                </div>
            </div>
        </div>
        <% } %>
    </div>
</asp:Content>

