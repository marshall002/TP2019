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
                        <a href='#' onclick='modal('modalEnConstruccion');'>
                            <i class='material-icons'>assignment</i>
                            <span>Inscribete a las clases</span>
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
                            <span>Administra las solicitudes de citas</span>
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
}
