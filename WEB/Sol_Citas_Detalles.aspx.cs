using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using DAO;
using CTR;
using DTO;

public partial class Sol_Citas_Detalles : System.Web.UI.Page
{
	CtrCita objctrcita = new CtrCita();
	DtoCita objdtocita = new DtoCita();
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{

			cargardatosCitas();

		}
	}

	protected void btnGuardar_ServerClick(object sender, EventArgs e)
	{
		try
		{
			string txtareaconsulta = txtDudaConsulta.Text.Trim();
			TimeSpan Hora = TimeSpan.Parse(txtHoras.Text);
			DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
			DateTime fechasolitada = Fecha + Hora;
			int codigosol = int.Parse(Session["CodigoSolicitudCita"].ToString());
			Log.WriteLog(txtresultadoChecbox.Value);

			string valorRadiobuttonentxt = txtresultadoChecbox.Value;
			string mensaje = "Datos actualizados";

			objctrcita.actualizarSolicitudCita(codigosol, fechasolitada, txtareaconsulta, int.Parse(valorRadiobuttonentxt));
			ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + mensaje + "', 'bottom', 'center', null, null);", true);

		}
		catch (Exception ex)
		{
			ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + ex.Message + "', 'bottom', 'center', null, null);", true);

		}

	}
	public void cargardatosCitas()
	{
		objdtocita.IC_Cod = int.Parse(Session["CodigoSolicitudCita"].ToString());

		objctrcita.ObtenerInformacionSolicitudCita(objdtocita);

		DateTime dtValue= objdtocita.DC_FechaHoraSolicitada;
		txtFecha.Text = dtValue.ToString("yyyy-MM-dd");
		txtHoras.Text = dtValue.ToString("HH:mm");
		string TipoCitaSol = Session["tipocitasol"].ToString();
		Log.WriteLog(TipoCitaSol);




		System.Text.StringBuilder sb = new System.Text.StringBuilder();
		sb.Append(@"<script language='javascript'>");
		sb.Append(@"SeleccionarRadioButton("+ TipoCitaSol + ");");
		sb.Append(@"</script>");
		System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "JCall1", sb.ToString(), false);

		
		txtDudaConsulta.Text = objdtocita.VC_Observacion;
		txtFecha.Text = Convert.ToString(objdtocita.DC_FechaHoraSolicitada.ToString("yyyy-MM-dd"));
	}

	protected void btnCancelar_ServerClick(object sender, EventArgs e)
	{

		Response.Redirect("~/Sol_Citas_Administracion.aspx");
	}
}