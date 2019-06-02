using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnIniciarSesión_Click(Object sender, EventArgs e)
    {

        string color = Constante.COLOR_NEGRO;
        string msj = "";
        int error = Constante.ERROR_EXIT;
        try
        {
            string usuario = textUsuario.Text.Trim();
            string clave = textPassword.Text.Trim();
            if (string.IsNullOrEmpty(usuario))
            {
                Label1.Text = "Ingrese su usuario";
                throw new Exception("Ingrese su usuario");
            }
               
            if (string.IsNullOrEmpty(clave))
            {
                Label1.Text = "Ingrese su contraseña";
                throw new Exception("Ingrese su clave");
            }
               
            DtoUsuario usuarioDto = new DtoUsuario();
            DtoTipoUsuario tipousuarioDto = new DtoTipoUsuario();
            DtoPlan planDto = new DtoPlan();


            CtrUsuario objctrUsuario = new CtrUsuario();
            DtoSesionFisio objdtosesionFisio = new DtoSesionFisio();
            DtoSesionNutri objdtosesionNutri = new DtoSesionNutri();

            usuarioDto.PK_CU_Dni = usuario;
            usuarioDto.VU_Contraseña = clave;

            CtrUsuario usuarioCtr = new CtrUsuario();

            usuarioDto = usuarioCtr.Login(usuarioDto);
            Log.WriteLog("usuarioDto" + usuarioDto);
            
            if (usuarioDto != null)
            {
                Log.WriteLog("-------------------------------------------------------------------------------------------------------------");
                Log.WriteLog("-----------------------------Ingresando a login y seteando valores de session--------------------------------");
                Log.WriteLog("-------------------------------------------------------------------------------------------------------------");

                objctrUsuario.ObtenerInformacionUsuario(usuarioDto, planDto, objdtosesionFisio, objdtosesionNutri);

                Session["SessionUsuario"] = usuarioDto.PK_CU_Dni;
                Session["NombreUsuario"] = usuarioDto.VU_Nombre;
                Session["APaternoUsuario"] = usuarioDto.VU_APaterno;
                Session["AMaternoUsuario"] = usuarioDto.VU_AMaterno;
                Session["NombreCompleto"] = usuarioDto.VU_Nombre + " " + usuarioDto.VU_APaterno + " " + usuarioDto.VU_AMaterno;
                Session["CU_Celular"] = usuarioDto.CU_Celular;
                Session["DU_FechaNacimiento"] = usuarioDto.DU_FechaNacimiento;
                Session["id_perfil"] = usuarioDto.FK_ITU_Cod;
                Session["correo"] = usuarioDto.VU_Correo;
                Session["TipoPlanID"] = usuarioDto.FK_IP_Cod;
                Session["direccion"] = usuarioDto.VU_Direccion;


                Log.WriteLog(" Session['SessionUsuario'] " + Session["SessionUsuario"]);
                Log.WriteLog(" Session['NombreUsuario'] " + Session["NombreUsuario"]);
                Log.WriteLog(" Session['APaternoUsuario'] " + Session["APaternoUsuario"]);
                Log.WriteLog(" Session['AMaternoUsuario'] " + Session["AMaternoUsuario"]);

                Log.WriteLog(" Session['direccion'] " + Session["direccion"]);
                Log.WriteLog(" Session['correo'] " + Session["correo"]);
                Log.WriteLog(" Session['id_perfil'] " + Session["id_perfil"]);
                Log.WriteLog(" Session['DU_FechaNacimiento'] " + Session["DU_FechaNacimiento"]);
                Log.WriteLog(" Session['CU_Celular'] " + Session["CU_Celular"]);
                Log.WriteLog(" Session['TipoPlanID'] " + Session["TipoPlanID"]);
                Log.WriteLog("--------------------------------------------Fin Login Aspx----------------------------------------------------");

                if (Session["id_perfil"].ToString() == "1")
                {
                    Session["DP_Fecha_Fin_Plan"] = planDto.DP_Fecha_Fin;
                    Session["ISF_Cantidad"] = objdtosesionFisio.ISF_Cantidad;
                    Session["ISN_Cantidad"] = objdtosesionNutri.ISN_Cantidad;
                
                    Log.WriteLog(" Session['DP_Fecha_Fin_Plan'] " + Session["DP_Fecha_Fin_Plan"]);
                    Log.WriteLog(" Session['ISF_Cantidad'] " + Session["ISF_Cantidad"]);
                    Log.WriteLog(" Session['ISN_Cantidad'] " + Session["ISN_Cantidad"]);
                }
                string script = @"<script type='text/javascript'>
                                      location.href='inicio.aspx';
                                  </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                error = Constante.ERROR_SUCCESS;

                tipousuarioDto.PK_TU_Cod = usuarioDto.FK_ITU_Cod;
                planDto.PK_IP_Cod = usuarioDto.FK_IP_Cod;

            }
            else
            {

                Label1.Text = "Su usuario o contraseña incorrecta o no existe";
                //throw new Exception("Su usuario o contraseña incorrecta o no existe");
            }

        }
        catch (Exception ex)
        {
            color = Constante.COLOR_ROJO;
            msj = ex.Message;
                Log.WriteLog("error" + ex.Message);

        }
        if (error != Constante.ERROR_SUCCESS)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('" + color + "', '" + msj + "', 'bottom', 'center', null, null);", true);
        }
    }
}