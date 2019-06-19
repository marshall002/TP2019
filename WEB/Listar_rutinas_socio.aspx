<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Listar_rutinas_socio.aspx.cs" Inherits="Listar_rutinas_socio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <section>
        <div class="container-fluid">
            <div class="block-header">
                <h1>RUTINAS INSCRITAS</h1>
            </div>
            <div class="row clearfix">
                <div class="col-md-11">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="upCursos" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <div class="card">
                                <!-- form start -->
                                <br />
                                <br />

                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10">
                                        <asp:Panel ID="Panel1" runat="server" CssClass="auto-style1">
                                            <asp:GridView ID="gvRutinasinscritas" runat="server" AutoGenerateColumns="False" DataKeyNames="FK_IR_Cod,DR_FechaRutina,DUR_FechaHora,VR_Nombre" GridLines="None" AllowPaging="true" CssClass="table table-striped table-hover" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" PageSize="7" OnPageIndexChanging="gvRutinasinscritas_PageIndexChanging" OnRowCommand="gvRutinasinscritas_RowCommand">
                                                <Columns>
                                                    <asp:BoundField DataField="FK_IR_Cod" HeaderText="cod rutina" Visible="false" />
                                                    <asp:BoundField DataField="DR_FechaRutina" HeaderText="fecha rutina" Visible="false" />
                                                    <asp:BoundField DataField="DUR_FechaHora" HeaderText="Fecha" />
                                                    <asp:BoundField DataField="VR_Nombre" HeaderText="Tipo Rutina" />
                                                    <asp:ButtonField ButtonType="button" HeaderText="Crossfit" CommandName="Actualizar" Text="Actualizar">
                                                        <ControlStyle CssClass="btn btn-warning" />
                                                    </asp:ButtonField>

                                                </Columns>
                                                <Columns>

                                                    <asp:ButtonField ButtonType="button" HeaderText="Functional" CommandName="Eliminar" Text="Eliminar">
                                                        <ControlStyle CssClass="btn btn-danger" />
                                                    </asp:ButtonField>
                                                </Columns>

                                            </asp:GridView>
                                            <div class="col-lg-3 right">
                                                <div class="modal fade" id="modalActualizacion" tabindex="-1" role="dialog">
                                                    <div class="modal-dialog" role="document">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <h4 class="modal-title" id="ModalActIns" runat="server">Actualizar Hora de Clase</h4>
                                                            </div>
                                                            <div class="modal-body">
                                                               
                                                                  <div class="col-lg-12">
                                                                    <asp:UpdatePanel ID="upFecha_Rutina" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                                        <ContentTemplate>
                                                                            <div class="form-group">
                                                                                <label class="form-label">Tipo Rutina</label>
                                                                                <div class="form-line">
                                                                                    <asp:TextBox ID="txtTipoR" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group">
                                                                                <label class="form-label">Fecha</label>
                                                                                <div class="form-line">
                                                                                    <asp:TextBox ID="txtfechaClase" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                    <div class="form-group">
                                                                        <label class="form-label">Hora</label>
                                                                        <asp:UpdatePanel ID="Udp_ddlhoras" runat="server" UpdateMode="Conditional">
                                                                            <ContentTemplate>
                                                                                <div class="form-line">
                                                                                    <asp:DropDownList ID="ddlHoras" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlHoras_SelectedIndexChanged" AutoPostBack="true">
                                                                                        <%--<asp:ListItem Value="NULO">Seleccione la hora</asp:ListItem>--%>
                                                                                        <%--<asp:ListItem Value="08:00">8:00 AM</asp:ListItem>
                                                                                        <asp:ListItem Value="09:00">9:00 AM</asp:ListItem>
                                                                                        <asp:ListItem Value="10:00">10:00 AM</asp:ListItem>
                                                                                        <asp:ListItem Value="11:00">11:00 AM</asp:ListItem>
                                                                                        <asp:ListItem Value="12:00">12:00 PM</asp:ListItem>
                                                                                        <asp:ListItem Value="13:00">1:00 PM</asp:ListItem>
                                                                                        <asp:ListItem Value="14:00">2:00 PM</asp:ListItem>
                                                                                        <asp:ListItem Value="15:00">3:00 PM</asp:ListItem>
                                                                                        <asp:ListItem Value="16:00">4:00 PM</asp:ListItem>
                                                                                        <asp:ListItem Value="17:00">5:00 PM</asp:ListItem>
                                                                                        <asp:ListItem Value="18:00">6:00 PM</asp:ListItem>
                                                                                        <asp:ListItem Value="19:00">7:00 PM</asp:ListItem>
                                                                                        <asp:ListItem Value="20:00">8:00 PM</asp:ListItem>--%>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:AsyncPostBackTrigger ControlID="ddlHoras" EventName="selectedindexchanged" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                            <div class="modal-footer">
                                                                <button type="button" class="btn btn-link waves-effect waves-grey btn-danger" data-dismiss="modal">CANCELAR</button>
                                                                <button type="button" class="btn btn-link waves-effect waves-grey btn-success" id="btnActualizar" runat="server" data-dismiss="modal" data-type="success" onserverclick="btnActualizar_ServerClick">ACTUALIZAR</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="modal fade" id="modalconfirmacioneliminarIns" tabindex="-1" role="dialog">
                                                <div class="modal-dialog" role="document">
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <h4 class="modal-title" id="DescModalEliminarInscripcion" runat="server">¿Seguro desea eliminar su Inscripcion a la rutina?</h4>
                                                        </div>
                                                        <div class="modal-body">
                                                        </div>
                                                        <div class="modal-footer">
                                                            <button type="button" class="btn btn-link waves-effect waves-grey" data-dismiss="modal">CANCELAR</button>
                                                            <button type="button" class="btn btn-link waves-effect waves-grey" id="btnEliminarInscripcion" runat="server" data-dismiss="modal" onserverclick="btnEliminarInscripcion_ServerClick">ELIMINAR</button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </div>
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
</asp:Content>

