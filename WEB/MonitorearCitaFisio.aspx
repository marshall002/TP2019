<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MonitorearCitaFisio.aspx.cs" Inherits="MonitorearCitaFisio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
    <link href="../../plugins/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <section>
        <div class="container-fluid">
            <div class="block-header">
                <h1>Lista de Citas:</h1>
            </div>
            <div class="card">
                <div class="row clearfix">
                    <!-- left column -->
                    <div class="col-md-11">
                        <!-- general form elements -->
                        <div class="box box-primary">
                            <!-- form start -->
     
                            <br />
                            <br />

                            <div class="row">

                                <div class="col-lg-1"></div>
                                <div class="col-lg-10">
                                    <asp:Panel ID="Panel2" runat="server" CssClass="auto-style1">
                                        <asp:GridView ID="gvListaMoniCitaFisio" runat="server" AutoGenerateColumns="False" GridLines="None" AllowPaging="true" CssClass="table table-striped table-hover dataTable" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" PageSize="9">
                                            <Columns>
                                                <asp:BoundField DataField="nombre" HeaderText="Nombres y Apellidos" />
                                                <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                                                 <asp:BoundField DataField="hora" HeaderText="Hora" />
                                                <asp:BoundField DataField="servicio" HeaderText="Cita" />
                                                <asp:BoundField DataField="estado" HeaderText="Estado" />
                                                <asp:ButtonField ButtonType="button" HeaderText="Acción" Text="Ver">
                                                    <ControlStyle CssClass="btn btn-warning" />
                                                </asp:ButtonField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>

                                </div>
                            </div>
                        </div>
                        <!-- /.box -->
                    </div>
                </div>
            </div>
        </div>
    </section>

    <script src="../../plugins/jquery-datatable/jquery.dataTables.js"></script>
    <script src="../../plugins/jquery-datatable/skin/bootstrap/js/dataTables.bootstrap.js"></script>
    <script src="../../plugins/jquery-datatable/extensions/export/dataTables.buttons.min.js"></script>
    <script src="../../js/pages/ui/dialogs.js"></script>
    <!-- Custom Js -->


    <script>$(function () {
    $(".dataTable").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
});


    </script>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" runat="Server">
</asp:Content>

