<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SolicitudPlan.aspx.cs" Inherits="SolicitudPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <section>
        <div class="container-fluid">
            <div class="row">
            </div>
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                    <div class="card">
                        <div class="header">
                            <h3>Mis planes solicitados</h3>
                        </div>
                        <div>
                            <div class="body">
                                <!-- Nav tabs -->
                                <ul class="nav nav-tabs tab-nav-right" role="tablist">
                                    <li role="presentation" class="active"><a href="#pendientepagos" data-toggle="tab">Pendientes de pago</a></li>
                                    <li role="presentation"><a href="#revision" data-toggle="tab">En revisión</a></li>
                                    <li role="presentation"><a href="#canceladas" data-toggle="tab">Canceladas por mi</a></li>
                                    <li role="presentation"><a href="#rechazadas" data-toggle="tab">Rechazados</a></li>
                                </ul>

                                <!-- Tab panes -->
                                <div class="tab-content">
                                    <div role="tabpanel" class="tab-pane fade in active" id="pendientepagos">
                                        <div class="body table-responsive ">
                                            <asp:UpdatePanel ID="updPanelPendientePago" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                <ContentTemplate>
                                                    <asp:GridView ID="gvSolPendientePago" CssClass="table table-bordered table-hover js-basic-example dataTable" DataKeyNames="PK_IC_Cod,VC_Descripcion" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True">
                                                        <Columns>
                                                            <asp:BoundField DataField="PK_IC_Cod" HeaderText="ID" />
                                                            <asp:BoundField DataField="VC_Descripcion" HeaderText="Tipo de moldura" Visible="false" />
                                                            <asp:BoundField DataField="DC_Fecha_Creacion" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Fecha de registro" />
                                                            <asp:BoundField DataField="DC_Fecha_Inicio" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha de inicio solicitado" />
                                                            <asp:BoundField DataField="IE_Cantidad_sesion_Nutri" HeaderText="N° sesiones nutricionista" />
                                                            <asp:BoundField DataField="IP_Cantidad_sesion_Fisio" HeaderText="N° sesiones Fisioterapeuta" />
                                                            <asp:BoundField DataField="Congelamiento" HeaderText="Congelamiento (dias)" />
                                                            <asp:BoundField DataField="MembresiaDuracionString" HeaderText="Membresia (meses)" />
                                                            <asp:BoundField DataField="FrecuenciaString" HeaderText="Frecuencia" />
                                                            <asp:ButtonField ButtonType="button" HeaderText="Detalles" CommandName="Ver" Text="Ver">
                                                                <ControlStyle CssClass="btn btn-warning" />
                                                            </asp:ButtonField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div role="tabpanel" class="tab-pane fade" id="revision">
                                        <div class="body table-responsive ">
                                            <asp:UpdatePanel ID="updPanelRevision" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                <ContentTemplate>
                                                    <asp:GridView ID="gvSolRevision" CssClass="table table-bordered table-hover js-basic-example dataTable" DataKeyNames="PK_IC_Cod,VC_Descripcion" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" OnRowCommand="gvSolAprobado_RowCommand">
                                                        <Columns>
                                                            <asp:BoundField DataField="PK_IC_Cod" HeaderText="ID" />
                                                            <asp:BoundField DataField="VC_Descripcion" HeaderText="Tipo de moldura" Visible="false" />
                                                            <asp:BoundField DataField="DC_Fecha_Creacion" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Fecha de registro" />
                                                            <asp:BoundField DataField="DC_Fecha_Inicio" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha de inicio solicitado" />
                                                            <asp:BoundField DataField="IE_Cantidad_sesion_Nutri" HeaderText="N° sesiones nutricionista" />
                                                            <asp:BoundField DataField="IP_Cantidad_sesion_Fisio" HeaderText="N° sesiones Fisioterapeuta" />
                                                            <asp:BoundField DataField="Congelamiento" HeaderText="Congelamiento (dias)" />
                                                            <asp:BoundField DataField="MembresiaDuracionString" HeaderText="Membresia (meses)" />
                                                            <asp:BoundField DataField="FrecuenciaString" HeaderText="Frecuencia" />
                                                            <asp:ButtonField ButtonType="button" HeaderText="Detalles" CommandName="Ver" Text="Ver">
                                                                <ControlStyle CssClass="btn btn-warning" />
                                                            </asp:ButtonField>
                                                            <asp:ButtonField ButtonType="button" HeaderText="Cancelar solicitud" CommandName="Cancelar" Text="Cancelar">
                                                                <ControlStyle CssClass="btn btn-danger" />
                                                            </asp:ButtonField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div role="tabpanel" class="tab-pane fade" id="canceladas">
                                        <div class="body table-responsive ">
                                            <asp:UpdatePanel ID="updPanelCancelado" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                <ContentTemplate>
                                                    <asp:GridView ID="gvSolCancelados" CssClass="table table-bordered table-hover js-basic-example dataTable" DataKeyNames="PK_IC_Cod,VC_Descripcion" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True">
                                                        <Columns>
                                                            <asp:BoundField DataField="PK_IC_Cod" HeaderText="ID" />
                                                            <asp:BoundField DataField="VC_Descripcion" HeaderText="Tipo de moldura" Visible="false" />
                                                            <asp:BoundField DataField="DC_Fecha_Creacion" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Fecha de registro" />
                                                            <asp:BoundField DataField="DC_Fecha_Inicio" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha de inicio solicitado" />
                                                            <asp:BoundField DataField="IE_Cantidad_sesion_Nutri" HeaderText="N° sesiones nutricionista" />
                                                            <asp:BoundField DataField="IP_Cantidad_sesion_Fisio" HeaderText="N° sesiones Fisioterapeuta" />
                                                            <asp:BoundField DataField="Congelamiento" HeaderText="Congelamiento (dias)" />
                                                            <asp:BoundField DataField="MembresiaDuracionString" HeaderText="Membresia (meses)" />
                                                            <asp:BoundField DataField="FrecuenciaString" HeaderText="Frecuencia" />
                                                            <asp:ButtonField ButtonType="button" HeaderText="Detalles" CommandName="Ver" Text="Ver">
                                                                <ControlStyle CssClass="btn btn-warning" />
                                                            </asp:ButtonField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div role="tabpanel" class="tab-pane fade" id="rechazadas">
                                        <div class="body table-responsive ">
                                            <asp:UpdatePanel ID="updPanelRechazada" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                <ContentTemplate>
                                                    <asp:GridView ID="gvSolRechazadas" CssClass="table table-bordered table-hover js-basic-example dataTable" DataKeyNames="PK_IC_Cod,VC_Descripcion" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True">
                                                        <Columns>
                                                            <asp:BoundField DataField="PK_IC_Cod" HeaderText="ID" />
                                                            <asp:BoundField DataField="VC_Descripcion" HeaderText="Tipo de moldura" Visible="false" />
                                                            <asp:BoundField DataField="DC_Fecha_Creacion" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Fecha de registro" />
                                                            <asp:BoundField DataField="DC_Fecha_Inicio" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha de inicio solicitado" />
                                                            <asp:BoundField DataField="IE_Cantidad_sesion_Nutri" HeaderText="N° sesiones nutricionista" />
                                                            <asp:BoundField DataField="IP_Cantidad_sesion_Fisio" HeaderText="N° sesiones Fisioterapeuta" />
                                                            <asp:BoundField DataField="Congelamiento" HeaderText="Congelamiento (dias)" />
                                                            <asp:BoundField DataField="MembresiaDuracionString" HeaderText="Membresia (meses)" />
                                                            <asp:BoundField DataField="FrecuenciaString" HeaderText="Frecuencia" />
                                                            <asp:ButtonField ButtonType="button" HeaderText="Detalles" CommandName="Ver" Text="Ver">
                                                                <ControlStyle CssClass="btn btn-warning" />
                                                            </asp:ButtonField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:HiddenField runat="server" ID="hfContentIDSol" ClientIDMode="Static" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="modal fade" id="defaultmodal" tabindex="-1" role="dialog">
                            <div class="modal-dialog modal-sm" role="document">
                                <div class="modal-content">
                                    <asp:UpdatePanel runat="server" ID="updPanelModal" UpdateMode="Always">
                                        <ContentTemplate>
                                            <div class="modal-header modal-col-red">
                                                <h4 class="modal-title" id="tituloModal" runat="server" style="color: white;"></h4>
                                            </div>
                                            <div class="modal-body">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="row clearfix">
                                                            <div class="form-group form-float">
                                                                <label class="form-label">Descripción :</label>
                                                                <div class="form-line focused">
                                                                    <div class="form-line">
                                                                        <asp:TextBox ID="txtDescripcionModal" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-link waves-effect" data-dismiss="modal">Cerrar</button>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <div class="modal fade" id="confirmacionmodal" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
                            <div class="modal-dialog modal-sm" role="document">
                                <div class="modal-content">
                                    <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Always">
                                        <ContentTemplate>
                                            <div class="modal-body">
                                                <h4 id="mensaje" runat="server">Esta seguro de cancelar su solicitud</h4>
                                            </div>
                                            <div class="modal-footer">
                                                <asp:UpdatePanel runat="server" ID="updPanelConfirmacion">
                                                    <ContentTemplate>
                                                        <asp:Button runat="server" ID="btnAceptarCancelarSol" CssClass="button" Text="Ir a pedido personalizado" OnClick="btnAceptarCancelarSol_Click" />
                                                        <button type="button" class="btn btn-link waves-effect button" onclick="limpiarHF();" data-dismiss="modal">Cerrar</button>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" runat="Server">
    <script>
        function limpiarHF() {
            $('#hfContentIDSol').val("");
        }
        function mostrarModalConfirmacion() {
            $('#confirmacionmodal').modal('show');
        }
        function mostrarMensajeConfirmacion() {
            $('#confirmacionmodal').modal('hide');
            $('#defaultmodal').modal('hide');
            swal('Cancelado!', 'Solicitud cancelado!!', 'success');
        }
    </script>
</asp:Content>

