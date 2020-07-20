using CTR;
using DTO;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Proc_CItas_Sol_Registrar : System.Web.UI.Page
{
    DtoUsuario objdtousuario = new DtoUsuario();
    DtoCita objdtoCita = new DtoCita();
    CtrUsuario objctrUsuario = new CtrUsuario();
    DtoPlan objdtoplan = new DtoPlan();
    DtoSesionFisio objdtosesionFisio = new DtoSesionFisio();
    DtoSesionNutri objdtosesionNutri = new DtoSesionNutri();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["id_perfil"] != null)
            {
                if (int.Parse(Session["id_perfil"].ToString()) == Constante.ROL_ADMINISTRADOR)
                {
                    contarCitasxServicio();
                    CargarDatosDniUsuario();
                }
                else
                {
                    Log.WriteOnLog("Proc Citas Sol Registrar - Error en id Perfil");
                    Response.Redirect("Inicio.aspx");
                }
            }
            else
            {

                Log.WriteOnLog("Proc Citas Sol Registrar - Error en id Perfil");
                Response.Redirect("Inicio.aspx");

            }
        }
    }
    protected void btnGuardar_ServerClick(object sender, EventArgs e)
    {
        try
        {
            string valorRadiobuttonentxt = txtresultadoChecbox.Value;
            contarCitasxServicio();

            if (valorRadiobuttonentxt == "1")//Nutri
            {
                if (int.Parse(objdtousuario.IC_Citas_Nutri_Usadas.ToString()) >= int.Parse(Session["ISN_Cantidad"].ToString()))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Debe adjuntar el derecho de pago para Nutri', 'bottom', 'center', null, null);", true);
                }
                else
                {
                    RegistrarCita(valorRadiobuttonentxt);
                }
            }
            else if (valorRadiobuttonentxt == "2")//Fisio
            {
                if (int.Parse(objdtousuario.IC_Citas_Fisio_Usadas.ToString()) >= int.Parse(Session["ISF_Cantidad"].ToString()))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Debe adjuntar el derecho de pago para Fisio', 'bottom', 'center', null, null);", true);
                }
                else
                {
                    RegistrarCita(valorRadiobuttonentxt);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'asdasd" + ex.Message + "', 'bottom', 'center', null, null);", true);

        }

    }
    public void RegistrarCita(string valorRadiobuttonentxt)
    {

        TimeSpan Hora = TimeSpan.Parse(ddlHoras.Text);
        string txtareaconsulta = txtDudaConsulta.Text.Trim();
        DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
        DateTime fechasolitada = Fecha + Hora;
        string DNIUsuario = DdlUsuariosID.SelectedValue;

        objdtoCita.DC_FechaHoraSolicitada = fechasolitada;
        objdtoCita.VC_Observacion = txtareaconsulta;
        objdtoCita.FK_IEC_Cod = 2;
        objdtoCita.FK_ITC_Cod = int.Parse(valorRadiobuttonentxt);
        objdtoCita.FK_CU_DNI = DNIUsuario;

        CtrCita ctr_Cita = new CtrCita();

        string mensaje = "Registrado con exito";
        ctr_Cita.RegistrarCita(objdtoCita);

        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + mensaje + "', 'bottom', 'center', null, null);", true);
    }
    protected void btnCancelar_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("~/Proc_Sol_Listar.aspx");
    }
    public void contarCitasxServicio()
    {
        Log.WriteOnLog("1");
        objdtousuario.PK_CU_Dni = DdlUsuariosID.SelectedValue.ToString();
        Log.WriteOnLog("2");
        objctrUsuario.ObtenerNumCitasRealizadas(objdtousuario);
    }

    protected void ddlHoras_SelectedIndexChanged(object sender, EventArgs e)
    {
        Log.WriteOnLog("Valor de dropdownList seleccionado : " + ddlHoras.SelectedValue);
    }

    protected void DdlUsuariosID_SelectedIndexChanged(object sender, EventArgs e)
    {
        obtenerdatosUsuario();
        txtNombre.Text = objdtousuario.VU_Nombre;
        txtApellidos.Text= objdtousuario.VU_APaterno + " " + objdtousuario.VU_AMaterno;
        txtNombre.Attributes.Add("disabled", "disabled");
        txtApellidos.Attributes.Add("disabled", "disabled");
    }

    public void obtenerdatosUsuario()
    {
        try
        {
            objdtousuario.PK_CU_Dni = DdlUsuariosID.SelectedValue;
            objctrUsuario.ObtenerInformacionUsuario(objdtousuario, objdtoplan, objdtosesionFisio, objdtosesionNutri);
        }
        catch (Exception )
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'No tiene los permisos para actualizar', 'bottom', 'center', null, null);", true);
            
        }
    }

    public void CargarDatosDniUsuario()
    {
        CtrUsuario objctrusuario = new CtrUsuario();

        DdlUsuariosID.DataSource = objctrusuario.ListarDNIUsuario();
        DdlUsuariosID.DataTextField = "PK_CU_Dni";
        DdlUsuariosID.DataValueField = "PK_CU_Dni";
        DdlUsuariosID.DataBind();
        DdlUsuariosID.Items.Insert(0, new ListItem("Seleccione el DNI", "NUll"));
    }

}