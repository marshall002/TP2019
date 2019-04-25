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
	DtoUsuario objdtousuario = new DtoUsuario();
	CtrUsuario objctrusuario = new CtrUsuario();
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			contarCitasxServicio();
		}
	}
	protected void btnGuardar_ServerClick(object sender, EventArgs e)
	{
		try
		{
			string valorRadiobuttonentxt = txtresultadoChecbox.Value;
			contarCitasxServicio();
			Log.WriteLog("---------------------------------------------------------------------------------------------");

			Log.WriteLog("Cantidad de sesiones x plan de fisioterapeuta actuales: " + Session["ISF_Cantidad"].ToString());
			Log.WriteLog("Contador de sesiones registradas actuales: " + objdtousuario.IC_Citas_Fisio_Usadas.ToString());
			Log.WriteLog("Contador de sesiones x plan de nutricionista actuales: " + Session["ISN_Cantidad"].ToString());
			Log.WriteLog("Contador de sesiones registradas actuales: " + objdtousuario.IC_Citas_Nutri_Usadas.ToString());
			Log.WriteLog("---------------------------------------------------------------------------------------------");


			if (valorRadiobuttonentxt == "1")//Nutri
			{
				if (int.Parse(objdtousuario.IC_Citas_Nutri_Usadas.ToString()) >= int.Parse(Session["ISN_Cantidad"].ToString()))
				{
					ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Debe adjuntar el derecho de pago para Nutri', 'bottom', 'center', null, null);", true);
				}
				else
				{
					RegistrarCodigo(valorRadiobuttonentxt);
				}
			}
			else if (valorRadiobuttonentxt == "2")//Fisio
			{
				if (int.Parse(objdtousuario.IC_Citas_Fisio_Usadas.ToString()) >= int.Parse(Session["ISF_Cantidad"].ToString()))
				{
					ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Debe adjuntar el derecho de pago para Fisio', 'bottom', 'center', null, null);", true);
				}
				else
				{
					RegistrarCodigo(valorRadiobuttonentxt);
				}
			}
		}
		catch (Exception ex)
		{
			ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + ex.Message + "', 'bottom', 'center', null, null);", true);

		}

	}
	public void RegistrarCodigo(string valorRadiobuttonentxt)
	{
		TimeSpan Hora = TimeSpan.Parse(txtHoras.Text);
		string txtareaconsulta = txtDudaConsulta.Text.Trim();
		DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
		DateTime fechasolitada = Fecha + Hora;
		string Sesion = "74931448";

		int IECCod = 1;

		DtoCita dto_Cita = new DtoCita();
		CtrCita ctr_Cita = new CtrCita();

		//dto_Cita.FK_ITC_Cod = int.Parse(valorRadiobuttonentxt);
		//dto_Cita.DC_FechaHoraSolicitada = fechasolitada;
		//dto_Cita.DC_FechaHoraCreada = DateTime.Now;
		//dto_Cita.VC_Observacion = txtareaconsulta;
		//dto_Cita.FK_IEC_Cod = IECCod;
		//dto_Cita.FK_CU_DNI = Sesion;

		string mensaje = "Registrado con exito";
		ctr_Cita.registrarSolicitudCita(fechasolitada, txtareaconsulta, DateTime.Now, IECCod, int.Parse(valorRadiobuttonentxt), Sesion);

		ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + mensaje + "', 'bottom', 'center', null, null);", true);
	}
	protected void btnCancelar_ServerClick(object sender, EventArgs e)
	{
		Response.Redirect("~/Sol_Citas_Administracion.aspx");
	}
	public void contarCitasxServicio()
	{
		objdtousuario.PK_CU_Dni = Session["SessionUsuario"].ToString();
		Log.WriteLog("El codigo de sesion es:" + objdtousuario.PK_CU_Dni);
		objctrusuario.ObtenerNumCitasRealizadas(objdtousuario);

		Log.WriteLog("Citas registradas de fisioterapeuta : " + objdtousuario.IC_Citas_Fisio_Usadas.ToString());
		Log.WriteLog("Citas registradas de nutricionista : " + objdtousuario.IC_Citas_Nutri_Usadas.ToString());
	}
}