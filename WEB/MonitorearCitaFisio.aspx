<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MonitorearCitaFisio.aspx.cs" Inherits="MonitorearCitaFisio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
    <link href="../../plugins/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">


    <section>
        <div class="container-fluid">
            <div class="block-header">
                <h1>Lista de citas:</h1>
            </div>

            <div class="row clearfix">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="upCursos" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <div class="card border">
                                <div class="header">
                                </div>

                                <div class="body border table-responsive">

                                    <asp:GridView ID="listaCitaFisio" CssClass="table table-bordered table-hover js-basic-example dataTable" runat="server" AutoGenerateColumns="False" EmptyDataText="No tiene citas registradas" ShowHeaderWhenEmpty="True">
                                        <Columns>
                                            <asp:BoundField HeaderText="Codigo de solicitud" />
                                            <asp:BoundField HeaderText="Fecha y Hora solicitada" DataFormatString="{0:dd/MM/yyyy hh:mm tt}" />
                                            <asp:BoundField HeaderText="Consulta" Visible="false" />
                                            <asp:BoundField HeaderText="Fecha de creacion" DataFormatString="{0:dd/MM/yyyy hh:mm tt}" />
                                            <asp:ButtonField HeaderText="boton" Text="boton" ButtonType="Button" ItemStyle-CssClass="text-sm-center"/>
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

    <script src="../../plugins/jquery-datatable/jquery.dataTables.js"></script>
    <script src="../../plugins/jquery-datatable/skin/bootstrap/js/dataTables.bootstrap.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/dataTables.buttons.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/buttons.flash.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/jszip.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/vfs_fonts.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/buttons.html5.min.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/buttons.print.min.js"></script>
    <script src="../../js/pages/ui/dialogs.js"></script>
    <!-- Custom Js -->
    <script src="../../js/admin.js"></script>
    <script src="../../js/pages/tables/jquery-datatable.js"></script>
    <script>$(function () {
            $(".dataTable").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });</script>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" runat="Server">
</asp:Content>

