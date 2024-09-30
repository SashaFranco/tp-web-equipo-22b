<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CanjearCodigo.aspx.cs" Inherits="TP_WEB_Grupo_22B.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Ingresa el código del voucher!</label>
                <input class="form-control" id="exampleFormControlInput1" placeholder="XXXXXXXX">
            </div>
            <div class="col-auto">
                <asp:Button Text="Siguiente" CssClass="btn btn-primary mb-3" ID ="btnSiguiente" OnClick ="btnSiguiente_Click" runat="server"/>
            </div>
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
