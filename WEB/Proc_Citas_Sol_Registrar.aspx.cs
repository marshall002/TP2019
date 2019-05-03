using CTR;
using DTO;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Proc_CItas_Sol_Registrar : System.Web.UI.Page
{
    DtoUsuario objdtousuario = new DtoUsuario();
    CtrUsuario objctrUsuario = new CtrUsuario();
    DtoPlan objdtoplan = new DtoPlan();
    DtoSesionFisio objdtosesionFisio = new DtoSesionFisio();
    DtoSesionNutri objdtosesionNutri = new DtoSesionNutri();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            contarCitasxServicio();
            CargarDatosDniUsuario();
        }
    }
    protected void btnGuardar_ServerClick(object sender, EventArgs e)
    {
        try
        {
            string valorRadiobuttonentxt = txtresultadoChecbox.Value;
            Log.WriteLog("1");
            contarCitasxServicio();
            Log.WriteLog("2");

            Log.WriteLog("---------------------------------------------------------------------------------------------");
            Log.WriteLog("Cantidad de sesiones x plan de fisioterapeuta actuales: " + Session["ISF_Cantidad"].ToString());
            Log.WriteLog("Contador de sesiones registradas actuales: " + objdtousuario.IC_Citas_Fisio_Usadas.ToString());
            Log.WriteLog("Contador de sesiones x plan de nutricionista actuales: " + Session["ISN_Cantidad"].ToString());
            Log.WriteLog("Contador de sesiones registradas actuales: " + objdtousuario.IC_Citas_Nutri_Usadas.ToString());
            Log.WriteLog("---------------------------------------------------------------------------------------------");

            Log.WriteLog("3");
            if (valorRadiobuttonentxt == "1")//Nutri
            {
                Log.WriteLog("4");
                if (int.Parse(objdtousuario.IC_Citas_Nutri_Usadas.ToString()) >= int.Parse(Session["ISN_Cantidad"].ToString()))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Debe adjuntar el derecho de pago para Nutri', 'bottom', 'center', null, null);", true);
                }
                else
                {
                    RegistrarCodigo(valorRadiobuttonentxt);
                }
            }
            else if (valorRadiobuttonentxt == "2")//Fisio
            {
                Log.WriteLog("5");
                if (int.Parse(objdtousuario.IC_Citas_Fisio_Usadas.ToString()) >= int.Parse(Session["ISF_Cantidad"].ToString()))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Debe adjuntar el derecho de pago para Fisio', 'bottom', 'center', null, null);", true);
                }
                else
                {
                    RegistrarCodigo(valorRadiobuttonentxt);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'asdasd" + ex.Message + "', 'bottom', 'center', null, null);", true);

        }

    }
    public void RegistrarCodigo(string valorRadiobuttonentxt)
    {
        TimeSpan Hora = TimeSpan.Parse(ddlHoras.Text);
        string txtareaconsulta = txtDudaConsulta.Text.Trim();
        DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
        DateTime fechasolitada = Fecha + Hora;
        string Sesion = "74931448";

        int IECCod = 2;

        DtoCita dto_Cita = new DtoCita();
        CtrCita ctr_Cita = new CtrCita();

        //dto_Cita.FK_ITC_Cod = int.Parse(valorRadiobuttonentxt);
        //dto_Cita.DC_FechaHoraSolicitada = fechasolitada;
        //dto_Cita.DC_FechaHoraCreada = DateTime.Now;
        //dto_Cita.VC_Observacion = txtareaconsulta;
        //dto_Cita.FK_IEC_Cod = IECCod;
        //dto_Cita.FK_CU_DNI = Sesion;

        string mensaje = "Registrado con exito";
        ctr_Cita.registrarSolicitudCita(fechasolitada, txtareaconsulta, DateTime.Now, IECCod, int.Parse(valorRadiobuttonentxt), Sesion);

        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + mensaje + "', 'bottom', 'center', null, null);", true);
    }
    protected void btnCancelar_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("~/Proc_Sol_Listar.aspx");
    }
    public void contarCitasxServicio()
    {
        objdtousuario.PK_CU_Dni = DdlUsuariosID.SelectedValue.ToString();
        objctrUsuario.ObtenerNumCitasRealizadas(objdtousuario);
    }

    protected void ddlHoras_SelectedIndexChanged(object sender, EventArgs e)
    {
        Log.WriteLog("Valor de dropdownList seleccionado : " + ddlHoras.SelectedValue);
    }

    protected void DdlUsuariosID_SelectedIndexChanged(object sender, EventArgs e)
    {
        Log.WriteLog("Ddl value" + DdlUsuariosID.SelectedValue);
        obtenerdatosUsuario();
        txtNombre.Text = objdtousuario.VU_Nombre + " " + objdtousuario.VU_APaterno + " " + objdtousuario.VU_AMaterno;
        txtNombre.Attributes.Add("disabled", "disabled");
    }

    public void obtenerdatosUsuario()
    {
        try
        {
            objdtousuario.PK_CU_Dni = DdlUsuariosID.SelectedValue;
            objctrUsuario.ObtenerInformacionUsuario(objdtousuario, objdtoplan, objdtosesionFisio, objdtosesionNutri);

            Log.WriteLog("" + objdtousuario.PK_CU_Dni);
            Log.WriteLog("" + objdtousuario.VU_Nombre);
            Session["NombreUsuario"] = objdtousuario.VU_Nombre;
            Log.WriteLog("" + objdtousuario.VU_APaterno);
            Session["APaternoUsuario"] = objdtousuario.VU_APaterno;
            Log.WriteLog("" + objdtousuario.VU_AMaterno);
            Session["AMaternoUsuario"] = objdtousuario.VU_AMaterno;
        }
        catch (Exception ex)
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