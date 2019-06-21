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
                                                <asp:Button ID="btnsubir" runat="server" Text="Subir"  CssClass="btn btn-success" OnClick="btnsubir_Click" />
                                            </div>

                                        </div>

                                        <div class="col-sm-5">
                                            <div class="col-sm-10">
                                                <label class="form-label">Archivo:</label>
                                            </div>
                                            <div class="col-sm-10">
                                                <asp:Image ID="imagen_previa" Width="200" ImageUrl="images/boucher.jpg" runat="server" />
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
                                                    <asp:TextBox ID="txt_operaciones" runat="server" CssClass="form-control"></asp:TextBox>
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
                                                    <asp:TextBox ID="txt_n_cita_fisio" CssClass="form-control" runat="server"></asp:TextBox>

                                                </div>
                                                <div class="col-sm-2">
                                                    <div class="form-group form-float">
                                                        <label class="form-label">Numero de citas Nutri:</label>
                                                    </div>
                                                </div>
                                                <div class="col-sm-4"> 
                                                    <asp:TextBox ID="txt_n_cita_nutri" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>


                                            </div>
                                        </div>

                                        <div class="col-lg-3 right">
                                            <asp:Button ID="btn_actualizar" runat="server" Text="Actualizar" CssClass="btn btn-success right" OnClick="btn_actualizar_Click" />

                                        </div>



                                        <br />
                                        <br />

                                    </div>
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

