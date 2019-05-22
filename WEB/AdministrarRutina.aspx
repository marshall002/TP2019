﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministrarRutina.aspx.cs" Inherits="AdministrarRutina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <section>
        <div class="container-fluid">
            <div class="block-header">
                <h1>Administrar Rutina</h1>
            </div>
            <div class="row clearfix">
                <div class="col-md-11">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="upCursos" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <div class="card">
                                <!-- form start -->
                                <div class="row">
                                    <br />
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-3">
                                        <label for="lblCliente">Seleccionar Mes: </label>
                                        <asp:DropDownList runat="server" ID="ddlMes" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged">

                                            <asp:ListItem Value="1">Enero</asp:ListItem>
                                            <asp:ListItem Value="2">Febrero</asp:ListItem>
                                            <asp:ListItem Value="3">Marzo</asp:ListItem>
                                            <asp:ListItem Value="4">Abril</asp:ListItem>
                                            <asp:ListItem Value="5">Mayo</asp:ListItem>
                                            <asp:ListItem Value="6">Junio</asp:ListItem>
                                            <asp:ListItem Value="7">Julio</asp:ListItem>
                                            <asp:ListItem Value="8">Agosto</asp:ListItem>
                                            <asp:ListItem Value="9">Setiembre</asp:ListItem>
                                            <asp:ListItem Value="10">Octubre</asp:ListItem>
                                            <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                            <asp:ListItem Value="12">Diciembre</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-3">
                                    </div>
                                    <div class="col-lg-4">
                                        <label for="lblCliente">Fecha de hoy: </label>
                                        <asp:TextBox ID="txtfecha" runat="server" ReadOnly CssClass="form-control" Width="250px" Height="30px"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <br />

                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10">
                                        <asp:Panel ID="Panel1" runat="server" CssClass="auto-style1">
                                            <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" DataKeyNames="n1" GridLines="None" AllowPaging="true" CssClass="table table-striped table-hover" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" PageSize="7" OnPageIndexChanging="gvLista_PageIndexChanging" OnRowCommand="gvLista_RowCommand">
                                                <Columns>
                                                    <asp:BoundField DataField="n1" HeaderText="Inicio de Semana" />
                                                    <asp:ButtonField ButtonType="button" HeaderText="Crossfit" CommandName="RegistrarC" Text="Registrar">
                                                        <ControlStyle CssClass="btn btn-success" />
                                                    </asp:ButtonField>
                                                    <asp:ButtonField ButtonType="button" HeaderText="" CommandName="VerC" Text="Ver">
                                                        <ControlStyle CssClass="btn btn-success" />
                                                    </asp:ButtonField>

                                                </Columns>
                                                <Columns>
                                                    <asp:ButtonField ButtonType="button" HeaderText="Functional" CommandName="RegistrarF" Text="Registrar">
                                                        <ControlStyle CssClass="btn btn-success" />
                                                    </asp:ButtonField>
                                                    <asp:ButtonField ButtonType="button" HeaderText="" CommandName="VerF" Text="Ver">
                                                        <ControlStyle CssClass="btn btn-success" />
                                                    </asp:ButtonField>
                                                </Columns>

                                            </asp:GridView>
                                            <div class="col-lg-3 right">
                                                <div class="modal fade" id="modalRutina" tabindex="-1" role="dialog">
                                                    <div class="modal-dialog" role="document">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <h4 class="modal-title" id="ModalRutina" runat="server">Escoja las ejercicios:</h4>
                                                            </div>
                                                            <div class="modal-body">
                                                                <div class="form-group">
                                                                    <label class="form-label">
                                                                        Rutina</label>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="form-label">Nuevo Ejercicio</label>
                                                                    <div class="form-line">
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="modal-footer">
                                                                <button type="button" class="btn btn-link waves-effect waves-grey" data-dismiss="modal">CANCELAR</button>
                                                                <%--<button type="button" class="btn btn-link waves-effect waves-grey" id="btnaceptar" runat="server" data-dismiss="modal" data-type="success" onserverclick="btnReproSCita_ServerClick">GUARDAR</button>
                                                      --%>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
</asp:Content>


