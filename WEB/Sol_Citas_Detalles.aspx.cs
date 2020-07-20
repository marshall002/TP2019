using System;
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
    Log Log = new Log();
	DtoUsuario objdtousuario = new DtoUsuario();
    protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{

            if (Session["id_perfil"] != null)
            {
                if (int.Parse(Session["id_perfil"].ToString()) == Constante.ROL_SOCIO)
                {
                    cargardatosCitas();
                }
                else
                {
                    Log.WriteOnLog(" Sol Citas Detalles - Error en id Perfil");
                    Response.Redirect("Inicio.aspx");
                }
            }
            else
            {

                Log.WriteOnLog(" Sol Citas Detalles - Error en id Perfil");
                Response.Redirect("Inicio.aspx");

            }
           
			//contarCitasxServicio();
		}

	}

	protected void btnGuardar_ServerClick(object sender, EventArgs e)
	{
		try
		{
			string valorRadiobuttonentxt = txtresultadoChecbox.Value;
			contarCitasxServicio();
			Log.WriteOnLog("---------------------------------------------------------------------------------------------");

			Log.WriteOnLog("Cantidad de sesiones x plan de fisioterapeuta actuales: " + Session["ISF_Cantidad"].ToString());
			Log.WriteOnLog("Contador de sesiones registradas actuales: " + objdtousuario.IC_Citas_Fisio_Usadas.ToString());
			Log.WriteOnLog("Contador de sesiones x plan de nutricionista actuales: " + Session["ISN_Cantidad"].ToString());
			Log.WriteOnLog("Contador de sesiones registradas actuales: " + objdtousuario.IC_Citas_Nutri_Usadas.ToString());

			Log.WriteOnLog("---------------------------------------------------------------------------------------------");
			if (valorRadiobuttonentxt == "1")//Nutricionista
			{
				if ( int.Parse(objdtousuario.IC_Citas_Nutri_Usadas.ToString()) >= int.Parse(Session["ISN_Cantidad"].ToString()))
				{
					ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Debe adjuntar el derecho de pago para registrar una cita', 'bottom', 'center', null, null);", true);

				}
				else
				{
					if (int.Parse(objdtousuario.IC_Citas_Nutri_Usadas.ToString()) > int.Parse(Session["ISN_Cantidad"].ToString()))
					{
						actualizardatos(valorRadiobuttonentxt);
					}
					else
					{
						actualizardatos(valorRadiobuttonentxt);
					}
				}
			}
			else if (valorRadiobuttonentxt == "2")//Fisioterapeuta
			{
				if (int.Parse(objdtousuario.IC_Citas_Fisio_Usadas.ToString()) > int.Parse(Session["ISF_Cantidad"].ToString()))
				{
					ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Debe adjuntar el derecho de pago para registrar una cita', 'bottom', 'center', null, null);", true);

				}
				else
				{
					if (int.Parse(objdtousuario.IC_Citas_Fisio_Usadas.ToString()) == int.Parse(Session["ISF_Cantidad"].ToString()))
					{
						
						actualizardatos(valorRadiobuttonentxt);
					}
					else
						actualizardatos(valorRadiobuttonentxt);
					{
					}
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
		TimeSpan Hora = TimeSpan.Parse(ddlHoras.Text);
		DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
		DateTime fechasolitada = Fecha + Hora;
		int codigosol = int.Parse(Session["CodigoSolicitudCita"].ToString());
		Log.WriteOnLog(txtresultadoChecbox.Value);

		string mensaje = "Datos actualizados";

		objctrcita.actualizarSolicitudCita(codigosol, fechasolitada, txtareaconsulta, int.Parse(valorRadiobuttonentxt));
		ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + mensaje + "', 'bottom', 'center', null, null);", true);

	}
	public void cargardatosCitas()
	{
		try
		{
            Log.WriteOnLog("Entro a cargar datos citas");
			objdtocita.IC_Cod = int.Parse(Session["CodigoSolicitudCita"].ToString());
            Log.WriteOnLog("1");

            objctrcita.ObtenerInformacionSolicitudCita(objdtocita);
            Log.WriteOnLog("2");
            DateTime dtValue = objdtocita.DC_FechaHoraSolicitada;
			txtFecha.Text = dtValue.ToString("yyyy-MM-dd");
			ddlHoras.Text = dtValue.ToString("HH:mm");
			string TipoCitaSol = Session["tipocitasol"].ToString();
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append(@"<script language='javascript'>");
			sb.Append(@"SeleccionarRadioButton(" + TipoCitaSol + ");");
			sb.Append(@"</script>");
			System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "JCall1", sb.ToString(), false);


			txtDudaConsulta.Text = objdtocita.VC_Observacion;
			txtFecha.Text = Convert.ToString(objdtocita.DC_FechaHoraSolicitada.ToString("yyyy-MM-dd"));
            Log.WriteOnLog("objdtocita.IC_Cod"+ objdtocita.IC_Cod);
            Log.WriteOnLog("dtValue" + dtValue);
            Log.WriteOnLog("TipoCitaSol" + TipoCitaSol);
            Log.WriteOnLog("objdtocita.VC_Observacion" + objdtocita.VC_Observacion);
            Log.WriteOnLog("objdtocita.FechaHoraSolicitada" + Convert.ToString(objdtocita.DC_FechaHoraSolicitada.ToString("yyyy-MM-dd")));


            if (int.Parse(Session["estadosol"].ToString()) == 2)
			{
				Log.WriteOnLog("entro a page load");

				System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
				sb1.Append(@"<script language='javascript'>");
				sb1.Append(@"DeshabilitarCampos();");
				sb1.Append(@"</script>");
				System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "JCall1", sb1.ToString(), false);
			}

		}
		catch (Exception ex)
		{
            Log.WriteOnLog("Error en EX"+ex.Message);
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
		Log.WriteOnLog("El codigo de sesion es:" + objdtousuario.PK_CU_Dni);
		objctrusuario.ObtenerNumCitasRealizadas(objdtousuario);
		Log.WriteOnLog("-----------------------------------SOL_CITAS_DETALLES.ASPX----------------------------------------------------");

		Log.WriteOnLog("Citas registradas de fisioterapeuta son en aspx de detalles: " + objdtousuario.IC_Citas_Fisio_Usadas.ToString());
		Log.WriteOnLog("Citas registradas de nutricionista  son en aspx de detalles: " + objdtousuario.IC_Citas_Nutri_Usadas.ToString());
	}

	protected void ddlHoras_SelectedIndexChanged(object sender, EventArgs e)
	{
		Log.WriteOnLog("Valor de dropdownList seleccionado al actualizar : " + ddlHoras.SelectedValue);

	}
}