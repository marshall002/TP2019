<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Realizar_Pago.aspx.cs" Inherits="Realizar_Pago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">

    <script type="text/javascript">
        function openModal() {
            $('#ActivarProducto').modal('show');
        }
    </script>

    <script type="text/javascript">
        function SoloNumeros(e) {
            var key_press = document.all ? key_press = e.keyCode : key_press = e.which;
            return ((key_press > 47 && key_press < 58) || key_press == 46);
        }

        function SoloLetras() {
            if ((event.keyCode >= 65) && (event.keyCode <= 90) || (event.keyCode >= 97) && (event.keyCode <= 122)) {
                event.returnValue = true;
            }
            else {
                event.returnValue = false;
            }

        }
    </script>

    <asp:ScriptManager ID="ScriptManager1"
        runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <section>
                <contenttemplate></contenttemplate>
                <div class="container-fluid">
                    <div class="block-header">
                        <h1>Realizar Pagos</h1>
                    </div>
                    <div class="row clearfix">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                                <div class="header">
                                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" class="btn btn-block btn-md btn-primary waves-effect" aria-hidden="true" OnClick="btnRegistrar_Click" />
                                </div>
                                <asp:HiddenField ID="txtmostrarcod" runat="server" />

                                <div class="body table-responsive ">
                                    <asp:GridView ID="gvRegistrarPago" class="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="PK_ICP_Cod, DCP_FechaHoraRealizada, ICP_NFisio, ICP_NNutri, VCP_Estado_Pago" EmptyDataText="No tiene pagos registradas" ShowHeaderWhenEmpty="True" OnRowCommand="gvRegistrarPago_RowCommand" OnSelectedIndexChanged="gvRegistrarPago_SelectedIndexChanged">
                                        <Columns>
                                            <asp:BoundField DataField="PK_ICP_Cod" HeaderText="Codigo" />
                                            <asp:BoundField DataField="DCP_FechaHoraRealizada" HeaderText="Fecha de Pago" />
                                            <asp:BoundField DataField="ICP_NFisio" HeaderText="N° de Citas Fisioterapeuta." />
                                            <asp:BoundField DataField="ICP_NNutri" HeaderText="N° de Citas Nutricionista" />
                                            <asp:BoundField DataField="VCP_Estado_Pago" HeaderText="Estado" />
                                            <asp:ButtonField ButtonType="button" HeaderText="Evaluacion" CommandName="Ver Pago" Text="Ver">
                                                <ControlStyle CssClass="btn btn-primary" />
                                            </asp:ButtonField>
                                            <asp:ButtonField ButtonType="button" HeaderText="Actualizar" CommandName="ver Actualizar" Text="Actualizar">
                                                <ControlStyle CssClass="btn btn-danger" />
                                            </asp:ButtonField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
            </section>
            <div class="modal fade" id="VerPago" tabindex="-1" role="dialog">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="ModalVerPago" runat="server">Verificar Pago</h4>
                        </div>
                        <div class="modal-body">
                            <div class="input-group ">
                                <div class="form-line">
                                    <label for="textComprobante">Comprobante:</label><br />
                                    <div class="col-lg-4">
                                        <asp:Image ID="textImagen" Width="250" Height="200" runat="server" CssClass="form-control" src="../images/boucher.jpg"></asp:Image>
                                    </div>
                                </div>
                                <span class="input-group-addon">
                                    <i></i>
                                </span>
                            </div>

                            <div class="form-group">
                                <div class="form-line">
                                    <h5>N° Operación:</h5>
                                    <asp:Label ID="txt_noperacion" runat="server" Width="300px" class="form-control" placeholder="N° Operación" Enabled="false"></asp:Label>
                                </div>
                            </div>
                            <br />

                            <div class="form-group">
                                <div class="form-line">
                                    <h5>N° Citas Fisio :</h5>
                                    <asp:Label ID="txt_nfisio" runat="server" Width="300px" class="form-control" placeholder="N° Citas Fisio" Enabled="false"></asp:Label>
                                </div>
                            </div>
                            <br />

                            <div class="form-group">
                                <div class="form-line">
                                    <h5>N° Citas Nutri :</h5>
                                    <asp:Label ID="txt_nnutri" runat="server" Width="300px" class="form-control" placeholder="N° Citas Nutri" Enabled="false"></asp:Label>
                                </div>
                            </div>

                            <br />
                            <div class="form-group">
                                <div class="form-line">
                                    <h5>Monto :</h5>
                                    <asp:Label ID="txt_monto" runat="server" class="form-control" Enabled="false"></asp:Label>
                                    Soles
                                </div>
                            </div>
                            <br />

                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="Button2" runat="server" class="btn btn-danger" Text="Cancelar" data-dismiss="modal" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="modal fade" id="Actualizarprueba" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="H1" runat="server">Actualizar Pago</h4>
                </div>
                <div class="modal-body">
                    <div class="input-group ">
                        <div class="form-line">
                            <label for="textComprobante">Comprobante:</label><br />
                            <div class="col-lg-4">
                                <asp:Image ID="Image1" Width="250" Height="200" runat="server" CssClass="form-control" src="../images/boucher.jpg"></asp:Image>
                            </div>
                        </div>
                        <span class="input-group-addon">
                            <i></i>
                        </span>
                    </div>

                    <div class="form-group">
                        <div class="form-line">
                            <h5>N° Operación:</h5>
                            <asp:TextBox ID="txt_noperacion1" runat="server" Width="300px" class="form-control" placeholder="N° Operación"></asp:TextBox>
                        </div>
                    </div>
                    <br />

                    <div class="form-group">
                        <div class="form-line">
                            <h5>N° Citas Fisio :</h5>
                            <asp:TextBox ID="txt_nfisio1" runat="server" Width="300px" class="form-control" placeholder="N° Citas Fisio"></asp:TextBox>
                        </div>
                    </div>
                    <br />

                    <div class="form-group">
                        <div class="form-line">
                            <h5>N° Citas Nutri :</h5>
                            <asp:TextBox ID="txt_nnutri1" runat="server" Width="300px" class="form-control" placeholder="N° Citas Nutri"></asp:TextBox>
                        </div>
                    </div>

                    <br />
                    <div class="form-group">
                        <div class="form-line">
                            <h5>Monto (ssoles):</h5>
                            <asp:TextBox ID="txt_monto1" runat="server" Width="300px" class="form-control" placeholder="Monto"></asp:TextBox>
                        </div>
                    </div>
                    <br />

                    <div class="modal-footer">
                        <asp:Button ID="btnActualizar" runat="server" class="btn btn-success" Text="Actualizar" OnClick="btnActualizar_Click" />
                        <asp:Button ID="btnAtras" runat="server" class="btn btn-danger" Text="Atras" OnClick="btnAtras_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" runat="Server">
</asp:Content>

