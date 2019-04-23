using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using CTR;
using DTO;

public partial class Inicio : System.Web.UI.Page
{
	CtrUsuario objctrUsuario = new CtrUsuario();
	DtoUsuario objdtousuario = new DtoUsuario();
	DtoPlan objdtoplan = new DtoPlan();
	DtoSesionFisio objdtosesionFisio = new DtoSesionFisio();
	DtoSesionNutri objdtosesionNutri = new DtoSesionNutri();
	
	protected void Page_Load(object sender, EventArgs e)
    {
		if(!IsPostBack){
			Session["SessionUsuario"] = "74931448";
			obtenerdatosUsuario();
		}
    }
	public void obtenerdatosUsuario()
	{
		try
		{
			objdtousuario.PK_CU_Dni = Session["SessionUsuario"].ToString();
			objctrUsuario.ObtenerInformacionUsuario(objdtousuario,objdtoplan, objdtosesionFisio, objdtosesionNutri);

			Log.WriteLog(""+ objdtousuario.PK_CU_Dni);
			Log.WriteLog("" + objdtousuario.VU_Nombre);
			Session["NombreUsuario"] = objdtousuario.VU_Nombre;
			Log.WriteLog("" + objdtousuario.VU_APaterno);
			Session["APaternoUsuario"] = objdtousuario.VU_APaterno;
			Log.WriteLog(""+ objdtousuario.VU_AMaterno);
			Session["AMaternoUsuario"] = objdtousuario.VU_AMaterno;

			Log.WriteLog("" + objdtousuario.CU_Celular);
			Session["CU_Celular"] = objdtousuario.CU_Celular;
			Log.WriteLog("" + objdtousuario.DU_FechaNacimiento);
			Session["DU_FechaNacimiento"] = objdtousuario.DU_FechaNacimiento;
			Log.WriteLog("" + objdtousuario.FK_ITU_Cod);
			Session["FK_ITU_Cod"] = objdtousuario.FK_ITU_Cod;
			Log.WriteLog("" + objdtoplan.DP_Fecha_Fin);
			Session["DP_Fecha_Fin_Plan"] = objdtoplan.DP_Fecha_Fin;
			Log.WriteLog("Sesiones de fisioterapeuta por derecho: " + objdtosesionFisio.ISF_Cantidad);
			Session["ISF_Cantidad"] = objdtosesionFisio.ISF_Cantidad;
			Log.WriteLog("Sesiones de nutricionista por derecho: " + objdtosesionNutri.ISN_Cantidad);
			Session["ISN_Cantidad"] = objdtosesionNutri.ISN_Cantidad;
		}
		catch (Exception ex)
		{
			ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'No tiene los permisos para actualizar', 'bottom', 'center', null, null);", true);
		}
	}
}