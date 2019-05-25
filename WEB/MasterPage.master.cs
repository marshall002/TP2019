using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Session["id_perfil"] = 1;

                int perfil = int.Parse(Session["id_perfil"].ToString());
                switch (perfil)
                {
                    case Constante.ROL_SOCIO:
                        perfil_Socio();
                        break;
                    case Constante.ROL_ADMINISTRADOR:
                        perfil_Administrador();
                        break;
                    case Constante.ROL_NUTRICIONISTA:
                        perfil_Nutricionista();
                        break;
                    case Constante.ROL_FISIOTERAPEUTA:
                        perfil_Fisioterapeuta();
                        break;
                    case Constante.ROL_ADMINISTRADOR_SISTEMA:
                        perfil_Administrador();
                        break;
                    default:
                        Session.Clear();
                        Session.Abandon();
                        Response.Redirect("inicio.aspx");
                        break;
                }
                //divname.innerhtml = session["nombre"].tostring();
                //divemail.innerhtml = session["correo"].tostring();
            }
            //cargarnotificaciones(usuario);
        }
        catch
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("inicio.aspx");
        }

    }
    public void perfil_Socio()
    {
        string html = string.Format(@"
                    <li>
                        <a href='Sol_Citas_Administracion.aspx'>
                            <i class='material-icons'>content_paste</i>
                            <span>Administra tus solicitudes de citas</span>
                        </a>
                    </li>
                    <li>
                        <a href='Inscribir_Clase.aspx'>
                            <i class='material-icons'>content_paste</i>
                            <span>Inscribite A rutinas</span>
                        </a>
                    </li>
                    <li>
                        <a href='Listar_rutinas_socio.aspx'>
                            <i class='material-icons'>content_paste</i>
                            <span>Administra tus inscripciones a clase</span>
                        </a>
                    </li>
                    ");
        this.Literal1.Text = html;
    }
    public void perfil_Administrador()
    {
        string html = string.Format(@"
                   
                   
                    <li>
                       <a href='#' onclick='modal('modalEnConstruccion');'>
                            <i class='material-icons'>content_paste</i>
                            <span>Gestionar las solicitudes</span>
                        </a>
                    </li>
                    ");
        this.Literal1.Text = html;
    }
    public void perfil_Nutricionista()
    {
        string html = string.Format(@"                   
                    <li>
                       <a href='#' onclick='modal('modalEnConstruccion');'>
                            <i class='material-icons'>content_paste</i>
                            <span>Mis citas</span>
                        </a>
                    </li>
                    ");
        this.Literal1.Text = html;
    }
    public void perfil_Fisioterapeuta()
    {
        string html = string.Format(@"
                   
                   
                    <li>
                       <a href='#' onclick='modal('modalEnConstruccion');'>
                            <i class='material-icons'>content_paste</i>
                            <span>Mis citas</span>
                        </a>
                    </li>
                    ");
        this.Literal1.Text = html;
    }
    protected void Test(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'No tiene los permisos para actualizar', 'bottom', 'center', null, null);", true);
    }

    protected void btnCerrarSesion_ServerClick(object sender, EventArgs e)
    {
        Session.Clear();
        //    Session.Abandon();
        //Response.Redirect("inicio.aspx");
    }

    protected void AdministradorOption_ServerClick(object sender, EventArgs e)
    {
        Session["id_perfil"] = 2;
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }

    protected void UsuarioOption_ServerClick(object sender, EventArgs e)
    {
        Session["id_perfil"] = 1;
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
}
