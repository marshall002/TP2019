using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;

public partial class WebPrincipal_WF_Registrar_Socio : System.Web.UI.Page
{
    DtoUsuario objdtoUsuario = new DtoUsuario();
    CtrUsuario objctrUsuario = new CtrUsuario();
    Log _Log = new Log();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        

    }

    protected void btnregistrarsocio_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtDni.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "El campo DNI se encuentra vacio" + "');", true);
                return;
            }
            if (txtnombre.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "El campo nombre se encuentra vacio" + "');", true);
                return;
            }
            if (txtapellidopaterno.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "El campo apellido paterno se encuentra vacio" + "');", true);
                return;
            }
            if (txtapellidomaterno.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "El campo apellido materno se encuentra vacio" + "');", true);
                return;
            }
            if (txtcorreo.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "El campo correo se encuentra vacio" + "');", true);
                return;
            }
            if (txtcelular.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "El campo celular se encuentra vacio" + "');", true);
                return;
            }
            if (txtedad.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "El campo edad se encuentra vacio" + "');", true);
                return;
            }
            if (txtdireccion.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "El campo direccion se encuentra vacio" + "');", true);
                return;
            }
            if (txtcontrasenia.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "El campo contraseña se encuentra vacio" + "');", true);
                return;
            }
            if (txtDni.Text.Trim().Length != 8)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "El DNI debe tener 8 digitos." + "');", true);
                return;
            }
            if (txtcelular.Text.Trim().Length != 9)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "El celular debe tener 9 digitos." + "');", true);
                return;
            }

            DateTime fecha = DateTime.Now;

            objdtoUsuario.PK_CU_Dni = txtDni.Text;
            objdtoUsuario.VU_Nombre = txtnombre.Text;
            objdtoUsuario.VU_APaterno = txtapellidopaterno.Text;
            objdtoUsuario.VU_AMaterno = txtapellidomaterno.Text;
            objdtoUsuario.VU_Correo = txtcorreo.Text;
            objdtoUsuario.DU_FechaNacimiento = Convert.ToDateTime(txtedad.Text);
            //objdtoUsuario.IU_Edad = int.Parse(txtedad.Text);
            objdtoUsuario.VU_Contrasenia = txtcontrasenia.Text;
            objdtoUsuario.CU_Celular = txtcelular.Text;
            objdtoUsuario.VU_Direccion = txtdireccion.Text;
            objctrUsuario.RegistrarSocio(objdtoUsuario);

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "Se a registrado el Socio con exito" + "');", true);

        }
        catch (Exception ex)
        {
            _Log.CustomWriteOnLog("RegistrarSocio.aspx","ERROR:   " + ex.Message);
        }
        
    }

    protected void btnregresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("WF_Iniciar_Sesion.aspx");

    }

}