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
                                    <li role="presentation" class="active"><a href="#revision" data-toggle="tab">En revisión</a></li>
                                    <li role="presentation"><a href="#pendientepagos" data-toggle="tab">Pendientes de pago</a></li>
                                    <li role="presentation" runat="server" id="liAprobados"><a href="#aprobados" data-toggle="tab">Aprobados</a></li>
                                    <li role="presentation" runat="server" id="liPagadoSinRevision"><a href="#pagadosinrevision" data-toggle="tab">Pagado sin revision</a></li>
                                    <li role="presentation" runat="server" id="licanceladas"><a href="#canceladas" data-toggle="tab">Canceladas por mi</a></li>
                                    <li role="presentation"><a href="#rechazadas" data-toggle="tab">Rechazados</a></li>
                                </ul>

                                <!-- Tab panes -->
                                <div class="tab-content">
                                    <div role="tabpanel" class="tab-pane fade" id="aprobados">
                                        <div class="body table-responsive ">
                                            <asp:UpdatePanel ID="updPanelAprobado" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                <ContentTemplate>
                                                    <asp:GridView ID="gvSolAprobados" CssClass="table table-bordered table-hover js-basic-example dataTable" DataKeyNames="PK_IC_Cod,VC_Descripcion" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" OnRowCommand="gvSolAprobados_RowCommand">
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
                                    <div role="tabpanel" class="tab-pane fade" id="pendientepagos">
                                        <div class="body table-responsive ">
                                            <asp:UpdatePanel ID="updPanelPendientePago" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                <ContentTemplate>
                                                    <asp:GridView ID="gvSolPendientePago" CssClass="table table-bordered table-hover js-basic-example dataTable" DataKeyNames="PK_IC_Cod,VC_Descripcion" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" OnRowCommand="gvSolPendientePago_RowCommand">
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
                                                            <asp:ButtonField ButtonType="button" HeaderText="Pagar" CommandName="Anexarpago" Text="Anexar pago">
                                                                <ControlStyle CssClass="btn btn-danger" />
                                                            </asp:ButtonField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div role="tabpanel" class="tab-pane fade active in" id="revision">
                                        <div class="body table-responsive ">
                                            <asp:UpdatePanel ID="updPanelRevision" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                <ContentTemplate>
                                                    <asp:GridView ID="gvSolRevision" CssClass="table table-bordered table-hover js-basic-example dataTable" DataKeyNames="PK_IC_Cod,VC_Descripcion" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" OnRowCommand="gvSolAprobado_RowCommand" OnRowCreated="gvSolRevision_RowCreated">
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
                                                            <asp:ButtonField ButtonType="button" HeaderText="Aprobar" CommandName="Aprobar" Text="Aprobar">
                                                                <ControlStyle CssClass="btn btn-danger" />
                                                            </asp:ButtonField>
                                                            <asp:ButtonField ButtonType="button" HeaderText="Rechazar" CommandName="Rechazar" Text="Rechazar">
                                                                <ControlStyle CssClass="btn btn-danger" />
                                                            </asp:ButtonField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div role="tabpanel" class="tab-pane fade" id="pagadosinrevision">
                                        <div class="body table-responsive ">
                                            <asp:UpdatePanel ID="updPanelSolSinRevision" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                <ContentTemplate>
                                                    <asp:GridView ID="gvSolPagadoSinRevision" CssClass="table table-bordered table-hover js-basic-example dataTable" DataKeyNames="PK_IC_Cod,VC_Descripcion" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" OnRowCommand="gvSolPagadoSinRevision_RowCommand" OnRowCreated="gvSolPagadoSinRevision_RowCreated">
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
                                                            <asp:ButtonField ButtonType="button" HeaderText="Aprobar" CommandName="VerPago" Text="Ver el pago">
                                                                <ControlStyle CssClass="btn btn-danger" />
                                                            </asp:ButtonField>
                                                            <asp:ButtonField ButtonType="button" HeaderText="Rechazar" CommandName="Rechazar" Text="Rechazar">
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
                                                    <asp:GridView ID="gvSolCancelados" CssClass="table table-bordered table-hover js-basic-example dataTable" DataKeyNames="PK_IC_Cod,VC_Descripcion" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" OnRowCommand="gvSolCancelados_RowCommand">
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
                                                    <asp:GridView ID="gvSolRechazadas" CssClass="table table-bordered table-hover js-basic-example dataTable" DataKeyNames="PK_IC_Cod,VC_Descripcion" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" OnRowCommand="gvSolRechazadas_RowCommand">
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
                                            <div class="modal-footer modal-col-red">
                                                <asp:UpdatePanel runat="server" ID="updPanelConfirmacion">
                                                    <ContentTemplate>
                                                        <asp:Button runat="server" ID="btnAceptarCancelarSol" CssClass="btn btn-link waves-effect" Text="Aceptar" OnClick="btnAceptarCancelarSol_Click" />
                                                        <button type="button" class="btn btn-link waves-effect button" onclick="limpiarHF();" data-dismiss="modal">Cerrar</button>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <div class="modal fade" id="RechazarModal" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
                            <div class="modal-dialog modal-sm" role="document">
                                <div class="modal-content">
                                    <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Always">
                                        <ContentTemplate>
                                            <div class="modal-body">
                                                <h4 id="H1" runat="server">Esta seguro de rechazar la solicitud</h4>
                                            </div>
                                            <div class="modal-footer modal-col-red">
                                                <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                                                    <ContentTemplate>
                                                        <asp:Button runat="server" ID="btnaceptarRechazo" CssClass="btn btn-link waves-effect" Text="Aceptar" OnClick="btnaceptarRechazo_Click" />
                                                        <button type="button" class="btn btn-link waves-effect button" onclick="limpiarHF();" data-dismiss="modal">Cerrar</button>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <div class="modal fade" id="AprobarModal" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
                            <div class="modal-dialog modal-sm" role="document">
                                <div class="modal-content">
                                    <asp:UpdatePanel runat="server" ID="UpdatePanel4" UpdateMode="Always">
                                        <ContentTemplate>
                                            <div class="modal-body">
                                                <h4 id="H2" runat="server">Esta seguro de aprobar la solicitud, se mostrará como los pendientes de pago</h4>
                                            </div>
                                            <div class="modal-footer modal-col-red">
                                                <asp:UpdatePanel runat="server" ID="udpPanelAprobarSolicitud">
                                                    <ContentTemplate>
                                                        <asp:Button runat="server" ID="btnaceptarAprobarRegistro" CssClass="btn btn-link waves-effect"  Text="Aceptar" OnClick="btnaceptarAprobarRegistro_Click" />
                                                        <button type="button" class="btn btn-link waves-effect button" onclick="limpiarHF();" data-dismiss="modal">Cerrar</button>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>

                        <div class="modal fade" id="modalImagenPago" tabindex="-1" role="dialog">
                            <div class="modal-dialog modal-lg" role="document">
                                <div class="modal-content">

                                    <div class="modal-header">
                                        <h4 class="modal-title" id="H3" runat="server">Pago </h4>
                                    </div>
                                    <div class="modal-body">

                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:UpdatePanel runat="server" ID="UpdatePanel5" UpdateMode="Always">
                                                    <ContentTemplate>
                                                        <div>
                                                            <asp:Image ID="Image1" Height="300px" Width="300px" runat="server" class="rounded" />
                                                        </div>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="modal-footer btn-group-sm">
                                        <asp:UpdatePanel ID="UpdatePanelA" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Button ID="btnAprobarPago" runat="server" Text="Aprobar"  CssClass="btn btn-link waves-effect"  OnClick="btnAprobarPago_Click" />
                                        <button type="button" class="btn btn-link waves-effect" data-dismiss="modal">Cerrar</button>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal fade" id="modalCargarPago" tabindex="-1" role="dialog">
                            <div class="modal-dialog modal-lg" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title" id="H4" runat="server">Anexar pago</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div>
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <asp:Image ID="Image2" Height="500px" Width="500px" runat="server" class="rounded" />

                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>

                                                    <input name="fileAnexo" type="file" id="FileUpload1" runat="server" accept=".png,.jpg" class="btn btn-danger" style="width: 100%;" />
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="modal-footer btn-group-sm">
                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Button ID="btnGuardarPago" runat="server" Text="Enviar pago" CssClass="btn btn-link waves-effect"  OnClick="btnGuardarPago_Click" />
                                                <button type="button" class="btn btn-link waves-effect button"  data-dismiss="modal">Cerrar</button>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
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
    <script src="js/Aplicacion/UploadFile.js"></script>
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
        function mostrarMensajeCancelacion() {
            $('#confirmacionmodal').modal('hide');
            $('#RechazarModal').modal('hide');
            swal('Rechazado!', 'Solicitud rechazada!!', 'success');
        }
        function mostrarMensajeConfirmacionMandarSinPago() {
            $('#confirmacionmodal').modal('hide');
            $('#AprobarModal').modal('hide');
            swal('Aprobado!', 'Está pendiente de revisión de pago!!', 'success');
        }
        function mostrarMensajRegistrarpago() {
            $('#confirmacionmodal').modal('hide');
            $('#modalCargarPago').modal('hide');
            swal('Registrado!', 'Solicitud pagada, en revisión!!', 'success');
        }
        function mostrarMensajepagada() {
            $('#confirmacionmodal').modal('hide');
            $('#modalImagenPago').modal('hide');
            swal('Registrado!', 'Contrato aprobado, se está enviando correo con el contrato!!', 'success');
        }
    </script>
</asp:Content>

