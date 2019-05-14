<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Proc_Citas_Sol_Listar.aspx.cs" Inherits="Proc_Citas_Sol_Listar" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>

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

                                    <asp:GridView ID="gvSolicitudesCitaAdmin" CssClass="table table-bordered table-hover js-basic-example dataTable" DataKeyNames="PK_IC_Cod,FK_IEC_Cod,FK_ITC_Cod,FK_CU_Dni" runat="server" AutoGenerateColumns="False" EmptyDataText="No tiene citas registradas" ShowHeaderWhenEmpty="True" OnRowCommand="gvSolicitudesCitaAdmin_RowCommand">
                                        <Columns>
                                            <asp:BoundField DataField="PK_IC_Cod" HeaderText="Codigo" />
                                            <asp:BoundField DataField="NombreCompletoUsuario" HeaderText="Nombre Completo Usuario" />
                                            <asp:BoundField DataField="VEC_Nombre" HeaderText="Estado de Solicitud" />
                                            <asp:BoundField DataField="VTC_Nombre" HeaderText="Especialidad" />
                                            <asp:BoundField DataField="DC_FechaHoraSolicitada" HeaderText="Fecha y Hora solicitada" DataFormatString="{0:dd/MM/yyyy hh:mm tt}" />
                                            <asp:BoundField DataField="VC_Observacion" HeaderText="Consulta" Visible="false" />
                                            <asp:BoundField DataField="FK_IEC_Cod" HeaderText="FK_ EstadoCitaCod" Visible="false" />
                                            <asp:BoundField DataField="FK_ITC_Cod" HeaderText="FK_TipoCita" Visible="false" />
                                            <asp:BoundField DataField="FK_CU_Dni" HeaderText="FK_UsuarioDNI" Visible="false" />
                                            <asp:ButtonField HeaderText="Detalles" Text="Ver" ButtonType="Button" ItemStyle-CssClass="text-sm-center" CommandName="Ver">
                                                <ControlStyle CssClass="btn btn-danger" />
                                            </asp:ButtonField>
                                        </Columns>
                                    </asp:GridView>
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
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" runat="Server">
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

