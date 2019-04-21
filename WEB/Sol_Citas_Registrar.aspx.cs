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
		try
		{
			TimeSpan Hora = TimeSpan.Parse(txtHoras.Text);
			string txtareaconsulta = txtDudaConsulta.Text.Trim();
			DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
			DateTime fechasolitada = Fecha + Hora;
			string Sesion = "74931448";

			string valorRadiobuttonentxt = txtresultadoChecbox.Value;
			int IECCod = 1;

			DtoCita dto_Cita = new DtoCita();
			dto_Cita.FK_ITC_Cod = Convert.ToInt32(valorRadiobuttonentxt);
			dto_Cita.DC_FechaHoraSolicitada = fechasolitada;
			dto_Cita.DC_FechaHoraCreada = DateTime.Now;
			dto_Cita.VC_Observacion = txtareaconsulta;
			dto_Cita.FK_IEC_Cod = IECCod;
			dto_Cita.FK_CU_DNI = Sesion;

			CtrCita ctr_Cita = new CtrCita();
			ctr_Cita.registrarSolicitudCita(dto_Cita);

			ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', 'Registrado con exito', 'bottom', 'center', null, null);", true);

		}
		catch (Exception ex)
		{
			ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + ex.Message + "', 'bottom', 'center', null, null);", true);

		}

	}

	protected void btnCancelar_ServerClick(object sender, EventArgs e)
	{
		Response.Redirect("~/Sol_Citas_Administracion.aspx");
	}
}