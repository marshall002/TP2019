<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdministrarRutina_Extra.aspx.cs" Inherits="AdministrarRutina_Extra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">

        <section>
        <div class="container-fluid">
            <div class="block-header">
                <h1>Administrar Rutinas</h1>
            </div>
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <asp:scriptmanager id="ScriptManager1" runat="server"></asp:scriptmanager>
                    <asp:updatepanel id="UPGridview" runat="server" updatemode="Conditional" childrenastriggers="false">
                        <ContentTemplate>
                            <div class="card">
                                <div class="header">
                                    <%--<h2>Programas actuales por sede</h2>--%>
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
                                    <asp:TextBox ID="txt" Text='<%# Eval("txt") %>' hidden="true"  runat="server" />
                                     <asp:TextBox ID="txt2" Text='<%# Eval("txt2") %>' hidden="true" runat="server" />
                                     <asp:TextBox ID="txt3" Text='<%# Eval("txt3") %>' hidden="true" runat="server" />
                                </div>
                                <div class="body table-responsive ">
                                    <asp:GridView ID="gvRutina" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="PK_IR_Cod, DR_FechaRutina"
                                        ShowHeaderWhenEmpty="true" GridLines="None" AllowPaging="true" CssClass="table table-striped table-hover"
                                        OnRowCommand="gvRutina_RowCommand" OnRowEditing="gvRutina_RowEditing" OnRowCancelingEdit="gvRutina_RowCancelingEdit"
                                        OnRowUpdating="gvRutina_RowUpdating" OnRowDeleting="gvRutina_RowDeleting"
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                        <%-- Theme Properties --%>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                        <RowStyle ForeColor="#000066" />
                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                        
                                        
                                               
                                        <Columns>
                                            <asp:TemplateField HeaderText="Fecha Rutina">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("DR_FechaRutina") %>' runat="server" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtfechaRutina" Text='<%# Eval("DR_FechaRutina") %>' runat="server" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtfechaRutinaFooter" runat="server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Fecha Registro">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("DR_FechaRegistro") %>' runat="server" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtfecharegistro" Text='<%# Eval("DR_FechaRegistro") %>' runat="server" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtfecharegistroFooter" runat="server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Descripcion Ejercicio">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("VR_DescripcionE")%>' runat="server" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtdescripcion" Text='<%# Eval("VR_DescripcionE") %>' runat="server" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtdescripcionFooter" runat="server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tipo Rutina">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("FK_ITR_Cod") %>' runat="server" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtFK_ITR_Cod" Text='<%# Eval("FK_ITR_Cod") %>' runat="server" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtFK_ITR_CodFooter" runat="server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Duracion">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("VR_Duracion") %>' runat="server" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtduracion" Text='<%# Eval("VR_Duracion") %>' runat="server" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtduracionFooter" runat="server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Repeticion">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("IR_Repeticion") %>' runat="server" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtrepeticion"  Text='<%# Eval("IR_Repeticion") %>' runat="server" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtrepeticionFooter" runat="server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ImageUrl="~/Images/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" />
                                                    <asp:ImageButton ImageUrl="~/Images/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:ImageButton ImageUrl="~/Images/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                                                    <asp:ImageButton ImageUrl="~/Images/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:ImageButton ImageUrl="~/Images/addnew.png"  id="anadir" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                    <asp:Button Text="Volver" CssClass="btn bg-green waves-effect" Width="90px" Height="30px" runat="server" OnClick="Unnamed_Click"/>
                                    
                                    <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
                                    <br />
                                    <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>

                            <%--<asp:AsyncPostBackTrigger ControlID="btnEliminarSolCita" />
                            <asp:AsyncPostBackTrigger ControlID="btnAprobar" />
                            <asp:AsyncPostBackTrigger ControlID="btnRechazar" />--%>
                        </Triggers>

                    </asp:updatepanel>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            $(function () {
                $("#cph_body_gvRutina_txtfechaRutinaFooter").val($("#cph_body_txt").val());
                   $("#cph_body_gvRutina_txtfechaRutinaFooter").prop("readonly",true);
            });
        </script>
        <script type="text/javascript">
            $(function () {
                $("#cph_body_gvRutina_txtFK_ITR_CodFooter").val($("#cph_body_txt2").val());
                    $("#cph_body_gvRutina_txtFK_ITR_CodFooter").prop("readonly",true);
            });
        </script>
        <script type="text/javascript">
            $(function () {
                $("#cph_body_gvRutina_txtfecharegistroFooter").val($("#cph_body_txt3").val());
                    $("#cph_body_gvRutina_txtfecharegistroFooter").prop("readonly",true);
            });
        </script>

        <script>
                $("#cph_body_gvRutina_anadir").click(function(){
                var campo_des = $("#cph_body_gvRutina_txtdescripcionFooter").val().trim();
                var campo_dur = $("#cph_body_gvRutina_txtduracionFooter").val().trim();
                var campo_rep =$("#cph_body_gvRutina_txtrepeticionFooter").val().trim();
              
                if (campo_des.length == 0 || campo_dur.length == 0|| campo_rep.length == 0) {
                    alert("No puede haber campos vacios");
                    return false;
                }
                else{
                    alert("Todo correcto");
                }

            });
        </script>

        <script>
                $("#cph_body_gvRutina_anadir").click(function () {
                    var campo_rep = $("#cph_body_gvRutina_txtrepeticionFooter").val().trim();

                    if (campo_rep.length > 999) {
                        alert("Ingrese un dato entero permitido.");
                        return false;
                    }
                    else {
                        alert("Todo correcto.");
                    }

                });
        </script>



    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" runat="Server">
</asp:Content>

