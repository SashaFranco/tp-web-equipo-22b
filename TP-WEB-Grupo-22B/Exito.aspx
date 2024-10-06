<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Exito.aspx.cs" Inherits="TP_WEB_Grupo_22B.Exito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .author-info {
            margin-bottom: 30px;
        }

            .author-info a {
                color: #007bff;
                text-decoration: none;
            }

                .author-info a:hover {
                    text-decoration: underline;
                }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <h1 class="my-5">Autores del Proyecto</h1>

        <div class="author-info">
            <h3>Catalina Avila Rotela, legajo: 24464</h3>
            <p>
                <a href="https://github.com/cataAvi" target="_blank">Link de GitHub de Catalina</a>
            </p>
        </div>

        <div class="author-info">
            <h3>Jorge Samuel Villalba, legajo: 26184</h3>
            <p>
                <a href="https://github.com/SamuelVillalba7" target="_blank">Link de GitHub de Samuel</a>
            </p>
        </div>

        <div class="author-info">
            <h3>Sasha Emanuel Franco, legajo: 27984</h3>
            <p>
                <a href="https://github.com/SashaFranco" target="_blank">Link de GitHub de Sasha</a>
            </p>
        </div>

    </div>
</asp:Content>

