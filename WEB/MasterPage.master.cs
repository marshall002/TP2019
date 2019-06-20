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

                Log.WriteLog("-------------------------------------------------------------------------------------------------------------");
                Log.WriteLog("-----------------------------Ingresando a masterpage y Obtener pestañas disponibles--------------------------");
                Log.WriteLog("-------------------------------------------------------------------------------------------------------------");
                int perfil = int.Parse(Session["id_perfil"].ToString());

                Log.WriteLog(" perfil:  " + perfil);

                string nombre = Session["NombreUsuario"].ToString() + " " + Session["APaternoUsuario"].ToString()
                                 + " " + Session["AMaternoUsuario"].ToString();

                nombreUsuario.Text = nombre;

                string email = Session["correo"].ToString();

                emailUsuario.Text = email;

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
                    case Constante.ROL_ENTRENADOR:
                        perfil_Entrenador();
                        break;
                    default:
                        Session.Clear();
                        Session.Abandon();
                        Response.Redirect("login.aspx");
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
            Response.Redirect("login.aspx");
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
                        <a href='Inscribir_Rutina.aspx'>
                            <i class='material-icons'>content_paste</i>
                            <span>Inscribite A rutinas</span>
                        </a>
                    </li>
                    <li>
                        <a href='Listar_rutinas_socio.aspx'>
                            <i class='material-icons'>content_paste</i>
                            <span>Administra tus inscripciones a rutina</span>
                        </a>
                    </li>
                    ");
        this.Literal1.Text = html;
    }
    public void perfil_Administrador()
    {
        string html = string.Format(@"


                   <li>
                        <a href='Proc_Citas_Sol_Listar.aspx'>
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
                       <a href='AdministrarCitaNutri.aspx'>
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
                       <a href='MonitorearCitaFisio.aspx'>
                            <i class='material-icons'>content_paste</i>
                            <span>Mis citas</span>
                        </a>
                    </li>
                    ");
        this.Literal1.Text = html;
    }
    public void perfil_Entrenador()
    {
        string html = string.Format(@"
                   <li>
                        <a href='AdministrarRutina.aspx'>
                            <i class='material-icons'>content_paste</i>
                            <span>Administra las rutinas</span>
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
        Session.Abandon();
        Response.Redirect("login.aspx");
    }

    protected void AdministradorOption_ServerClick(object sender, EventArgs e)
    {
        
    }

    protected void UsuarioOption_ServerClick(object sender, EventArgs e)
    {
    }
}
