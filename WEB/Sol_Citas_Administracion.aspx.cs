using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using CTR;
using DTO;

public partial class _Default : System.Web.UI.Page
{
	CtrCita objctrcita = new CtrCita();
	CtrUsuario objctrusuario = new CtrUsuario();
	DtoUsuario objdtousuario = new DtoUsuario();

	int TipoCitaSol = 1;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			ListarSolicitudesCita(TipoCitaSol, Session["SessionUsuario"].ToString());
			//contarCitasxServicio();
			ValidarfechaFinPlan();
		}
	}
	public void ListarSolicitudesCita(int tiposolicitud, string CodigoUsuario)
	{
		gvSolicitudesCita.DataSource = objctrcita.VerSolicitudesCita(CodigoUsuario);
		gvSolicitudesCita.DataBind();
	}
	protected void gvSolicitudesCita_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "actualizar")
		{
			int index = Convert.ToInt32(e.CommandArgument);
			var colsNoVisible = gvSolicitudesCita.DataKeys[index].Values;
			string id = colsNoVisible[0].ToString();
			string estadosol = colsNoVisible[1].ToString();
			string tipocitasol = colsNoVisible[2].ToString();

			Session["CodigoSolicitudCita"] = id;
			Session["estadosol"] = estadosol;
			Session["TipoCitaSol"] = tipocitasol;
			if (estadosol != "2")
			{
				Response.Redirect("Sol_Citas_Detalles.aspx");

			}
			else
			{
				ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Usted no puede actualizar la cita', 'bottom', 'center', null, null);", true);

			}

		}
		if (e.CommandName == "eliminar")
		{
			try
			{
				int index = Convert.ToInt32(e.CommandArgument);
				var colsNoVisible = gvSolicitudesCita.DataKeys[index].Values;
				string idSol = colsNoVisible[0].ToString();
				string estadosol = colsNoVisible[1].ToString();
				Session["CodigoSolicitudCita"] = idSol;
				Session["estadosol"] = estadosol;
				if (estadosol != "2")
				{
					string script = @"<script type='text/javascript'>
                                      $('#modalconfirmacioneliminarsol').modal('show');
                                  </script>";
					ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", script, false);
				}
				else
				{
					ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Usted no puede eliminar la cita', 'bottom', 'center', null, null);", true);
				}


			}
			catch (Exception ex)
			{
				ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + ex.Message + "', 'bottom', 'center', null, null);", true);

			}
		}
	}

	protected void btnRegistrar_Click(object sender, EventArgs e)
	{
			Response.Redirect("~/Sol_Citas_Registrar.aspx");
	}

	protected void btnEliminarSolCita_ServerClick(object sender, EventArgs e)
	{
		try
		{
			int idSolicitud = int.Parse(Session["CodigoSolicitudCita"].ToString());
			int estadosol = int.Parse(Session["estadosol"].ToString());
			objctrcita.EliminarrSolicitudCita(idSolicitud, estadosol);
			ListarSolicitudesCita(TipoCitaSol, Session["SessionUsuario"].ToString());
			upCursos.Update();
			contarCitasxServicio();
			ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', 'Solicitud eliminada con exito	', 'bottom', 'center', null, null);", true);
		}
		catch (Exception ex)
		{
			ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + ex.Message + "', 'bottom', 'center', null, null);", true);
		}
	}
	public void contarCitasxServicio()
	{
		objdtousuario.PK_CU_Dni = Session["SessionUsuario"].ToString();
		//Log.WriteLog("El codigo de sesion es:" + objdtousuario.PK_CU_Dni);
		objctrusuario.ObtenerNumCitasRealizadas(objdtousuario);

		//Log.WriteLog("Citas registradas de fisioterapeuta son: " + objdtousuario.IC_Citas_Fisio_Usadas.ToString());
		//Log.WriteLog("Citas registradas de nutricionista  son: " + objdtousuario.IC_Citas_Nutri_Usadas.ToString());
	}

	public void ValidarfechaFinPlan()
	{
		DateTime Fechafinpla= DateTime.Parse(Session["DP_Fecha_Fin_Plan"].ToString());
		DateTime fechaahora = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
		Log.WriteLog("fecha fin de plan por usuario " + Session["NombreUsuario"].ToString() + ":" +Fechafinpla);
		Log.WriteLog("Funcion Now" + fechaahora);

		if(fechaahora> Fechafinpla)
		{
			Log.WriteLog("1");
			ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Es mayor la fecha de hoy a la fecha de fin de plan', 'bottom', 'center', null, null);", true);
			Log.WriteLog("2");

		}
		else if(fechaahora <= Fechafinpla)
		{
			Log.WriteLog("3");
			ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', 'Es menor la fecha de hoy a la fecha de fin de plan', 'bottom', 'center', null, null);", true);
			Log.WriteLog("4");

		}

	}
}