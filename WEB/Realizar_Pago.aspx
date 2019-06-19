<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Realizar_Pago.aspx.cs" Inherits="Realizar_Pago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <section>
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
                        <div class="body table-responsive ">
                            <asp:GridView ID="gvRegistrarPago" class="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" EmptyDataText="No tiene pagos registradas" ShowHeaderWhenEmpty="True" OnRowCommand="gvRegistrarPago_RowCommand" OnSelectedIndexChanged="gvRegistrarPago_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="PK_ICP_Cod" HeaderText="Codigo" />
                                    <asp:BoundField DataField="DCP_FechaHoraRealizada" HeaderText="Fecha de Pago" />
                                    <asp:BoundField DataField="ICP_NFisio" HeaderText="N° de Citas Fisioterapeuta." />
                                    <asp:BoundField DataField="ICP_NNutri" HeaderText="N° de Citas Nutricionista" />
                                    <asp:BoundField DataField="VCP_Estado_Pago" HeaderText="Estado" />
                                    <asp:ButtonField HeaderText="Ver" Text="Ver" ButtonType="Button" ItemStyle-CssClass="text-sm-center" CommandName="Ver">
                                        <ControlStyle CssClass="btn btn-info" />
                                    </asp:ButtonField>
                                    <%-- <asp:ButtonField HeaderText="Actualizar" Text="Actualizar" ButtonType="Button" ItemStyle-CssClass="text-sm-center" Visible="<%# ValidacionEstadoCita((int)Eval("FK_IEC_Cod")) %>" CommandName="Actualizar">
                                                <ControlStyle CssClass="btn btn-warning" />
                                            </asp:ButtonField>--%>
                                    <asp:TemplateField HeaderText="Actualizar">
                                        <ItemTemplate>
                                            <asp:Button runat="server" Text="Actualizar"
                                                Visible='<%# ValidacionEstadoPago((string)Eval("VCP_Estado_Pago")) %>' ButtonType="Button" ItemStyle-CssClass="text-sm-center"
                                                CommandName="Actualizar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" runat="Server">
</asp:Content>

