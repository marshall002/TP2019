using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CTR;
using DTO;

public partial class Solicitudes_Cita_Registrar_Solicitud_Cita : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			
		}
	}
	protected void btnGuardar_ServerClick(object sender, EventArgs e)
	{
		string Hora = txtHoras.Text.Trim();
		string txtareaconsulta = txtDudaConsulta.Text.Trim();
		string Fecha = txtFecha.Text.Trim();
		string Sesion = "74931448";

		string valorRadiobuttonentxt= txtresultadoChecbox.Value;
		int IECCod = 1;

		DtoCita dto_Cita = new DtoCita();
		dto_Cita.FK_ITC_Cod = Convert.ToInt32(valorRadiobuttonentxt);
		dto_Cita.DC_FechaHoraSolicitada = Convert.ToDateTime(Fecha);
		dto_Cita.DC_FechaHoraCreada = DateTime.Now;
		dto_Cita.VC_Observacion = txtareaconsulta;
		dto_Cita.FK_IEC_Cod = IECCod;
		dto_Cita.FK_CU_DNI = Sesion;

		CtrCita ctr_Cita = new CtrCita();
		ctr_Cita.registrarSolicitudCita(dto_Cita);

	}

	protected void btnCancelar_ServerClick(object sender, EventArgs e)
	{
		Response.Redirect("~/Sol_Citas_Administracion.aspx");
	}
}