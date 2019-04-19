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

	int TipoCitaSol = 1;
	string CodigoUsuarioDNI="74931448";
	protected void Page_Load(object sender, EventArgs e)
	{

		if (!IsPostBack)
		{
			//int perfil = int.Parse(Session["id_perfil"].ToString());
			//if (perfil != Constante.ROL_SECRETARIA)
			//{
			//	Session.Clear();
			//	Session.Abandon();
			//	Response.Redirect("inicio.aspx");
			//}
		
			ListarSolicitudesCita(TipoCitaSol, CodigoUsuarioDNI);
		}
	}
	public void ListarSolicitudesCita(int tiposolicitud, string CodigoUsuario)
	{
		CtrCita objcita = new CtrCita();
		gvSolicitudesCita.DataSource = objcita.VerSolicitudesCita(tiposolicitud, CodigoUsuario);
		gvSolicitudesCita.DataBind();
	}
	protected void gvSolicitudesCita_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "confirmarPago")
		{
			//	int index = Convert.ToInt32(e.CommandArgument);
			//	var colsNoVisible = 1;
			//	int idPersona = int.Parse(colsNoVisible[0].ToString());
			//	int correlativo = int.Parse(colsNoVisible[1].ToString());
			//	actualizarEstadoCompromiso(int.Parse(Session["programaGlobal"].ToString()), idPersona, correlativo, "PAGADO");
			//	ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', 'Confirmación de pago realizado', 'bottom', 'center', null, null);", true);
			//	listarMatriculasPendientesAlumno(idProgramaGlobal, "PENDIENTE", 1);
		}
	}

	protected void btnRegistrar_Click(object sender, EventArgs e)
	{

	}
}