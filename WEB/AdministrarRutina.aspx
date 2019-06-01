<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministrarRutina.aspx.cs" Inherits="AdministrarRutina" %>

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
                    <script src="plugins/bootstrap/js/bootstrap.js"></script>
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
                                    <div class="col-lg-2"></div>
                                    <div class="col-lg-8">
                                        <asp:Panel ID="Panel1" runat="server" CssClass="auto-style1">
                                            <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" DataKeyNames="n1" GridLines="None" AllowPaging="true" CssClass="table table-striped table-hover"
                                                OnRowCommand="gvLista_RowCommand1" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" PageSize="7" OnPageIndexChanging="gvLista_PageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField DataField="n1" HeaderText="Inicio de Semana" />
                                                    <asp:ButtonField ButtonType="button" HeaderText="Crossfit" CommandName="RegistrarC" Text="Registrar">
                                                        <ControlStyle CssClass="btn btn-success" />
                                                    </asp:ButtonField>
                                                    <asp:ButtonField ButtonType="button" CommandName="VerC" Text="Ver">
                                                        <ControlStyle CssClass="btn btn-warning" />
                                                    </asp:ButtonField>
                                                    <asp:ButtonField ButtonType="button" HeaderText="Functional" CommandName="RegistrarF" Text="Registrar">
                                                        <ControlStyle CssClass="btn btn-success" />
                                                    </asp:ButtonField>
                                                    <asp:ButtonField ButtonType="button" CommandName="VerF" Text="Ver">
                                                        <ControlStyle CssClass="btn btn-warning" />
                                                    </asp:ButtonField>
                                                </Columns>

                                            </asp:GridView>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <!-- The Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog">
            <div class="modal-dialog" style="width: 1000px">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">
                            <asp:Label ID="TituloTRut" runat="server"></asp:Label>
                        </h4>
                    </div>

                    <!-- Modal body -->
                    <div class="modal-body" id="modal-rutina">
                        <%--<div class="row">
                            <div class="col-lg-11"></div>
                            <div class="row">
                                <br />--%>
                        <%--<div class="col-md-2"></div><div class="col-lg-4">
                      <div class="liveExample"> 
                  <table data-bind='visible: gifts().length > 0'>
            <thead>
                 <tr>
                    <th>Gift name</th>
                    <th>Price</th>
                    <th />
                </tr>
            </thead>
            <tbody data-bind='foreach: gifts'>
                <tr>
                    <td><input class='required' data-bind='value: name, uniqueName: true' /></td>
                    <td><input class='required number' data-bind='value: price, uniqueName: true' /></td>
                    <td><a href='#' data-bind='click: $root.removeGift'>Delete</a></td>
                </tr>
            </tbody>
        </table>
    
        <button onclick="return false;" data-bind='click: addGift'>Add Gift</button>
        <button onclick="return false;" data-bind='enable: gifts().length > 0' type='submit'>Submit</button>
                          <script src="js/AdmRut.js"></script>
                  </div>
                      </div>
                  <br />--%>
                        <div class="row">
                            <div class="col-md-3">
                               <label for="lblCliente">Tipo Ejercicio: </label>
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Width="180px" Height="30px" AutoPostBack="false">
                                    <asp:ListItem Value="0">Seleccione </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-3">
                                 <label for="lblCliente">Ejercicio: </label>
                                <asp:DropDownList ID="ddlEjercicio" runat="server" CssClass="form-control" Width="180px" Height="30px" AutoPostBack="false">
                                    <asp:ListItem Value="0">Seleccione </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-3">
                                <label for="lblDocumento">Descripción: </label>
                                <br />
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Width="180" Height="30px"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <button id="btnlist" type="button" class="btn btn-success" style="margin-top: 23px" >+</button>
                            </div>
                        </div>
                        <!-- Modal footer -->
                        <br />
                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-success"><span class="fa fa-floppy-o">Guardar</button>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script src="js/Rutina.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
</asp:Content>


