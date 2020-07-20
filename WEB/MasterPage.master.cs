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
    Log Log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                Log.WriteOnLog("-------------------------------------------------------------------------------------------------------------");
                Log.WriteOnLog("-----------------------------Ingresando a masterpage y Obtener pestañas disponibles--------------------------");
                Log.WriteOnLog("-------------------------------------------------------------------------------------------------------------");
                int perfil = int.Parse(Session["id_perfil"].ToString());

                Log.WriteOnLog(" perfil:  " + perfil);

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
                        Response.Redirect("~/WebPrincipal/WF_Iniciar_Sesion.aspx");
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
            Response.Redirect("~/WebPrincipal/WF_Iniciar_Sesion.aspx");
        }

    }
    public void perfil_Socio()
    {
        string html1 = "";


        html1 = string.Format("<li>" +
            "<a href='SolicitarPlan.aspx'>" +
            "<i class='material-icons'>content_paste</i>"+                            
                            "<span>Se</span>"+
                        "</a>"+
                    "</li>");
        string html = string.Format(@"
                    <li>
                        <a href='SolicitarPlan.aspx'>
                            <i class='material-icons'>content_paste</i>
                            <span>Solicitar un plan</span>
                        </a>
                    </li>
                    <li>
                        <a href='Sol_Citas_Administracion.aspx'>
                            <i class='material-icons'>content_paste</i>
                            <span>Administra tus solicitudes de citas</span>
                        </a>
                    </li>
                    <li>
                        <a href='Listar_rutinas_socio.aspx'>
                            <i class='material-icons'>content_paste</i>
                            <span>Administra tus inscripciones a rutina</span>
                        </a>
                    </li>
                    <li>
                        <a href='Inscribir_Rutina.aspx'>
                            <i class='material-icons'>content_paste</i>
                            <span>Inscribete a las rutinas</span>
                        </a>
                    </li>
                     <li>
                        <a href='Realizar_Pago.aspx'>
                            <i class='material-icons'>content_paste</i>
                            <span>Mis pagos</span>
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
<li>
                        <a href='Verificar_Pago.aspx'>
                            <i class='material-icons'>content_paste</i>
                            <span>Verificar los pagos</span>
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
        Response.Redirect("~/WebPrincipal/WF_Iniciar_Sesion.aspx");
    }

    protected void AdministradorOption_ServerClick(object sender, EventArgs e)
    {

    }

    protected void UsuarioOption_ServerClick(object sender, EventArgs e)
    {
    }
}
