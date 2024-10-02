<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="TP_WEB_Grupo_22B.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-2">
            </div>

            <div class="col formulario">

                <div class="mb-3 div-Dni">
                    <label for="txtDni" class="form-label">Dni</label>
                    <asp:TextBox ID="txtDni" AutoPostBack="true" placeholder="45234543" CssClass="form-control" runat="server" OnTextChanged="txtDni_TextChanged"></asp:TextBox>
                </div>


                <div class="form-container1">
                    <div class="mb-3 div-Nombre">
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <asp:TextBox ID="txtNombre" placeholder="Nombre" CssClass="form-control" runat="server"></asp:TextBox>

                    </div>
                    <div class="mb-3 div-Apellido">
                        <label for="txtApellido" class="form-label">Apellido</label>
                        <asp:TextBox ID="txtApellido" placeholder="Apellido" CssClass="form-control" runat="server"></asp:TextBox>

                    </div>

                    <div class="div-Email">
                        <label for="txtEmail" class="form-label">Email</label>
                        <div class="input-group mb-3 ">
                            <span class="input-group-text" id="basic-addon1">@</span>
                            <asp:TextBox ID="txtEmail" type="email" placeholder="email@email.com" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="form-container2">
                    <div class="mb-3 div-Direccion">
                        <label for="txtDireccion" class="form-label">Direccion</label>
                        <asp:TextBox ID="txtDireccion" placeholder="Calle 123" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3 div-Ciudad">
                        <label for="txtCiudad" class="form-label">Ciudad</label>
                        <asp:TextBox ID="txtCiudad" placeholder="Mi Ciudad" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3 div-CP ">
                        <label for="txtCP" class="form-label">CP</label>
                        <asp:TextBox ID="txtCP" type="number" placeholder="xxxx" CssClass="form-control" runat="server"></asp:TextBox>

                    </div>

                </div>

                <div class="mb-3">
                    <div class="form-check">
                        <input class="form-check-input" type="checkbox" id="Check">
                        <label class="form-check-label" for="Check">
                            Acepto los terminos y condiciones.
                        </label>
                    </div>
                </div>
                <asp:Button ID="btnParticipar" OnClick="Button1_Click" CssClass="btn btn-primary" runat="server" Text="Participar!" />


            </div>


            <div class="col-2"></div>
        </div>
    </div>

</asp:Content>
