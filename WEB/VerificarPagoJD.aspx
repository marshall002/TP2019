<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VerificarPagoJD.aspx.cs" Inherits="VerificarPagoJD" Async="true" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">

    <link href="plugins/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <asp:ScriptManager ID="ScriptManager1"
        runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel" runat="server"></asp:UpdatePanel>
    <section>
        <div class="container-fluid">
            <div class="block-header">
                <h1>Verificar Pagos</h1>
            </div>
            <div class="card">
                <div class="row clearfix">
                    <!-- left column -->
                    <div class="col-md-11">
                        <!-- general form elements -->
                        <div class="box box-primary">
                            <!-- form start -->
                                <div class="row clearfix">
                                    <br />
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-3">
                                        <label for="lblCliente">Socio: </label>
                                        <asp:TextBox ID="txtBsocio" runat="server" CssClass="form-control" Width="250px" Height="30px"></asp:TextBox>


                                    </div>
                                    <div class="col-lg-3">
                                        <br />
                                        <button class="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-search"></span>Buscar</button>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="col-lg-4"></div>
                                        <br />
                                    </div>
                                </div>
                                <br />
                                <br />

                                <div class="row">

                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10">
                                        <asp:Panel ID="Panel1" runat="server" CssClass="auto-style1">
                                            <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" GridLines="None" AllowPaging="true" CssClass="table table-striped table-hover" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" PageSize="9">
                                                <Columns>

                                                    <asp:BoundField DataField="nombres" HeaderText="Nombre" />
                                                    <asp:BoundField DataField="DCP_FechaHoraRealizada" HeaderText="Fecha" />
                                                    <asp:BoundField DataField="ICP_NNutri" HeaderText="N° Nutri" />
                                                    <asp:BoundField DataField="ICP_NFisio" HeaderText="N° Fisio" />
                                                    <asp:ButtonField ButtonType="button" HeaderText="Evaluacion" CommandName="Ver evaluacion" Text="Ver">
                                                        <ControlStyle CssClass="btn btn-warning" />
                                                    </asp:ButtonField>
                                                    <asp:BoundField DataField="VCP_Estado_Pago" HeaderText="Estado" />
                                                    <asp:ButtonField ButtonType="button" HeaderText="Accion 1" CommandName="Ver evaluacion" Text="Aceptar Pago Realizado">
                                                        <ControlStyle CssClass="btn btn-success" />

                                                    </asp:ButtonField>
                                                    <asp:ButtonField ButtonType="button" HeaderText="Accion 2" CommandName="Ver" Text="Reportar Pago Usuario">
                                                        <ControlStyle CssClass="btn btn-danger" />
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
    <div id="modal_no">
        <div class="modal" id="VerDetalleMod" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">

                        <h4 class="modal-title" id="DescModalEliminarCurso" runat="server">Detalle Cita</h4>
                    </div>
                    <div class="modal-body">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <div class="input-group colorpicker">

                                    <div class="form-line">
                                        <label for="textNombre">Nombres:</label>
                                        <asp:TextBox ID="textNombre" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <span class="input-group-addon">
                                        <i></i>
                                    </span>
                                </div>

                                <div class="input-group colorpicker">
                                    <div class="form-line">
                                        <label for="textFecha">Fecha:</label>
                                        <asp:TextBox ID="textFecha" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <span class="input-group-addon">
                                        <i></i>
                                    </span>
                                </div>

                                <div class="input-group colorpicker">
                                    <style>
                                        #textObs {
                                            resize: none;
                                        }
                                    </style>
                                    <div class="form-line">
                                        <label for="textObs">Duda o Consulta:</label>
                                        <asp:TextBox ID="textObs" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <span class="input-group-addon">
                                        <i></i>
                                    </span>
                                </div>
                            </div>

                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <div class="input-group colorpicker">
                                    <div class="form-line">
                                        <label for="textHora">Hora:</label>
                                        <asp:TextBox ID="textHora" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <span class="input-group-addon">
                                        <i></i>
                                    </span>
                                </div>

                                <div class="form-group">
                                    <label>Asistencia:</label>
                                    <div class="input-group">
                                        <input type="radio" id="chk1" class="filled-in" value="2" name="chk">
                                        <label for="chk1">Si</label>
                                    </div>
                                    <div class="input-group">
                                        <input type="radio" id="chk2" class="filled-in" value="3" name="chk">

                                        <label for="chk2">No</label>
                                    </div>
                                </div>


                            </div>

                        </div>
                        <div class="modal-footer">

                            <div class="form-group">
                                <div class="form-group">
                                    <input type="button" value="Guardar" class="btn btn-success" runat="server">
                                    <input type="button" value="Cerrar" class="btn btn-danger" onclick="closeModal();">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>





</asp:Content>

