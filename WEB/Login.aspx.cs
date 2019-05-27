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
        {;
            string usuario = textUsuario.Text.Trim();
            string clave = textPassword.Text.Trim();
            if (string.IsNullOrEmpty(usuario))
                throw new Exception("Ingrese su usuario");

            if (string.IsNullOrEmpty(clave))
                throw new Exception("Ingrese su clave");
            DtoUsuario usuarioDto = new DtoUsuario();
            usuarioDto.PK_CU_Dni = usuario;
            usuarioDto.VU_Contraseña = clave;

            CtrUsuario usuarioCtr = new CtrUsuario();

            usuarioDto = usuarioCtr.Login(usuarioDto);
            Log.WriteLog("usuarioDto" + usuarioDto);

            int codigo = usuarioDto.FK_ITU_Cod;
            string nombre = usuarioDto.VU_Nombre;
            string apellido = usuarioDto.VU_APaterno;
            string correo = usuarioDto.VU_Correo;
            Session["idusuario"] = textUsuario.Text.Trim();
            if (usuarioDto != null)
            {

                string script = @"<script type='text/javascript'>
                                      location.href='inicio.aspx';
                                  </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                error = Constante.ERROR_SUCCESS;
                Log.WriteLog("error" + error);
            }
            else
            {
                throw new Exception("Su usuario o contraseña incorrecta o no existe");
            }

        }
        catch (Exception ex)
        {
            color = Constante.COLOR_ROJO;
            msj = ex.Message;
        }
        if (error != Constante.ERROR_SUCCESS)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('" + color + "', '" + msj + "', 'bottom', 'center', null, null);", true);
        }
    }
}