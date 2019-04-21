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
		string Hora = txtHoras.Text;
		string txtareaconsulta = txtDudaConsulta.Text.Trim();
		DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
		string Sesion = "74931448";
		int codigosol = int.Parse(Session["CodigoSolicitudCita"].ToString());
		Log.WriteLog(txtresultadoChecbox.Value);





		string valorRadiobuttonentxt = txtresultadoChecbox.Value;
		

		objctrcita.actualizarSolicitudCita(codigosol, Fecha, txtareaconsulta, int.Parse(valorRadiobuttonentxt));
	}
	public void cargardatosCitas()
	{
		objdtocita.IC_Cod = int.Parse(Session["CodigoSolicitudCita"].ToString());

		objctrcita.ObtenerInformacionSolicitudCita(objdtocita);

		DateTime dtValue= objdtocita.DC_FechaHoraSolicitada;  // load your date & time into this variable
		txtFecha.Text = dtValue.ToString("yyyy-MM-dd");
		txtHoras.Text = dtValue.ToString("HH:mm");


		txtDudaConsulta.Text = objdtocita.VC_Observacion;
		Log.WriteLog(objdtocita.DC_FechaHoraSolicitada.ToString("yyyy-MM-dd"));
		txtFecha.Text = Convert.ToString(objdtocita.DC_FechaHoraSolicitada.ToString("yyyy-MM-dd"));


	}

	protected void btnCancelar_ServerClick(object sender, EventArgs e)
	{

		Response.Redirect("~/Sol_Citas_Administracion.aspx");
	}
}