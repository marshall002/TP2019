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
    //DtoPlan objdtoplan = new DtoPlan();
    DtoSesionFisio objdtosesionFisio = new DtoSesionFisio();
    DtoSesionNutri objdtosesionNutri = new DtoSesionNutri();
    DtoContrato objdtocontrato = new DtoContrato();
    Log Log = new Log();

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (Session["id_persona"] != null)
            {
            Log.CustomWriteOnLog("Inicio.aspx", "ERROR en id persona");
                //Response.Redirect("login.aspx");

            }
            else
            {
                obtenerdatosUsuario();

            }
        }
    }
    public void obtenerdatosUsuario()
    {
        try
        {
            objdtousuario.PK_CU_Dni = Session["SessionUsuario"].ToString();
            objctrUsuario.ObtenerInformacionUsuario(objdtousuario, objdtocontrato, objdtosesionFisio, objdtosesionNutri);

            Log.WriteOnLog("" + objdtousuario.PK_CU_Dni);
            Log.WriteOnLog("" + objdtousuario.VU_Nombre);
            Session["NombreUsuario"] = objdtousuario.VU_Nombre;
            Log.WriteOnLog("" + objdtousuario.VU_APaterno);
            Session["APaternoUsuario"] = objdtousuario.VU_APaterno;
            Log.WriteOnLog("" + objdtousuario.VU_AMaterno);
            Session["AMaternoUsuario"] = objdtousuario.VU_AMaterno;
            Log.WriteOnLog("" + objdtousuario.CU_Celular);
            Session["CU_Celular"] = objdtousuario.CU_Celular;
            Log.WriteOnLog("" + objdtousuario.DU_FechaNacimiento);
            Session["DU_FechaNacimiento"] = objdtousuario.DU_FechaNacimiento;
            Log.WriteOnLog("" + objdtousuario.FK_ITU_Cod);
            Session["FK_ITU_Cod"] = objdtousuario.FK_ITU_Cod;
            Log.WriteOnLog("" + objdtocontrato.DC_Fecha_Vencimiento);
            Session["DP_Fecha_Fin_Plan"] = objdtocontrato.DC_Fecha_Vencimiento;
            Log.WriteOnLog("Sesiones de fisioterapeuta por derecho: " + objdtosesionFisio.ISF_Cantidad);
            Session["ISF_Cantidad"] = objdtosesionFisio.ISF_Cantidad;
            Log.WriteOnLog("Sesiones de nutricionista por derecho: " + objdtosesionNutri.ISN_Cantidad);
            Session["ISN_Cantidad"] = objdtosesionNutri.ISN_Cantidad;

            Log.CustomWriteOnLog("IniciarSesion", " Session['SessionUsuario'] " + Session["SessionUsuario"]);
            Log.CustomWriteOnLog("IniciarSesion", " Session['NombreUsuario'] " + Session["NombreUsuario"]);
            Log.CustomWriteOnLog("IniciarSesion", " Session['APaternoUsuario'] " + Session["APaternoUsuario"]);
            Log.CustomWriteOnLog("IniciarSesion", " Session['AMaternoUsuario'] " + Session["AMaternoUsuario"]);
            Log.CustomWriteOnLog("IniciarSesion", " Session['direccion'] " + Session["direccion"]);
            Log.CustomWriteOnLog("IniciarSesion", " Session['correo'] " + Session["correo"]);
            Log.CustomWriteOnLog("IniciarSesion", " Session['id_perfil'] " + Session["id_perfil"]);
            Log.CustomWriteOnLog("IniciarSesion", " Session['DU_FechaNacimiento'] " + Session["DU_FechaNacimiento"]);
            Log.CustomWriteOnLog("IniciarSesion", " Session['CU_Celular'] " + Session["CU_Celular"]);
            Log.CustomWriteOnLog("IniciarSesion", " Session['FK_ITU_Cod'] " + Session["FK_ITU_Cod"]);
            Log.CustomWriteOnLog("IniciarSesion", " Session['DP_Fecha_Fin_Plan'] " + Session["DP_Fecha_Fin_Plan"]);
            Log.CustomWriteOnLog("IniciarSesion", " Session['ISF_Cantidad'] " + Session["ISF_Cantidad"]);
            Log.CustomWriteOnLog("IniciarSesion", " Session['ISN_Cantidad'] " + Session["ISN_Cantidad"]);

            //Log.CustomWriteOnLog("IniciarSesion", " Session['TipoPlanID'] " + Session["TipoPlanID"]);
            Log.CustomWriteOnLog("IniciarSesion", "--------------------------------------------INICIO Aspx----------------------------------------------------");
        }
        catch (Exception ex)
        {

            Log.CustomWriteOnLog("Inicio.aspx", "ERROR " + ex.Message);
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'No tiene los permisos para actualizar', 'bottom', 'center', null, null);", true);
        }
    }

}