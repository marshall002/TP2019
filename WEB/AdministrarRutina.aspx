<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministrarRutina.aspx.cs" Inherits="AdministrarRutina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <section>
        <div class="container-fluid">
            <div class="block-header">
                <h1>Administrar Rutina</h1>
            </div>
            <div class="row clearfix">
                <div class="col-md-11">
                    <script src="plugins/bootstrap/js/bootstrap.js"></script>
                    <asp:scriptmanager id="ScriptManager1" runat="server"></asp:scriptmanager>
                    <asp:updatepanel id="upCursos" runat="server" updatemode="Conditional" childrenastriggers="false">
                        <ContentTemplate>
                            <div class="card">
                                <!-- form start -->
                                <div class="row">
                                    <br />
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-3">
                                        <label for="lblCliente">Seleccionar Mes: </label>
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
                                    <div class="col-lg-2"></div>
                                    <div class="col-lg-8">
                                        <asp:Panel ID="Panel1" runat="server" CssClass="auto-style1">
                                            <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" DataKeyNames="n1" GridLines="None" AllowPaging="true" CssClass="table table-striped table-hover"
                                                OnRowCommand="gvLista_RowCommand1" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" PageSize="7" OnPageIndexChanging="gvLista_PageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField DataField="n1" HeaderText="Inicio de Semana" />
                                                    <asp:TemplateField HeaderText="Crossfit">
                                                        <ItemTemplate>
                                                            <asp:LinkButton CssClass="btn bg-green waves-effect" ID="btnRegistrarC" runat="server" CommandArgument='<%# Container.DataItemIndex %>' CommandName="RegistrarC" data-toggle="tooltip" data-placement="right" title="Registrar Crossfit" Text="Registrar">
                                                                 <i class="material-icons">add</i>
                                                            </asp:LinkButton>
                                                            <asp:LinkButton CssClass="btn bg-orange waves-effect" ID="btnVerC" runat="server" CommandArgument='<%# Container.DataItemIndex %>' CommandName="VerC" data-toggle="tooltip" data-placement="right" title="Ver Crossfit" Text="Ver rutina">
                                                                 <i class="material-icons">create</i>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Functional">
                                                        <ItemTemplate>
                                                            <asp:LinkButton CssClass="btn bg-green waves-effect" ID="btnRegistrarF" runat="server" CommandArgument='<%# Container.DataItemIndex %>' CommandName="RegistrarF" data-toggle="tooltip" data-placement="right" title="Registrar Functional" Text="Registrar">
                                                                 <i class="material-icons">add</i>
                                                            </asp:LinkButton>
                                                            <asp:LinkButton CssClass="btn bg-orange waves-effect" ID="btnVerF" runat="server" CommandArgument='<%# Container.DataItemIndex %>' CommandName="VerF" data-toggle="tooltip" data-placement="right" title="Actualizar Functional" Text="Ver rutina">
                                                                 <i class="material-icons">create</i>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>

                                            </asp:GridView>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:updatepanel>
                </div>
            </div>
        </div>
        <!-- The Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog">
            <div class="modal-dialog" style="width: 1000px">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">
                            <asp:label id="TituloTRut" runat="server"></asp:label>
                        </h4>
                    </div>
                    <asp:updatepanel id="UpdatePanel1" runat="server" updatemode="Conditional" childrenastriggers="false">
                        <ContentTemplate>
                            <!-- Modal body -->
                            <div class="modal-body" id="modal-rutina">
                                <div class="row">

                                    <div class="form-group">
                                        <label class="form-label">Fecha</label>
                                        <div class="form-line">
                                            <asp:TextBox ID="txtfechaRuti" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <label class="form-label">Descripción</label>

                                            <div class="form-line">
                                                <asp:TextBox ID="txtdescripcion" runat="server" TextMode="multiline" Rows="4" class="form-control no-resize" placeholder="Ingrese la descripción"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Modal footer -->
                                    <br />
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-link waves-effect waves-grey btn-success" id="btnGuardar" runat="server" data-dismiss="modal" data-type="success" onserverclick="btnGuardar_ServerClick">GUARDAR</button>
                                </div>
                               
                        </ContentTemplate>
                    </asp:updatepanel>
                </div>
            </div>
        </div>
        </div>

        

        <div class="modal fade" id="myModal2" tabindex="-1" role="dialog">
            <div class="modal-dialog" style="width: 1000px">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">
                            <asp:label id="Label1" runat="server"></asp:label>
                        </h4>
                    </div>
                    <asp:updatepanel id="UpdatePanel2" runat="server" updatemode="Conditional" childrenastriggers="false">
                         <ContentTemplate>
                             <!-- Modal body -->
                             <div class="modal-body" id="test">
                                 <div class="row">

                                     <div class="form-group">
                                         <label class="form-label">Fecha</label>
                                         <div class="form-line">
                                             <asp:TextBox ID="txtfechaVer" runat="server" CssClass="form-control"></asp:TextBox>
                                         </div>

                                         <div class="form-group">
                                             <label class="form-label">Descripción</label>

                                             <div class="form-line">
                                                 <asp:TextBox ID="txtVerDesc" runat="server" TextMode="multiline" Rows="4" class="form-control no-resize" placeholder="Ingrese la descripción"></asp:TextBox>
                                             </div>
                                         </div>
                                     </div>

                                     <!-- Modal footer -->
                                     <br />
                                 </div>
                                 <div class="modal-footer">
                                     <button type="button" class="btn btn-link waves-effect waves-grey btn-success" id="btnactualizar" runat="server" data-dismiss="modal" data-type="success" onserverclick="btnactualizar_ServerClick">Actualizar</button>
                                     <button type="button" class="btn btn-link waves-effect waves-grey btn-success" id="btneliminar" runat="server" data-dismiss="modal" data-type="success" onserverclick="btneliminar_ServerClick">Eliminar</button>
                                
                                     </div>
                         </ContentTemplate>
                     </asp:updatepanel>
                </div>
            </div>
        </div>

    </section>
    <%--<script src="js/Rutina.js"></script>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
</asp:Content>


