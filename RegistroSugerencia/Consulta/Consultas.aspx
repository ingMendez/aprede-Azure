<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="RegistroSugerencia.Consulta.Consultas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="card card-register mx-auto mt-5">
        <div class="card-header text-uppercase text-center">Consultar Personas</div>
        <div class="card-body">
            <div class="form-row justify-content-center">
                <%--Filtro--%>
                <div class="form-group col-md-2">
                    <asp:Label Text="Filtro" runat="server" />
                    <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                        <asp:ListItem>Todo</asp:ListItem>
                        <asp:ListItem>Id sugerencia</asp:ListItem>
                        <asp:ListItem>descripcion</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <%--Criterio--%>
                <div class="form-group col-md-3">
                    <asp:Label ID="Label1" runat="server">Criterio</asp:Label>
                    <asp:TextBox ID="CriterioTextBox" AutoCompleteType="Disabled" class="form-control input-group" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1 p-0">
                    <asp:LinkButton ID="buscarLinkButton" CssClass="btn btn-dark mt-4" runat="server">
                <span class="fas fa-search"></span>
                 Buscar
                    </asp:LinkButton>
                </div>
            </div>
            <%--Rango fecha--%>
            <div class="form-row justify-content-center">
                <div class="form-group col-md-2">
                    <asp:Label Text="Desde" runat="server" />
                    <asp:TextBox ID="DesdeTextBox" class="form-control input-group" TextMode="Date" runat="server" />
                </div>
                <div class="form-group col-md-2">
                    <asp:Label Text="Hasta" runat="server" />
                    <asp:TextBox ID="HastaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
                </div>
            </div>
            <div class="card">
                <div class="card-body">
                    <asp:Label ID="criterioLabel" runat="server" Text="" Font-Bold="True" ValidateRequestMode="Inherit" Font-Size="Large"></asp:Label>
                    <div class="form-row justify-content-center">
                        <asp:GridView ID="ConsultaGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="LightSkyBlue" />
                            <Columns>
                                <asp:BoundField DataField="SugerenciaId" HeaderText="PersonaId" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Nombre" />
                              
                            </Columns>
                            <HeaderStyle BackColor="LightGreen" Font-Bold="True" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <%--Botones--%>
            <div class="card-footer">
                <div class="justify-content-start">
                    <div class="form-group" style="display: inline-block">
                        <asp:LinkButton ID="ImprimirLinkButton" CssClass="btn btn-info mt-4" runat="server">
                            <span class="fas fa-print"></span>
                            Imprimir
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
