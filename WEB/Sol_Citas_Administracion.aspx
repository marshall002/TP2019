<%@ Page Title="SCLAP" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sol_Citas_Administracion.aspx.cs" Inherits="_Default" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
    <%--<script src="js/pages/ui/s.js"></script>--%>

    <script src="../../js/pages/ui/dialogs.js"></script>
    <link href="../../plugins/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css" rel="stylesheet">
    <script>$(function () {
            $(".dataTable").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <section>
        <div class="container-fluid">
            <div class="block-header">
                <h1>Citas solicitadas</h1>
            </div>
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="upCursos" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <div class="card">
                                <div class="header">
                                    <%--<h2>Programas actuales por sede</h2>--%>
                                    <ul class="header-dropdown m-r--5">
                                        <li class="dropdown">
                                            <a href="javascript:void(0);" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                                                <i class="material-icons">more_vert</i>
                                            </a>
                                            <ul class="dropdown-menu pull-right">
                                                <li><a href="javascript:void(0);">Action</a></li>
                                                <li><a href="javascript:void(0);">Another action</a></li>
                                                <li><a href="javascript:void(0);">Something else here</a></li>
                                            </ul>

                                        </li>
                                    </ul>

                                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar"
                                        class="btn btn-block btn-md btn-primary waves-effect" aria-hidden="true" OnClick="btnRegistrar_Click" />

                                </div>
                                <div class="body table-responsive ">

                                    <asp:GridView ID="gvSolicitudesCita" CssClass="table table-bordered table-hover js-basic-example dataTable" DataKeyNames="PK_IC_Cod,FK_IEC_Cod,FK_ITC_Cod" runat="server" AutoGenerateColumns="False" EmptyDataText="No tiene citas registradas" ShowHeaderWhenEmpty="True" OnRowCommand="gvSolicitudesCita_RowCommand">
                                        <Columns>
                                            <asp:BoundField DataField="PK_IC_Cod" HeaderText="Codigo de solicitud" />
                                            <asp:BoundField DataField="DC_FechaHoraSolicitada" HeaderText="Fecha y Hora solicitada" DataFormatString="{0:dd/MM/yyyy hh:mm tt}" />
                                            <asp:BoundField DataField="VC_Observacion" HeaderText="Consulta" Visible="false" />
                                            <asp:BoundField DataField="DC_FechaHoraCreada" HeaderText="Fecha de creacion" DataFormatString="{0:dd/MM/yyyy hh:mm tt}" />
                                            <asp:BoundField DataField="FK_IEC_Cod" HeaderText="FK_ EstadoCitaCod" Visible="false" />
                                            <asp:BoundField DataField="FK_ITC_Cod" HeaderText="FK_TipoCita" Visible="false" />
                                            <asp:BoundField DataField="VEC_Nombre" HeaderText="Estado de Solicitud" />
                                            <asp:BoundField DataField="FK_CU_Dni" HeaderText="FK_UsuarioDNI" Visible="false" />
                                            <asp:BoundField DataField="VTC_Nombre" HeaderText="Especialidad" />
                                            <asp:ButtonField HeaderText="Actualiza tu sol." Text="Actualizar" ButtonType="Button" ItemStyle-CssClass="text-sm-center" CommandName="actualizar">
                                                <ControlStyle CssClass="btn btn-success" />
                                            </asp:ButtonField>
                                            <asp:ButtonField HeaderText="Elimina tu sol." Text="Eliminar" ButtonType="Button" ItemStyle-CssClass="text-sm-center" CommandName="eliminar">
                                                <ControlStyle CssClass="btn btn-danger" />
                                            </asp:ButtonField>
                                            <%--<asp:ButtonField HeaderText="Aprueba la Reprogramacion" Text="Aprobar" ButtonType="Button" ItemStyle-CssClass="text-sm-center" CommandName="AprobarRepro" >
                                                <ControlStyle CssClass="btn bg-yellow" />
                                            </asp:ButtonField>--%>
                                            <asp:TemplateField HeaderText="Aprueba la Reprogramacion">
                                                <ItemTemplate>
                                                    <asp:Button runat="server" Text="Aprobar"
                                                        Visible='<%# ValidacionEstadoCita((int)Eval("FK_IEC_Cod")) %>'
                                                        CommandName="AprobarRepro" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn bg-yellow" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="modal fade" id="modalconfirmacioneliminarsol" tabindex="-1" role="dialog">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h4 class="modal-title" id="DescModalEliminarCita" runat="server">¿Seguro desea eliminar su solicitud?</h4>
                                        </div>
                                        <div class="modal-body">
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-link waves-effect waves-grey" data-dismiss="modal">CANCELAR</button>
                                            <button type="button" class="btn btn-link waves-effect waves-grey" id="btnEliminarSolCita" runat="server" data-dismiss="modal" onserverclick="btnEliminarSolCita_ServerClick">ELIMINAR</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal fade" id="modalDetallesHoraReprogramada" tabindex="-1" role="dialog">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h4 class="modal-title" id="H1" runat="server">La hora Reprogramada es: </h4>
                                        </div>
                                        <div class="modal-body">
                                            <asp:UpdatePanel ID="upHoraReprogramada" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                <ContentTemplate>
                                                    <div class="form-group">
                                                        <label class="form-label">
                                                            Nueva fecha propuesta</label>
                                                        <div class="form-line">
                                                            <asp:TextBox runat="server" ID="txtFechareprogramada" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-label">
                                                            Nueva hora propuesta</label>
                                                        <div class="form-line">
                                                            <asp:TextBox runat="server" ID="txtHorareprogramada" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-link waves-effect waves-grey" data-dismiss="modal">CANCELAR</button>
                                            <button type="button" class="btn btn-link waves-effect waves-grey" id="btnAprobar" runat="server" data-dismiss="modal" onserverclick="btnAprobar_ServerClick">Aprobar</button>
                                            <button type="button" class="btn btn-link waves-effect waves-grey" id="btnRechazar" runat="server" data-dismiss="modal" onserverclick="btnRechazar_ServerClick">Rechazar</button>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>

                            <asp:AsyncPostBackTrigger ControlID="btnEliminarSolCita" />
                            <asp:AsyncPostBackTrigger ControlID="btnAprobar" />
                            <asp:AsyncPostBackTrigger ControlID="btnRechazar" />


                        </Triggers>

                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_js" runat="Server">
    <script src="../../plugins/jquery-datatable/jquery.dataTables.js"></script>
    <script src="../../plugins/jquery-datatable/skin/bootstrap/js/dataTables.bootstrap.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/dataTables.buttons.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/buttons.flash.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/jszip.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/pdfmake.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/vfs_fonts.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/buttons.html5.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/buttons.print.min.js"></script>

    <!-- Custom Js -->
    <script src="../../js/admin.js"></script>
    <script src="../../js/pages/tables/jquery-datatable.js"></script>
</asp:Content>
