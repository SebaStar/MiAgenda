<%@ Page Title="Mis Asignaturas - MiAgenda" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Asignaturas.aspx.cs" Inherits="MiAgenda.Asignaturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 50px">
        <h3 runat="server" id="usuarioLbl" />
        <div class="card" style="margin-top: 10px">
            <div class="card-header d-flex justify-content-between">
                <div class="align-self-center">Mis Asignaturas</div>
                <asp:Button runat="server" ID="agregarBtn" Text="Agregar" SkinID="MainBtn" OnClick="agregarBtn_Click" />
            </div>
            <div class="card-body">
                <div class="form-group row">
                    <div class="col-6">
                        <label for="filtrarTxt">N° de semestre:</label>
                        <asp:TextBox runat="server" ID="filtrarTxt" TextMode="Number" Text="1" />
                    </div>
                    <div class="col-5">
                        <label for="estadoCb">Estado:</label>
                        <asp:DropDownList runat="server" ID="estadoCb">
                            <asp:ListItem Text="Sin cerrar" />
                            <asp:ListItem Text="Cerrado" />
                        </asp:DropDownList>
                    </div>
                    <div class="col-1 align-self-end">
                        <asp:Button runat="server" ID="filtrarBtn" SkinID="MainBtn" Text="Filtrar" OnClick="filtrarBtn_Click" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:GridView runat="server" ID="asignaturasTable" OnRowCommand="asignaturasTable_RowCommand" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Semestre" HeaderText="N°" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="SeccionText" HeaderText="Sección" />
                            <asp:BoundField DataField="DocenteText" HeaderText="Docente" />
                            <asp:BoundField DataField="PromedioText" HeaderText="Promedio" />
                            <asp:BoundField DataField="AsistenciaPorcentajeText" HeaderText="Asistencia" />
                            <asp:BoundField DataField="Situacion" HeaderText="Situación" />
                            <asp:BoundField DataField="EstadoText" HeaderText="Estado" />

                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:Button runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("Id") %>' SkinID="EditBtn" />
                                    <asp:Button runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' SkinID="DeleteBtn" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="card-footer">
                <span runat="server" id="mensajeLbl" />
            </div>
        </div>
    </div>
</asp:Content>
