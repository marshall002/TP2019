<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RegistrarPagos.aspx.cs" Inherits="RegistrarPagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <section>
        <div class="container-fluid">
            <div class="block-header">
                <h1>Realizar Pago</h1>
            </div>
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Imagen agregada:</label>

                                            </div>
                                        </div>
                                        <div class="col-sm-7  ">
                                            <div class="col-sm-10">
                                                <asp:FileUpload ID="fu_load_imagen" accept=".jpg" runat="server" CssClass="form-control" />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:Button ID="btnSubir" runat="server" Text="Subir" CssClass="btn btn-success" OnClick="btnSubir_Click1" />
                                            </div>

                                        </div>
                                        <div class="col-sm-5">
                                            <div class="col-sm-10">
                                                <label class="form-label">Archivo:</label>
                                            </div>
                                            <div class="col-sm-10">
                                                <asp:Image ID="imagen_previa" Width="200" ImageUrl="data:image/png;base64,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" runat="server" />
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="row clearfix">
                                        <div class="col-sm-2">
                                            <div class="form-group form-float">
                                                <label class="form-label">Numero de Operación:</label>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txt_operacion" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-2">
                                            <div class="form-group form-float">
                                                <label class="form-label">Monto:</label>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">

                                            <asp:TextBox ID="txt_monto" runat="server" CssClass="form-control"></asp:TextBox>

                                        </div>


                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="row clearfix">
                                        <div class="col-sm-2">
                                            <div class="form-group form-float">
                                                <label class="form-label">Numero de citas Fisio:</label>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txt_fisio" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-2">
                                            <div class="form-group form-float">
                                                <label class="form-label">Numero de citas Nutri:</label>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">

                                            <asp:TextBox ID="txt_nutri" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>


                                    </div>
                                </div>
                                <div class="col-lg-3 right">
                                    <asp:Button ID="btn_resgitrar"  runat="server" Text="Registrar" CssClass="btn btn-success right" OnClick="btn_resgitrar_Click" />

                                </div>
                            </div>
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

