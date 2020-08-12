<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SolicitarPlan.aspx.cs" Inherits="SolicitarPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
    <link href="../../plugins/bootstrap/css/bootstrap.css" rel="stylesheet">
    <!-- Animation Css -->
    <link href="../../plugins/animate-css/animate.css" rel="stylesheet" />

    <!-- Custom Css -->
    <link href="../../css/style.css" rel="stylesheet">

    <!-- AdminBSB Themes. You can choose a theme from css/themes instead of get all themes -->
    <link href="../../css/themes/all-themes.css" rel="stylesheet" />
    <link href="../../plugins/bootstrap-material-datetimepicker/css/bootstrap-material-datetimepicker.css" rel="stylesheet">
    <link href="css/Custom.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <section>
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div class="container-fluid">
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <div class="row">
                                <div class="col-sm-4">
                                    <h3>Tu plan</h3>
                                </div>
                                <div class="col-sm-6">
                                    <h3 id="MensajeH" runat="server">No tiene plan activo</h3>
                                </div>
                            </div>

                            <div class="body table-responsive" runat="server" id="divTablePlan">
                                <table class="table">
                                    <tbody>
                                        <tr>
                                            <td>Duración de meses 
                                            </td>
                                            <td>
                                                <p runat="server" id="lblDuracionMeses"></p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Fecha de inicio
                                            </td>
                                            <td>
                                                <p runat="server" id="lblfechainicio"></p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Fecha de vencimiento
                                            </td>
                                            <td>
                                                <p runat="server" id="lblfechavencimiento"></p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Sesiones con nutricionista
                                            </td>
                                            <td>
                                                <p runat="server" id="lblnutricionista"></p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Sesiones con fisioterapeuta
                                            </td>
                                            <td>
                                                <p runat="server" id="lblfisioterapeuta"></p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Congelamiento
                                            </td>
                                            <td>
                                                <p runat="server" id="lblCongelamiento"></p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Frecuencia
                                            </td>
                                            <td>
                                                <p runat="server" id="lblfrecuencia"></p>
                                            </td>
                                        </tr>
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td></td>

                                            <td>
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button Text="Congelar plan" runat="server" CssClass="btn btn-primary" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                                <asp:Button Text="Imprimir contrato" runat="server" ID="Button1" CssClass="btn btn-danger" OnClick="btnImprimirContrato_Click" />

                                            </td>
                                        </tr>
                                    </tfoot>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h3>Planes disponibles</h3>
                            <div class="body table-responsive">
                                <asp:UpdatePanel runat="server" ID="upCarrusel" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="row" id="divCarrusel">
                                            <div class="col-md-12">
                                                <section class="section-preview">
                                                    <div id="carouselExampleIndicators" class="carousel slide carousel-flujo-aprobacion" data-ride="carousel">
                                                        <!-- Indicators -->
                                                        <ol class="carousel-indicators">
                                                            <asp:Literal ID="indicadorescarouselLit" runat="server"></asp:Literal>
                                                        </ol>
                                                        <!--/.Indicators-->
                                                        <div class="carousel-inner" role="listbox">
                                                            <asp:Literal ID="creadordeRuleta" runat="server"></asp:Literal>
                                                        </div>
                                                        <!--Controls-->
                                                        <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                                                            <i class="material-icons">keyboard_arrow_left</i>
                                                            <span class="sr-only">Previous</span>
                                                        </a>
                                                        <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                                                            <i class="material-icons">keyboard_arrow_right</i>
                                                            <span class="sr-only">Next</span>
                                                        </a>
                                                        <!--/.Controls-->
                                                    </div>
                                                </section>
                                            </div>
                                        </div>
                                        <asp:HiddenField ID="hfValorSeleccionado" runat="server" ClientIDMode="Static" OnValueChanged="hfValorSeleccionado_ValueChanged" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <div class="modal fade " id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header modal-col-red">
                    <h5 class="modal-title" id="exampleModalLabel">Crear la solicitud</h5>
                </div>
                <div class="modal-body">
                    <div class="col-xs-12">
                        <h5 class="card-inside-title">Fecha de inicio </h5>
                        <div class="input-group date" id="id_EscogerFechaInicio">
                            <div class="form-line">
                                <asp:TextBox type="text" ClientIDMode="Static" ID="txtFechaIngreso" runat="server" class="form-control" placeholder="Escoja una fecha de inicio"></asp:TextBox>
                            </div>
                            <span class="input-group-addon">
                                <i class="material-icons">date_range</i>
                            </span>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <h5 class="card-inside-title">Comentario adicional </h5>
                        <div class="input-group">
                            <div class="form-line">
                                <asp:TextBox type="text" ClientIDMode="Static" ID="txtComentario" Rows="3" TextMode="MultiLine" runat="server" class="form-control no-resize" placeholder="Escoja una fecha de inicio"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div>
                        <label>Está seguro de escoger este plan, no hay sujeto a cambios. su solicitud será aprobada en un plazo de 3 días</label>
                    </div>

                </div>
                <div class="modal-footer">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <asp:HiddenField ID="hidenfield" runat="server" ClientIDMode="Static" />

                            <button type="button" class="btn btn-link waves-effect" data-dismiss="modal">Cancelar</button>
                            <asp:Button runat="server" ID="btnConfirmar" CssClass="btn btn-link waves-effect" Text="Crear solicitud de compra" OnClick="btnConfirmar_Click" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnConfirmar" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" runat="Server">
    <script src="../../plugins/bootstrap/js/bootstrap.js"></script>
    <script src="../../js/admin.js"></script>
    <script src="../../js/demo.js"></script>
    <script>
        function CambiarTextboxHF(value) {
            console.log("Valor de plan ID escogido =" + value);
            $('#hfValorSeleccionado').val(value);
            $('#hidenfield').val(value);
        }



        function mostrarModal() {
            $('#exampleModal').modal('show');
        }
        function OcultaryLimpiarModal() {
            $('#exampleModal').modal('hide');
            $('#txtFechaIngreso').val("");
            $('#txtComentario').val("");
        }
        function mostrarMensajeConfirmacion() {
            //swal('Registro Exitoso!', 'Solicitud registrada!!', 'success');
            setTimeout(function () {
                swal({
                    title: "Registro Exitoso!",
                    text: "Solicitud registrada!!",
                    type: "success"
                }, function () {
                    window.location = "SolicitudPlan.aspx";
                });
            }, 1000);


        }
        $(function () {
            $('#id_EscogerFechaInicio').datepicker({
                autoclose: true,
                container: '#id_EscogerFechaInicio'
            });
        });
    </script>

</asp:Content>

