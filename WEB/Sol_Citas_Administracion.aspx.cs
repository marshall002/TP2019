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
	CtrCita objcita = new CtrCita();
	int TipoCitaSol = 1;
	string CodigoUsuarioDNI = "74931448";
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			ListarSolicitudesCita(TipoCitaSol, CodigoUsuarioDNI);
		}
	}
	public void ListarSolicitudesCita(int tiposolicitud, string CodigoUsuario)
	{
		gvSolicitudesCita.DataSource = objcita.VerSolicitudesCita(tiposolicitud, CodigoUsuario);
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

			Response.Redirect("Sol_Citas_Detalles.aspx");
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
				
				string script = @"<script type='text/javascript'>
                                      $('#modalconfirmacioneliminarsol').modal('show');
                                  </script>";
				ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", script, false);
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

	protected void btnEliminarCurso_ServerClick(object sender, EventArgs e)
	{
		try
		{
			int idSolicitud = int.Parse(Session["CodigoSolicitudCita"].ToString());
			int estadosol = int.Parse(Session["estadosol"].ToString());
			objcita.EliminarrSolicitudCita(idSolicitud, estadosol);
			ListarSolicitudesCita(TipoCitaSol, CodigoUsuarioDNI);
			upCursos.Update();
			ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', 'Solicitud eliminada con exito	', 'bottom', 'center', null, null);", true);
		}
		catch (Exception ex)
		{
			ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + ex.Message + "', 'bottom', 'center', null, null);", true);
		}
	}
}