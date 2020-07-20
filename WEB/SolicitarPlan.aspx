<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SolicitarPlan.aspx.cs" Inherits="SolicitarPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
    <link href="../../plugins/bootstrap/css/bootstrap.css" rel="stylesheet">
    <!-- Animation Css -->
    <link href="../../plugins/animate-css/animate.css" rel="stylesheet" />

    <!-- Custom Css -->
    <link href="../../css/style.css" rel="stylesheet">

    <!-- AdminBSB Themes. You can choose a theme from css/themes instead of get all themes -->
    <link href="../../css/themes/all-themes.css" rel="stylesheet" />
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
                            <h3>Planes disponibles</h3>
                            <div class="body table-responsive">
                                Dni:  
                                <asp:TextBox ID="txtDni" runat="server" Text="" Enabled="false"></asp:TextBox>

                                estado del plan:  
                                <asp:TextBox ID="txtultimoestadodelplan" runat="server" Text="" Enabled="false"></asp:TextBox>
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

    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Crear la solicitud</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    Está seguro de escoger este plan, no hay sujeto a cambios. su solicitud será aprobada despues

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <asp:Button runat="server" ID="btnConfirmar" CssClass="btn btn-primary" Style="float: right" Text="Crear solicitud de compra" OnClick="btnConfirmar_Click" />
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
        }
        function mostrarModal() {
            $('#exampleModal').modal('show');
        }
    </script>

</asp:Content>

