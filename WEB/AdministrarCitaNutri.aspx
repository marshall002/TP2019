<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministrarCitaNutri.aspx.cs" Inherits="AdministrarCitaNutri" Async="true" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
    <script src="../../js/pages/ui/dialogs.js"></script>
    <link href="plugins/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="../../plugins/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css" rel="stylesheet">
    <script>$(function () {
            $(".dataTable").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });</script>
    <script>
        $("input[type='checkbox']").change(function () {
            if ($(this).is(":checked")) {
                alert('checked');
                var checkboxradio = 6;
                $('[id*=btnReprogramar]').hide();
                $("[id*=txtasistenciaChecbox]").val(checkboxradio);

            }
            else {
                alert('no checked');

                checkboxradio = 7;
                $("[id*=txtasistenciaChecbox]").val(checkboxradio);
                $('[id*=btnReprogramar]').show();
            }
        });
    </script>
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
                                <div class="header bg-red">
                                    <h2>LISTA DE CITAS<small>Nutricionista</small>
                                    </h2>
                                </div>

                                <div class="body table-responsive ">
                                    <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="true" CssClass="table table-bordered table-hover js-basic-example dataTable" DataKeyNames="PK_IC_Cod,nombres,DC_FechaHoraSolicitada,VEC_Nombre,VC_Observacion,PK_IEC_Cod"
                                        OnRowCommand="gvLista_RowCommand" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                        PageSize="9">
                                        <Columns>
                                            <asp:BoundField DataField="PK_IC_Cod" HeaderText="Codigo" />
                                            <asp:BoundField DataField="nombres" HeaderText="Nombre" />
                                            <asp:BoundField DataField="DC_FechaHoraSolicitada" HeaderText="Fecha" />
                                            <asp:BoundField DataField="VEC_Nombre" HeaderText="Estado" />
                                            <asp:BoundField DataField="VC_Observacion" HeaderText="obs" Visible="false" />
                                            <asp:BoundField DataField="PK_IEC_Cod" HeaderText="obs" Visible="false" />
                                            <asp:ButtonField ButtonType="button" HeaderText="Asistencia" CommandName="Asistencia" Text="Ver">
                                                <ControlStyle CssClass="btn btn-warning" />
                                            </asp:ButtonField>
                                            <asp:ButtonField ButtonType="button" HeaderText="Evaluacion" CommandName="Ver_Evaluacion" Text="Ver">
                                                <ControlStyle CssClass="btn btn-warning" />
                                            </asp:ButtonField>
                                            <asp:ButtonField ButtonType="button" HeaderText="Plan de dieta" CommandName="Ver_Plan" Text="Ver">
                                                <ControlStyle CssClass="btn btn-warning" />
                                            </asp:ButtonField>

                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="modal" id="VerDetalleMod" tabindex="-1" role="dialog">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">

                                            <h4 class="modal-title" id="DescModalEliminarCurso" runat="server">Detalle Cita</h4>
                                        </div>
                                        <div class="modal-body">
                                            <asp:UpdatePanel ID="upcitaNutri" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                <ContentTemplate>
                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                            <div class="input-group colorpicker">

                                                                <div class="form-line">
                                                                    <label for="textNombre">Nombres:</label>
                                                                    <asp:TextBox ID="textNombre" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                                                                </div>
                                                                <span class="input-group-addon">
                                                                    <i></i>
                                                                </span>
                                                            </div>

                                                            <div class="input-group colorpicker">
                                                                <label for="textFecha">Fecha:</label>
                                                                <div class="form-line">
                                                                    <asp:TextBox ID="txtFechaProNueva" class="form-control" runat="server" MaxLength="10"></asp:TextBox>
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
                                                                    <label for="txtobs">Duda o Consulta:</label>
                                                                    <asp:TextBox ID="textObs" TextMode="MultiLine" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
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
                                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList runat="server" ID="ddlNuevaHora" CssClass="form-control" AutoPostBack="true">
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
                                                                                <asp:ListItem Value="20:00">8:00 PM</asp:ListItem>
                                                                                <asp:ListItem Value="20:30">8:30 PM</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="ddlNuevaHora" EventName="selectedindexchanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <span class="input-group-addon">
                                                                    <i></i>
                                                                </span>
                                                            </div>
                                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
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

                                                            <div class="col-lg-6">
                                                                <asp:LinkButton ID="btnReprogramar" runat="server" CssClass="btn bg-indigo waves-effect" Style="float: left" Width="150%" Text="Guardar" OnClick="btnReprogramar_Click">
												    <i class="material-icons">alarm</i> Reprogramar
                                                                </asp:LinkButton>
                                                            </div>
                                                        </div>


                                                    </div>

                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <div class="modal-footer">
                                                <asp:UpdatePanel ID="upbotones" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                    <ContentTemplate>
                                                        <div class="form-group">
                                                            <asp:Button ID="btnGuardar" runat="server" Text="GUARDAR" CssClass="btn waves-effect waves-grey btn-success" data-type="success" OnClick="btnGuardar_Click" />
                                                            <%--<button type="button" class="btn waves-effect waves-grey btn-success" id="btnAsistencia" runat="server" data-dismiss="modal" data-type="success" onserverclick="btnAsistencia_ServerClick">GUARDAR</button>--%>
                                                            <button type="button" class="btn waves-effect waves-grey btn-danger" data-dismiss="modal">CANCELAR</button>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnGuardar" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>


    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
    <%--<script src="js/RadioButtonCustom.js"></script>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_js" runat="Server">
    <script src="js/asistencia.js"></script>

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
