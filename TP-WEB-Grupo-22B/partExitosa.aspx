<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="partExitosa.aspx.cs" Inherits="TP_WEB_Grupo_22B.partExitosa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .contenido{
            width:100%;
            height:50vh;
            display:flex;
            align-items:center;
            justify-content:center;
            flex-direction:column;
        }
        h1{
            margin-bottom:4rem !important;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
    <div class="contenido">
        <h1>Felicitaciones, su participación ha sido registrada con éxito!</h1>
        <a href ="Default.aspx" class="btn btn-primary">Volver al inicio</a>
    </div>
</asp:Content>
