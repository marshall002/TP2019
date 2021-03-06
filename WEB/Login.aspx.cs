﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;

public partial class Login : System.Web.UI.Page
{
    Log Log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
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
                Session["TipoPlanID"] = usuarioDto.FK_IC_Cod;
                Session["direccion"] = usuarioDto.VU_Direccion;


                Log.WriteOnLog(" Session['SessionUsuario'] " + Session["SessionUsuario"]);
                Log.WriteOnLog(" Session['NombreUsuario'] " + Session["NombreUsuario"]);
                Log.WriteOnLog(" Session['APaternoUsuario'] " + Session["APaternoUsuario"]);
                Log.WriteOnLog(" Session['AMaternoUsuario'] " + Session["AMaternoUsuario"]);

                Log.WriteOnLog(" Session['direccion'] " + Session["direccion"]);
                Log.WriteOnLog(" Session['correo'] " + Session["correo"]);
                Log.WriteOnLog(" Session['id_perfil'] " + Session["id_perfil"]);
                Log.WriteOnLog(" Session['DU_FechaNacimiento'] " + Session["DU_FechaNacimiento"]);
                Log.WriteOnLog(" Session['CU_Celular'] " + Session["CU_Celular"]);
                Log.WriteOnLog(" Session['TipoPlanID'] " + Session["TipoPlanID"]);
                Log.WriteOnLog("--------------------------------------------Fin Login Aspx----------------------------------------------------");

                if (Session["id_perfil"].ToString() == "1")
                {
                    Session["DP_Fecha_Fin_Plan"] = "";
                    Session["ISF_Cantidad"] = objdtosesionFisio.ISF_Cantidad;
                    Session["ISN_Cantidad"] = objdtosesionNutri.ISN_Cantidad;

                    Log.WriteOnLog(" Session['DP_Fecha_Fin_Plan'] " + Session["DP_Fecha_Fin_Plan"]);
                    Log.WriteOnLog(" Session['ISF_Cantidad'] " + Session["ISF_Cantidad"]);
                    Log.WriteOnLog(" Session['ISN_Cantidad'] " + Session["ISN_Cantidad"]);
                }
                string script = @"<script type='text/javascript'>
                                      location.href='inicio.aspx';
                                  </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
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
            color = Constante.COLOR_ROJO;
            msj = ex.Message;
            Log.WriteOnLog("error " + ex.Message);
            mostrarMensaje.Text = msj;
        }
        if (error != Constante.ERROR_SUCCESS)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('" + color + "', '" + msj + "', 'bottom', 'center', null, null);", true);
        }
    }
}