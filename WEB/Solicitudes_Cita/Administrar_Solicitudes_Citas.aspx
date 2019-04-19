<%@ Page Title="Adm. Solicitudes" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Administrar_Solicitudes_Citas.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
	<section>
		<div class="container-fluid">
			<div class="block-header">
				<h2>Mis solicitudes de cita</h2>
			</div>
			<div class="row clearfix">
				<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
					<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
					<asp:UpdatePanel ID="upCursos" runat="server">
						<ContentTemplate>
							<div class="card">
								<div class="header">
									<h2>Programas actuales por sede</h2>
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
								</div>


								<div class="body table-responsive ">
									<asp:Button ID="btnRegistrar" runat="server" Text="Registrar"
                                        class="btn btn-block btn-lg btn-primary waves-effect" aria-hidden="true" OnClick="btnRegistrar_Click"  />

									<asp:GridView ID="gvSolicitudesCita" CssClass="table table-bordered table-hover " DataKeyNames="IC_Cod" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay programas en su sede" ShowHeaderWhenEmpty="True" OnRowCommand="gvSolicitudesCita_RowCommand">
										<Columns>
											<asp:BoundField DataField="IC_Cod" HeaderText="Codigo de solicitud" />
											<asp:BoundField DataField="DC_FechaHoraSolicitada" HeaderText="Fecha y Hora solicitada" />
											<asp:BoundField DataField="VC_Observacion" HeaderText="Consulta" Visible="false" />
											<asp:BoundField DataField="DC_FechaHoraCreada" HeaderText="Fecha de creacion" Visible="false" />
											<asp:BoundField DataField="FK_IEC_Cod" HeaderText="FK_ EstadoCitaCod" Visible="false" />
											<asp:BoundField DataField="FK_ITC_Cod" HeaderText="FK_TipoCita" Visible="false" />
											<asp:BoundField DataField="VEC_Nombre" HeaderText="Estado de Solicitud" />
											<asp:BoundField DataField="FK_CU_Dni" HeaderText="FK_UsuarioDNI" Visible="false" />
											<asp:BoundField DataField="VTC_Nombre" HeaderText="Especialidad" />
											<asp:ButtonField HeaderText="Actualiza tu sol." Text="Actualizar" ButtonType="Button" ItemStyle-CssClass="text-sm-center" CommandName="actualizar">
												<ControlStyle CssClass="btn btn-success" />
											</asp:ButtonField>
											<asp:ButtonField HeaderText="Elimina tu sol." Text="Eliminar" ButtonType="Button" ItemStyle-CssClass="text-sm-center" CommandName="eliminar">
												<ControlStyle CssClass="btn btn-danger" />
											</asp:ButtonField>
										</Columns>
									</asp:GridView>
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

