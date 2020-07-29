using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DTO;
using CTR;

public partial class WebPrincipal_WF_Iniciar_Sesion1 : System.Web.UI.Page
{
    Log Log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }


    protected void btnIniciarSesión_Click(object sender, EventArgs e)
    {
        try
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
                    //mostrarMensaje.Text = "Ingrese su usuario";

                    throw new Exception("Ingrese su usuario");
                }

                if (string.IsNullOrEmpty(clave))
                {
                    //mostrarMensaje.Text = "Ingrese su contraseña";

                    throw new Exception("Ingrese su clave");
                }

                DtoUsuario usuarioDto = new DtoUsuario();
                DtoTipoUsuario tipousuarioDto = new DtoTipoUsuario();
                DtoPlan planDto = new DtoPlan();
                DtoContrato contratoDto = new DtoContrato();


                CtrUsuario objctrUsuario = new CtrUsuario();
                DtoSesionFisio objdtosesionFisio = new DtoSesionFisio();
                DtoSesionNutri objdtosesionNutri = new DtoSesionNutri();

                usuarioDto.PK_CU_Dni = usuario;
                usuarioDto.VU_Contrasenia = clave;

                CtrUsuario usuarioCtr = new CtrUsuario();

                usuarioDto = usuarioCtr.Login(usuarioDto);
                Log.WriteOnLog("usuarioDto" + usuarioDto);

                if (usuarioDto != null)
                {
                    Log.WriteOnLog("-------------------------------------------------------------------------------------------------------------");
                    Log.WriteOnLog("-----------------------------Ingresando a login y seteando valores de session--------------------------------");
                    Log.WriteOnLog("-------------------------------------------------------------------------------------------------------------");

                    objctrUsuario.ObtenerInformacionUsuario(usuarioDto, contratoDto, objdtosesionFisio, objdtosesionNutri);

                    Session["SessionUsuario"] = usuarioDto.PK_CU_Dni;
                    Session["NombreUsuario"] = usuarioDto.VU_Nombre;
                    Session["APaternoUsuario"] = usuarioDto.VU_APaterno;
                    Session["AMaternoUsuario"] = usuarioDto.VU_AMaterno;
                    Session["NombreCompleto"] = usuarioDto.VU_Nombre + " " + usuarioDto.VU_APaterno + " " + usuarioDto.VU_AMaterno;
                    Session["CU_Celular"] = usuarioDto.CU_Celular;
                    Session["DU_FechaNacimiento"] = usuarioDto.DU_FechaNacimiento;




                    Session["id_perfil"] = usuarioDto.FK_ITU_Cod;
                    Session["correo"] = usuarioDto.VU_Correo;
                    //Session["TipoPlanID"] = usuarioDto.FK_IC_Cod;


                    Session["direccion"] = usuarioDto.VU_Direccion;
                    Session["IC_Citas_Fisio_Usadas"] = usuarioDto.IC_Citas_Fisio_Usadas;
                    Session["IC_Citas_Nutri_Usadas"] = usuarioDto.IC_Citas_Nutri_Usadas;


                    Log.CustomWriteOnLog("IniciarSesion", " Session['SessionUsuario'] " + Session["SessionUsuario"]);
                    Log.CustomWriteOnLog("IniciarSesion", " Session['NombreUsuario'] " + Session["NombreUsuario"]);
                    Log.CustomWriteOnLog("IniciarSesion", " Session['APaternoUsuario'] " + Session["APaternoUsuario"]);
                    Log.CustomWriteOnLog("IniciarSesion", " Session['AMaternoUsuario'] " + Session["AMaternoUsuario"]);
                    Log.CustomWriteOnLog("IniciarSesion", " Session['direccion'] " + Session["direccion"]);
                    Log.CustomWriteOnLog("IniciarSesion", " Session['correo'] " + Session["correo"]);
                    Log.CustomWriteOnLog("IniciarSesion", " Session['id_perfil'] " + Session["id_perfil"]);
                    Log.CustomWriteOnLog("IniciarSesion", " Session['DU_FechaNacimiento'] " + Session["DU_FechaNacimiento"]);
                    Log.CustomWriteOnLog("IniciarSesion", " Session['CU_Celular'] " + Session["CU_Celular"]);
                    //Log.CustomWriteOnLog("IniciarSesion", " Session['TipoPlanID'] " + Session["TipoPlanID"]);
                    Log.CustomWriteOnLog("IniciarSesion", "--------------------------------------------Fin Login Aspx----------------------------------------------------");

                    if (usuarioDto.FK_IC_Cod != 0)
                    {
                        if (Session["id_perfil"].ToString() == "1")
                        {

                            Session["TipoPlanID"] = usuarioDto.FK_IC_Cod.ToString();

                            Log.CustomWriteOnLog("IniciarSesion", " Session['TipoPlanID'] " + Session["TipoPlanID"]);

                        }
                    }
                    else
                    {
                        Session["TipoPlanID"] = "0";
                    }

                    Log.CustomWriteOnLog("IniciarSesion", "0");
                    string script = @"<script type='text/javascript'>
                                      location.href='../inicio.aspx';
                                  </script>";
                    Log.CustomWriteOnLog("IniciarSesion", "1");
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                    Log.CustomWriteOnLog("IniciarSesion", "2");
                    error = Constante.ERROR_SUCCESS;

                    tipousuarioDto.PK_TU_Cod = usuarioDto.FK_ITU_Cod;
                    planDto.PK_IP_Cod = usuarioDto.FK_IC_Cod;

                }
                else
                {

                    //mostrarMensaje.Text = "Su usuario o contraseña incorrecta o no existe";
                    throw new Exception("Su usuario o contraseña incorrecta o no existe");

                }

            }
            catch (Exception ex)
            {
                Log.CustomWriteOnLog("IniciarSesion", "Error=  " + ex.Message + "Ubicacion" + ex.StackTrace);
                color = Constante.COLOR_ROJO;
                msj = ex.Message;
                Log.WriteOnLog("error " + ex.Message);
                mostrarMensaje.Text = msj;
                Log.CustomWriteOnLog("IniciarSesion", "ERROR ex dentro de : " + ex.Message);
            }
            if (error != Constante.ERROR_SUCCESS)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('" + color + "', '" + msj + "', 'bottom', 'center', null, null);", true);
            }
        }
        catch (Exception ex)
        {
            Log.CustomWriteOnLog("IniciarSesion", "ERROR " + ex.Message);
        }
    }
}