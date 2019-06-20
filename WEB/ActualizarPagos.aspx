<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ActualizarPagos.aspx.cs" Inherits="ActualizarPagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <section>
        <div class="container-fluid">
            <div class="block-header">
                <h1>Actualizar Pago</h1>
            </div>
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="col-md-4 col-md-offset-4"></div>
                        Imagen agregada:
                    <br />
                        <br />
                        <br />
                        <asp:Image ID="imagen_previa" Width="200" ImageUrl="images/boucher.jpg" runat="server" />
                        <br />
                        <br />
                        <asp:Button ID="btnsubir" runat="server" Text="Subir" />
                        <br />
                        <br />
                        Archivo:
                    <br />
                        <br />
                        <asp:FileUpload ID="fu_load_imagen" accept=".jpg" runat="server" CssClass="form-control" />
                        <br />
                        <br />
                        Numero de Operaciones:
                    <br />
                        <br />
                        <asp:TextBox ID="txt_operaciones" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        Monto:
                    <br />
                        <br />
                        <asp:TextBox ID="txt_monto" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        Numero de citas fisio:
                    <br />
                        <br />
                        <asp:TextBox ID="txt_n_cita_fisio" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        Numero de citas nutri:
                    <br />
                        <br />
                        <asp:TextBox ID="txt_n_cita_nutri" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="btn_actualizar" runat="server" Text="Actualizar" OnClick="btn_actualizar_Click" />
                        <br />
                        <br />

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

