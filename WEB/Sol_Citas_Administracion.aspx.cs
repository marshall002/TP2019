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
	string CodigoUsuarioDNI="74931448";
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
			Session["CodigoSolicitudCita"] = id;
			Response.Redirect("Sol_Citas_Registrar.aspx");

		}
		if (e.CommandName == "eliminar")
		{
			try
			{
				int index = Convert.ToInt32(e.CommandArgument);
				var colsNoVisible = gvSolicitudesCita.DataKeys[index].Values;
				string id = colsNoVisible[0].ToString();
				Log.WriteLog(id);
				
				DescModalEliminarCurso.InnerText = "¿Seguro desea eliminar el curso '" + id + "'";
				Log.WriteLog("1");
				string script = @"<script type='text/javascript'>
                                      $('#modalAsignarCurso').modal('show');
                                  </script>";
				Log.WriteLog("2");
				ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", script, false);
			}
			catch
			{
				ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'curso asignado actualmente a un programa', 'bottom', 'center', null, null);", true);
			}
			//int index = Convert.ToInt32(e.CommandArgument);
			//var colsNoVisible = gvSolicitudesCita.DataKeys[index].Values;
			//string id = colsNoVisible[0].ToString();
			//Session["CodigoSolicitudCita"] = id;
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
			int id_sed = int.Parse(Session["id_sede_aux"].ToString());
			//eliminarCurso(id_sed);
			ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', 'Curso eliminado exitosamente', 'bottom', 'center', null, null);", true);
		}
		catch (Exception ex)
		{
			ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'No se puede eliminar el curso', 'bottom', 'center', null, null);", true);
		}
	}
}