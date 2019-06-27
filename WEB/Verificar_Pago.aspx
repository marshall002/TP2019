<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Verificar_Pago.aspx.cs" Inherits="Verificar_Pago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">

    <script src="../../js/pages/ui/dialogs.js"></script>
    <link href="../../plugins/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css" rel="stylesheet">
    <script>$(function () {
            $(".dataTable").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <section>
        <div class="container-fluid">
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <div class="card">
                                <div class="header">
                                    <h1>Verificar Pagos</h1>

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
                                </div>
                                <div class="body table-responsive">
                                    <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="true" DataKeyNames="PK_ICP_Cod, ICP_NNutri, ICP_NFisio, VCP_Estado_Pago" CssClass="table table-striped table-hover dataTable" OnRowCommand="gvLista_RowCommand" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                        PageSize="9">
                                        <Columns>
                                            <asp:BoundField DataField="PK_ICP_Cod" HeaderText="Codigo" />
                                            <asp:BoundField DataField="nombres" HeaderText="Nombre" />
                                            <asp:BoundField DataField="DCP_FechaHoraRealizada" HeaderText="Fecha" />
                                            <asp:BoundField DataField="ICP_NNutri" HeaderText="N° Nutri" />
                                            <asp:BoundField DataField="ICP_NFisio" HeaderText="N° Fisio" />
                                            <asp:ButtonField ButtonType="button" HeaderText="Evaluacion" CommandName="Ver Pago" Text="Ver">
                                                <ControlStyle CssClass="btn btn-warning" />
                                            </asp:ButtonField>
                                            <asp:BoundField DataField="VCP_Estado_Pago" HeaderText="Estado" />
                                            <asp:TemplateField HeaderText="Aprobar Pago">
                                                <ItemTemplate>
                                                    <asp:Button runat="server" Text="Aceptar Pago" CommandName="AceptarP"
                                                        Visible='<%# ValidacionEstadoCita((string)Eval("VCP_Estado_Pago")) %>'
                                                        CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-success" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rechaza Pago">
                                                <ItemTemplate>
                                                    <asp:Button runat="server" Text="Rechazar pago"
                                                        Visible='<%# ValidacionEstadoCita((string)Eval("VCP_Estado_Pago")) %>'
                                                        CommandName="ReportarP" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-danger" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>

                                </div>
                            </div>
                            <div class="modal fade" id="VerPago" tabindex="-1" role="dialog">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">

                                            <h4 class="modal-title" id="ModalVerPago" runat="server">Verificar Pago</h4>
                                        </div>
                                        <div class="modal-body">
                                            <asp:UpdatePanel ID="upModal" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                <ContentTemplate>
                                                    <div class="input-group colorpicker">
                                                        <div class="form-line">
                                                            <label for="textComprobante">Comprobante:</label><br />
                                                            <div class="col-lg-4">
                                                                <asp:Image ID="textImagen" Width="250" Height="200" runat="server" CssClass="form-control"></asp:Image>
                                                            </div>
                                                        </div>
                                                        <span class="input-group-addon">
                                                            <i></i>
                                                        </span>
                                                    </div>
                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                            <div class="input-group colorpicker">
                                                                <div class="form-line">
                                                                    <label for="textMontos">Monto:</label>
                                                                    <asp:TextBox ID="txtMonto" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                                                                </div>
                                                                <span class="input-group-addon">
                                                                    <i></i>
                                                                </span>
                                                            </div>

                                                            <div class="input-group colorpicker">
                                                                <div class="form-line">
                                                                    <label for="textNnutri">N° Citas Nutri:</label>
                                                                    <asp:TextBox ID="txtNnutri" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                                                                </div>
                                                                <span class="input-group-addon">
                                                                    <i></i>
                                                                </span>
                                                            </div>
                                                        </div>

                                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                            <div class="input-group colorpicker">
                                                                <div class="form-line">
                                                                    <label for="textOpera">N° de Operación:</label>
                                                                    <asp:TextBox ID="txtOpera" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                                                                </div>
                                                                <span class="input-group-addon">
                                                                    <i></i>
                                                                </span>
                                                            </div>
                                                            <div class="input-group colorpicker">
                                                                <div class="form-line">
                                                                    <label for="textNfisio">N° Citas Fisio:</label>
                                                                    <asp:TextBox ID="txtFisio" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                                                                </div>
                                                                <span class="input-group-addon">
                                                                    <i></i>
                                                                </span>
                                                            </div>

                                                        </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="modal-footer">

                                            <div class="form-group">
                                                <div class="form-group">
                                                    <input type="button" value="Cerrar" class="btn btn-danger" data-dismiss="modal">
                                                </div>
                                            </div>
                                        </div>
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
