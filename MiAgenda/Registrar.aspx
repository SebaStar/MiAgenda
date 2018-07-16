<%@ Page Title="Registrarse - MiAgenda" Language="C#" MasterPageFile="~/Early.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="MiAgenda.Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="align-center-h" style="padding: 50px">
        <div class="card">
            <div class="card-header">
                Registrarse en MiAgenda
            </div>
            <div class="card-body">
                <div class="form-group">
                    <label for="nombreTxt">Nombre de usuario:</label>
                    <asp:TextBox runat="server" ID="nombreTxt" MaxLength="20" />
                </div>
                <div class="form-group row">
                    <div class="col">
                        <label for="passwordTxt">Contraseña:</label>
                        <asp:TextBox runat="server" ID="passwordTxt" MaxLength="16" TextMode="Password" />
                    </div>
                    <div class="col">
                        <label for="rpasswordTxt">Repetir contraseña:</label>
                        <asp:TextBox runat="server" ID="rpasswordTxt" MaxLength="16" TextMode="Password" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Button runat="server" ID="registrarBtn" Text="Registrarse" SkinID="MainBtn" OnClick="registrarBtn_Click" />
                </div>
            </div>
            <div class="card-footer">
                <span runat="server" id="mensajeLbl" />
            </div>
        </div>
    </div>
</asp:Content>
