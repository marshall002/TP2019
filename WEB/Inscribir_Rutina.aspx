<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Inscribir_Rutina.aspx.cs" Inherits="Inscribir_Clase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <section>
        <div class="container-fluid">
            <div class="block-header">
                <h1>INSCRIBIR A RUTINA</h1>
            </div>
            <div class="row clearfix">
                <div class="col-md-11">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="upCursos" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <div class="card">
                                <!-- form start -->
                                <div class="row">
                                    <br />
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-3">
                                        <label for="lblmes">Seleccionar Mes: </label>
                                        <asp:DropDownList runat="server" ID="ddlMes" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged">

                                            <asp:ListItem Value="1">Enero</asp:ListItem>
                                            <asp:ListItem Value="2">Febrero</asp:ListItem>
                                            <asp:ListItem Value="3">Marzo</asp:ListItem>
                                            <asp:ListItem Value="4">Abril</asp:ListItem>
                                            <asp:ListItem Value="5">Mayo</asp:ListItem>
                                            <asp:ListItem Value="6">Junio</asp:ListItem>
                                            <asp:ListItem Value="7">Julio</asp:ListItem>
                                            <asp:ListItem Value="8">Agosto</asp:ListItem>
                                            <asp:ListItem Value="9">Setiembre</asp:ListItem>
                                            <asp:ListItem Value="10">Octubre</asp:ListItem>
                                            <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                            <asp:ListItem Value="12">Diciembre</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-3">
                                    </div>
                                    <div class="col-lg-4">
                                        <label for="lblCliente">Fecha de hoy: </label>
                                        <asp:TextBox ID="txtfecha" runat="server" ReadOnly CssClass="form-control" Width="250px" Height="30px"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <br />

                                <div class="row">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10">
                                        <asp:Panel ID="Panel1" runat="server" CssClass="auto-style1">
                                            <asp:GridView ID="gvDiasRutinas" runat="server" AutoGenerateColumns="False" DataKeyNames="n1" GridLines="None" AllowPaging="true" CssClass="table table-striped table-hover" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" PageSize="7" OnPageIndexChanging="gvDiasRutinas_PageIndexChanging" OnRowCommand="gvDiasRutinas_RowCommand">
                                                <Columns>
                                                    <asp:BoundField DataField="n1" HeaderText="Fecha" />
                                                    <asp:BoundField DataField="n2" HeaderText="Dia" />


                                                    <asp:ButtonField ButtonType="button" HeaderText="Crossfit" CommandName="VerC" Text="Ver">
                                                        <ControlStyle CssClass="btn btn-info" />
                                                    </asp:ButtonField>

                                                </Columns>
                                                <Columns>

                                                    <asp:ButtonField ButtonType="button" HeaderText="Functional" CommandName="VerF" Text="Ver">
                                                        <ControlStyle CssClass="btn btn-info" />
                                                    </asp:ButtonField>
                                                </Columns>

                                            </asp:GridView>
                                            <div class="col-lg-3 right">
                                                <div class="modal fade" id="modalInscripcion" tabindex="-1" role="dialog">
                                                    <div class="modal-dialog" role="document">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <h4 class="modal-title" id="ModalRutina" runat="server">Inscribir Clase</h4>
                                                            </div>
                                                            <div class="modal-body">
                                                                <div class="col-lg-6">
                                                                    <div class="form-group">
                                                                        <label class="form-label">
                                                                            Rutina</label>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:TextBox ID="txtEjercicios" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-6">
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
                                                                <button type="button" class="btn btn-link waves-effect waves-grey btn-success" id="btnInscribir" runat="server" data-dismiss="modal" data-type="success" onserverclick="btnInscribir_ServerClick">INSCRIBIR</button>
                                                            </div>
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

