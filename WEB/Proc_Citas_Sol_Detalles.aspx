<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Proc_Citas_Sol_Detalles.aspx.cs" Inherits="Sol_Citas_Detalles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
    <script>
        $(document).ready(function () {
            $("[id*=cbx_Fisioterapeuta]").prop('disabled', true);
            $("[id*=cbx_Nutricionista]").prop('disabled', true);
            $("[id*=txtFecha]").prop('disabled', true);
            $("[id*=txtHoras]").prop('disabled', true);
            $("[id*=txtDudaConsulta]").prop('disabled', true);
            $("[id*=ddlHoras]").prop('disabled', true);
            $("[id*=txtFechaProNueva]").prop('disabled', false);
            $("[id*=txtUsuarioSolicitante]").prop('disabled', true);
            $("[id*=txtEstadoSolicitud]").prop('disabled', true);
            $("[id*=txtApellidos]").prop('disabled', true);
            $("[id*=txtServicios]").prop('disabled', true);




        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <section>
        <div class="container-fluid">
            <div class="block-header">
                <h1></h1>
            </div>
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="upCursos" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <div class="card">
                                <div class="header">
                                    <h1>Detalles de la solicitud Codigo: <%:Session["CodigoSolicitudCita"]%></h1>
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
                                <div class="body">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="row clearfix">
                                                <div class="col-md-12">
                                                    <div class="form-group form-float">
                                                        <label class="form-label">Nombres</label>
                                                        <div class="form-line focused">
                                                            <div class="form-line">
                                                                <asp:TextBox ID="txtUsuarioSolicitante" class="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="row clearfix">
                                                <div class="col-md-12">
                                                    <div class="form-group form-float">
                                                        <label class="form-label">Apellidos</label>
                                                        <div class="form-line focused">
                                                            <div class="form-line">
                                                                <asp:TextBox ID="txtApellidos" class="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="row clearfix">
                                                <div class="col-md-12">
                                                    <div class="form-group form-float">
                                                        <label class="form-label">Estado de la Solicitud</label>
                                                        <div class="form-line focused">
                                                            <div class="form-line">
                                                                <asp:TextBox ID="txtEstadoSolicitud" class="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="row clearfix">
                                                <div class="col-sm-12">
                                                    <div class="form-group form-float">
                                                        <label class="form-label">Fecha de la solicitud</label>
                                                        <div class="form-line focused">
                                                            <div class="form-line">
                                                                <asp:TextBox ID="txtFecha" class="form-control" runat="server" TextMode="Date" MaxLength="10"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="row clearfix">
                                                <div class="col-sm-12">
                                                    <label class="form-label">Hora</label>
                                                    <asp:TextBox ID="ddlHoras" class="form-control" runat="server" MaxLength="10"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="row clearfix">
                                                <div class="col-sm-12">
                                                    <div class="form-group">
                                                        <label class="form-label">Duda o consulta</label>
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtDudaConsulta" runat="server" TextMode="multiline" Rows="9" class="form-control no-resize" placeholder="Ingrese la consulta brevemente"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <label class="form-label">Servicio</label>
                                            <asp:TextBox ID="txtServicios" class="form-control" runat="server"></asp:TextBox>

                                        </div>
                                        <div class="col-lg-6">
                                            <h2 class="card-inside-title form-inline">Aprobar</h2>
                                            <div class="switch">
                                                <label id="rechazadotxt">Rechazado</label>
                                                <label>
                                                    <input type="checkbox" id="chbresultadoAprob"><span class="lever switch-col-indigo"></span></label>
                                                <label id="aprobadotxt">Aprobado</label>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:LinkButton ID="btnReprogramar" runat="server" CssClass="btn bg-indigo waves-effect" Style="float: left" Width="40%" Text="Guardar" OnClick="btnReprogramar_Click">
												<i class="material-icons">alarm</i> Reprogramar
                                            </asp:LinkButton>
                                        </div>
                                        <%--</div>--%>
                                        <%--<div class="row">--%>

                                        <div class="col-lg-3 right">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always"
                                                ChildrenAsTriggers="true">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="btnGuardar1" runat="server" CssClass="btn bg-indigo waves-effect" Style="float: right" Text="Guardar" OnClick="btnGuardar_ServerClick">
												<i class="material-icons">save</i> Guardar
                                                    </asp:LinkButton>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnGuardar1" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always"
                                                ChildrenAsTriggers="true">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="btnCancelar1" runat="server" CssClass="btn bg-red waves-effect" Style="float: right" Text="Cancelar" PostBackUrl="~/Proc_Citas_Sol_Listar.aspx" OnClick="btnCancelar_ServerClick">
												<i class="material-icons">arrow_back</i>Regresar
                                                    </asp:LinkButton>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnCancelar1" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <%--<asp:HiddenField ID="txtresultadoChecbox" runat="server" />--%>
                                            <asp:HiddenField ID="txtresultadoChecbox" runat="server" />

                                            <div class="modal fade" id="modalreprogramar" tabindex="-1" role="dialog">
                                                <div class="modal-dialog" role="document">
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <h4 class="modal-title" id="DescModalEliminarCita" runat="server">Escoja la fecha y hora para la reprogramación</h4>
                                                        </div>
                                                        <div class="modal-body">
                                                            <div class="form-group">
                                                                <label class="form-label">
                                                                    Nueva fecha</label>
                                                                <div class="form-line">
                                                                    <asp:TextBox ID="txtFechaProNueva" class="form-control" runat="server" TextMode="Date" MaxLength="10"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="form-label">Nueva hora</label>
                                                                <div class="form-line">
                                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList runat="server" ID="ddlNuevaHora" CssClass="form-control" OnSelectedIndexChanged="ddlNuevaHora_SelectedIndexChanged" AutoPostBack="true">
                                                                                <asp:ListItem Value="NULO">Seleccione la hora</asp:ListItem>
                                                                                <asp:ListItem Value="15:30">3:30 PM</asp:ListItem>
                                                                                <asp:ListItem Value="16:00">4:00 PM</asp:ListItem>
                                                                                <asp:ListItem Value="16:30">4:30 PM</asp:ListItem>
                                                                                <asp:ListItem Value="17:00">5:00 PM</asp:ListItem>
                                                                                <asp:ListItem Value="17:30">5:30 PM</asp:ListItem>
                                                                                <asp:ListItem Value="18:00">6:00 PM</asp:ListItem>
                                                                                <asp:ListItem Value="18:30">6:30 PM</asp:ListItem>
                                                                                <asp:ListItem Value="19:00">7:00 PM</asp:ListItem>
                                                                                <asp:ListItem Value="19:30">7:30 PM</asp:ListItem>
                                                                                <asp:ListItem Value="20:00">8:30 PM</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="ddlNuevaHora" EventName="selectedindexchanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="modal-footer">
                                                            <button type="button" class="btn btn-link waves-effect waves-grey" data-dismiss="modal">CANCELAR</button>
                                                            <button type="button" class="btn btn-link waves-effect waves-grey" id="btnaceptar" runat="server" data-dismiss="modal" data-type="success" onserverclick="btnReproSCita_ServerClick">REPROGRAMAR</button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                </div>
                            </div>

                        </ContentTemplate>
                        <Triggers>

                            <asp:AsyncPostBackTrigger ControlID="btnaceptar" />

                        </Triggers>

                    </asp:UpdatePanel>

                </div>
            </div>

        </div>

    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
    <script src="js/CheckboxCustom.js"></script>
    <%--<script src="js/RadioButtonCustom.js"></script>--%>
</asp:Content>

