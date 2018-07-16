<%@ Page Title="Iniciar sesión en MiAgenda" Language="C#" MasterPageFile="~/Early.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MiAgenda.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="align-center-h" style="margin-top: 50px">
        <div class="card">
            <div class="card-body">
                <asp:Login runat="server" ID="loginForm" OnAuthenticate="loginForm_Authenticate" />
            </div>
            <div class="card-footer">
                <div class="align-center-h">
                    <a class="nav-link" href="Registrar.aspx">¿No tienes cuenta? ¡Regístrate!</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
