﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_WEB_Grupo_22B.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex flex-column justify-content-center align-items-center vh-100 text-center">
        <h1>Bienvenido, haga click en el boton "Ir a Voucher" o ingrese a la seccion "Canjear Codigo" para participar por premios!</h1>
        <img src="https://paytechlaw.com/wp-content/uploads/190414_Corona-Voucher_Artenauta.png" class="img-fluid my-3" alt="Promoción">
        <asp:Button href="CanjearCodigo.aspx" Text="Ir a Vouchers" ID ="btnVoucher" CssClass="btn btn-primary mt-3" OnClick="btnVoucher_Click" runat="server" />
    </div>
</asp:Content>

