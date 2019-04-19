using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Solicitudes_Cita_Registrar_Solicitud_Cita : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}
	protected void btnGuardar_ServerClick(object sender, EventArgs e)
	{
		ClientScript.RegisterStartupScript(typeof(Page), "showNotification", "showNotification('bg-red', 'No se ha subido Imagen', 'bottom', 'center', null, null);", true);
	}
}