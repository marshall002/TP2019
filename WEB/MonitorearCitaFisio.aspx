<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MonitorearCitaFisio.aspx.cs" Inherits="MonitorearCitaFisio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
    <link href="../../plugins/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">

    <link href="plugins/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <!-- Jquery Core Js -->
    <script src="plugins/jquery/jquery.min.js"></script>

    <!-- Bootstrap Core Js -->
    <script src="plugins/bootstrap/js/bootstrap.js"></script>


    <section>
        <div class="container-fluid">
            <div class="container-fluid">
                <div class="col-lg-12 col-md-4 col-sm-6 col-xs-12">
                    <div class="card">
                        <div class="header bg-blue-grey">
                            <h2>LISTA DE CITAS<small>Fisioterapista</small>
                            </h2>
                        </div>
                        <div class="body">
                            <div class="table-responsive text-center">
                                <asp:Panel ID="Panel1" runat="server" CssClass="auto-style1">
                                    <asp:GridView ID="gvListaMoniCitaFisio" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="true" CssClass="table table-bordered table-hover js-basic-example dataTable" OnRowCommand="listaCitaFisio_RowCommand" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                        PageSize="9" EmptyDataText="No tiene citas registradas"
                                        DataKeyNames="CODIGO">
                                        <Columns>
                                            <asp:BoundField DataField="NRO" HeaderText="N°" />
                                            <asp:BoundField DataField="CODIGO" HeaderText="Codigo" Visible="false" />
                                            <asp:BoundField DataField="NOMBRE" HeaderText="Nombres y Apellidos" />
                                            <asp:BoundField DataField="FECHA" HeaderText="Fecha" />
                                            <asp:BoundField DataField="HORA" HeaderText="Hora" />
                                            <asp:BoundField DataField="SESION" HeaderText="Cita" />
                                            <asp:BoundField DataField="ESTADO" HeaderText="Estado" />
                                            <asp:ButtonField ButtonType="button" HeaderText="Acción" CommandName="Ver Acción" Text="Ver Detalle">
                                                <ControlStyle CssClass="btn btn-warning text-center" />
                                            </asp:ButtonField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- For Material Design Colors -->
        <div class="modal fade" id="VerDetalleMod" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">

                    <div class="modal-header">
                        <h4 class="modal-title" id="defaultModalLabel">Detalle de la solicitud</h4>
                    </div>

                    <div class="modal-body">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <div class="input-group colorpicker">
                                    <div class="form-line">
                                        <label for="textNombre">Codigo Cita :</label>
                                        <asp:TextBox ID="textCodigo" runat="server" CssClass="form-control text-center" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <span class="input-group-addon">
                                        <i></i>
                                    </span>
                                </div>

                                <div class="input-group colorpicker">
                                    <div class="form-line">
                                        <label for="textHora">Fecha:</label>
                                        <asp:TextBox ID="textHora" runat="server" CssClass="form-control text-center" ReadOnly="true">

                                        </asp:TextBox>
                                    </div>
                                    <span class="input-group-addon">
                                        <i></i>
                                    </span>
                                </div>
                                <div class="input-group colorpicker">
                                    <div class="form-line">
                                        <label for="textHora">Fecha:</label>
                                        <asp:TextBox ID="textFecha" runat="server" CssClass="form-control text-center" ReadOnly="true">

                                        </asp:TextBox>
                                    </div>
                                    <span class="input-group-addon">
                                        <i></i>
                                    </span>
                                </div>
                                <div class="input-group colorpicker">
                                    <div class="form-line">
                                        <style>
                                            #textObs {
                                                height: 300px;
                                                width: 600px;
                                            }
                                        </style>
                                        <label class="text-left" for="textObs">Duda o Consulta:</label>
                                        <asp:TextBox ID="textObs" TextMode="MultiLine" runat="server" CssClass="form-control" Height="100" ReadOnly="true">

                                        </asp:TextBox>
                                    </div>
                                    <span class="input-group-addon">
                                        <i></i>
                                    </span>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <!-- <div class="input-group colorpicker">
                                    <div class="form-line">
                                        <label for="textHora">Apellido:</label>
                                        <asp:TextBox ID="TextApellido" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <span class="input-group-addon">
                                        <i></i>
                                    </span>
                                </div>-->
                                <div class="form-group">
                                    <label>Asistencia:</label>
                                    <div class="input-group">
                                        <input type="radio" id="chk1" class="filled-in" value="6" name="chk">
                                        <label for="chk1">Atendido</label>
                                    </div>
                                    <div class="input-group">
                                        <input type="radio" id="chk2" class="filled-in" value="7" name="chk">
                                        <label for="chk2">No Atendido</label>
                                    </div>
                                    <asp:Label runat="server" ID="msjrb"> </asp:Label>
                                </div>
                                <asp:HiddenField ID="txtresultadoChecbox" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">

                        <asp:Button runat="server" CssClass="btn btn-success" Text="Grabar" OnClick="btnGuardar_ServerClick" />
                        <asp:Button runat="server" CssClass="btn btn-danger" OnClientClick="$('#VerDetalleMod').modal('hide');" Text="Cerrar" />

                    </div>
                </div>
            </div>
        </div>


    </section>

    <script src="js/script.js"></script>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" runat="Server">
</asp:Content>

