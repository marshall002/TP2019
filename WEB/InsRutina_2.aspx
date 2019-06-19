<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InsRutina_2.aspx.cs" Inherits="InsRutina_2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <section>
        <div class="container-fluid">
            <div class="block-header">
                <h1 id="titulo">INSCRIBIR A RUTINA</h1>
            </div>
            <div class="row clearfix">
                <div class="col-md-11">
                    <asp:scriptmanager id="ScriptManager1" runat="server"></asp:scriptmanager>
                    <asp:updatepanel id="upCursos" runat="server" updatemode="Conditional" childrenastriggers="false">
                        <ContentTemplate>
                            <div class="card">
                                <!-- form start -->
                                <div class="row">
                                    <br />
                                    <div class="col-lg-12">
                                        <div class="col-lg-6">
                                            <asp:UpdatePanel ID="upEjercicios" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                              <ContentTemplate>
                                                 <div class="form-group">
                                                     <label class="form-label">
                                                          Rutina</label>
                                                    </div>
                                                 <div class="form-group">
                                                   <%--<asp:TextBox ID="txtEjercicios" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>--%>
                                                   <%--<asp:GridView ID="GridView2" runat="server"></asp:GridView>--%>  
                                                     <asp:GridView ID="GvEjercicios" runat="server" AutoGenerateColumns="False" DataKeyNames="PK_IR_Cod,VR_DescripcionE,VR_Duracion,IR_Repeticion"
                                                           GridLines="None" AllowPaging="true" CssClass="table table-striped table-hover" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                                                            <Columns>
                                                                     <asp:BoundField DataField="PK_IR_Cod" HeaderText="cod rutina" Visible="false" />
                                                                     <asp:BoundField DataField="VR_DescripcionE" HeaderText="Ejercicio" />
                                                                     <asp:BoundField DataField="VR_Duracion" HeaderText="Duracion" />
                                                                     <asp:BoundField DataField="IR_Repeticion" HeaderText="Repeticion" />
                                                            </Columns>
                                                       </asp:GridView>
                                                   </div>
                                              </ContentTemplate>
                                          </asp:UpdatePanel>
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
                                                            <asp:DropDownList ID="ddlHoras" runat="server" CssClass="form-control" AutoPostBack="true">
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
                                    <div class="col-lg-3 right">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always"
                                        ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="btnCancelar1" runat="server" CssClass="btn bg-red waves-effect" Style="float: right" Width="33%" Text="Cancelar" PostBackUrl="~/Inscribir_Rutina.aspx" OnClick="btnCancelar_ServerClick">
												<i class="material-icons">arrow_back</i>Regresar
                                            </asp:LinkButton>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnCancelar1" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>

                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always"
                                        ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="btnGuardar1" runat="server" CssClass="btn bg-indigo waves-effect" Style="float: right" Width="33%" Text="Guardar" OnClick="btnGuardar_ServerClick">
												<i class="material-icons">save</i> Registrar
                                            </asp:LinkButton>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnGuardar1" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    </div>
                                    <div class="col-lg-12">
                                        <br/>
                                        
                                    </div>
                                  </div>
                             </div>
                          </ContentTemplate>
                     </asp:updatepanel>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" runat="Server">
</asp:Content>

