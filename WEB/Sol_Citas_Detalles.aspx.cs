﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CTR;
using DTO;

public partial class Sol_Citas_Detalles : System.Web.UI.Page
{
	CtrCita objctrcita = new CtrCita();
	CtrUsuario objctrusuario = new CtrUsuario();
	DtoCita objdtocita = new DtoCita();
	DtoUsuario objdtousuario = new DtoUsuario();
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			cargardatosCitas();
			contarCitasxServicio();
		}

	}

	protected void btnGuardar_ServerClick(object sender, EventArgs e)
	{
		try
		{
			string valorRadiobuttonentxt = txtresultadoChecbox.Value;
			contarCitasxServicio();
			Log.WriteLog("Cantidad de sesiones x plan de fisioterapeuta detalles.aspx: " + Session["ISF_Cantidad"].ToString());
			Log.WriteLog("Contador de sesiones registradas detalles.aspx: " + objdtousuario.IC_Citas_Fisio_Usadas.ToString());
			if (valorRadiobuttonentxt == "1")//fisioterapeuta
			{
				if (Session["ISF_Cantidad"].ToString() == objdtousuario.IC_Citas_Fisio_Usadas.ToString())
				{
					ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Debe adjuntar el derecho de pago para registrar una cita', 'bottom', 'center', null, null);", true);

				}
				else
				{
					actualizardatos(valorRadiobuttonentxt);
				}
			}
			else if (valorRadiobuttonentxt == "1")//Nutricionista
			{
				if (Session["ISN_Cantidad"].ToString() == objdtousuario.IC_Citas_Nutri_Usadas.ToString())
				{
					ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Debe adjuntar el derecho de pago para registrar una cita', 'bottom', 'center', null, null);", true);

				}
				else
				{
					actualizardatos(valorRadiobuttonentxt);
				}
			}
			//if (Session["ISF_Cantidad"].ToString() == objdtousuario.IC_Citas_Fisio_Usadas.ToString())
			//{
			//	ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Debe adjuntar el derecho de pago para registrar una cita', 'bottom', 'center', null, null);", true);

			//}
			//else
			//{
			//	if (Session["ISN_Cantidad"].ToString() == objdtousuario.IC_Citas_Nutri_Usadas.ToString())
			//	{
			//		ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Debe adjuntar el derecho de pago para registrar una cita', 'bottom', 'center', null, null);", true);

			//	}
			//	else
			//	{

			//	}
			//}
		}
		catch (Exception ex)
		{
			ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + ex.Message + "', 'bottom', 'center', null, null);", true);

		}

	}
	public void actualizardatos(string valorRadiobuttonentxt)
	{
		string txtareaconsulta = txtDudaConsulta.Text.Trim();
		TimeSpan Hora = TimeSpan.Parse(txtHoras.Text);
		DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
		DateTime fechasolitada = Fecha + Hora;
		int codigosol = int.Parse(Session["CodigoSolicitudCita"].ToString());
		Log.WriteLog(txtresultadoChecbox.Value);

		string mensaje = "Datos actualizados";

		objctrcita.actualizarSolicitudCita(codigosol, fechasolitada, txtareaconsulta, int.Parse(valorRadiobuttonentxt));
		ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + mensaje + "', 'bottom', 'center', null, null);", true);

	}
	public void cargardatosCitas()
	{
		try
		{
			objdtocita.IC_Cod = int.Parse(Session["CodigoSolicitudCita"].ToString());

			objctrcita.ObtenerInformacionSolicitudCita(objdtocita);

			DateTime dtValue = objdtocita.DC_FechaHoraSolicitada;
			txtFecha.Text = dtValue.ToString("yyyy-MM-dd");
			txtHoras.Text = dtValue.ToString("HH:mm");
			string TipoCitaSol = Session["tipocitasol"].ToString();
			Log.WriteLog(TipoCitaSol);




			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append(@"<script language='javascript'>");
			sb.Append(@"SeleccionarRadioButton(" + TipoCitaSol + ");");
			sb.Append(@"</script>");
			System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "JCall1", sb.ToString(), false);


			txtDudaConsulta.Text = objdtocita.VC_Observacion;
			txtFecha.Text = Convert.ToString(objdtocita.DC_FechaHoraSolicitada.ToString("yyyy-MM-dd"));

			if (int.Parse(Session["estadosol"].ToString()) == 2)
			{
				Log.WriteLog("entro a page load");

				System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
				sb1.Append(@"<script language='javascript'>");
				sb1.Append(@"DeshabilitarCampos();");
				sb1.Append(@"</script>");
				System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "JCall1", sb1.ToString(), false);
			}

		}
		catch (Exception)
		{
			ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'No tiene los permisos para actualizar', 'bottom', 'center', null, null);", true);

		}

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

		Log.WriteLog("Citas registradas de fisioterapeuta son en aspx de detalles: " + objdtousuario.IC_Citas_Fisio_Usadas.ToString());
		Log.WriteLog("Citas registradas de nutricionista  son en aspx de detalles: " + objdtousuario.IC_Citas_Nutri_Usadas.ToString());
	}
}