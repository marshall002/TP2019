using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class SolicitudPlan : System.Web.UI.Page
{
    Log _log = new Log();
    DtoUsuario objDtoUsuario = new DtoUsuario();
    DtoContrato objDtoContrato = new DtoContrato();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Session["id_perfil"].ToString() == "1")
                {
                    ObtenerSolicitudesContratoxUsuarioxEstado();
                }
                else if (Session["id_perfil"].ToString() == "2")
                {
                    ObtenerSolicitudesContratoxEstado();
                }
                else
                {
                    _log.CustomWriteOnLog("SolicitudesPlan", "ERROR EN ID PERFIL  + " + Session["id_perfil"].ToString());
                    Response.Redirect("Inicio.aspx");
                }
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("SolicitudesPlan", "ERROR EN PAGE LOAD " + ex.Message + " Stacktrace " +ex.StackTrace);
            }

        }
    }
    public void ObtenerSolicitudesContratoxUsuarioxEstado()
    {
        CtrContrato objCtrContrato = new CtrContrato();
        objDtoUsuario.PK_CU_Dni = Session["SessionUsuario"].ToString();
        objDtoContrato.FK_IEC_Cod = 2;
        gvSolPendientePago.DataSource = objCtrContrato.ListarSolicitudesContratoxUsuarioxEstado(objDtoUsuario, objDtoContrato);
        gvSolPendientePago.DataBind();
        objDtoContrato.FK_IEC_Cod = 1;
        gvSolRevision.DataSource = objCtrContrato.ListarSolicitudesContratoxUsuarioxEstado(objDtoUsuario, objDtoContrato);
        gvSolRevision.DataBind();
        objDtoContrato.FK_IEC_Cod = 7;
        gvSolCancelados.DataSource = objCtrContrato.ListarSolicitudesContratoxUsuarioxEstado(objDtoUsuario, objDtoContrato);
        gvSolCancelados.DataBind();
        objDtoContrato.FK_IEC_Cod = 4;
        gvSolRechazadas.DataSource = objCtrContrato.ListarSolicitudesContratoxUsuarioxEstado(objDtoUsuario, objDtoContrato);
        gvSolRechazadas.DataBind();
        objDtoContrato.FK_IEC_Cod = 8;
        gvSolPagadoSinRevision.DataSource = objCtrContrato.ListarSolicitudesContratoxUsuarioxEstado(objDtoUsuario, objDtoContrato);
        gvSolPagadoSinRevision.DataBind();
        objDtoContrato.FK_IEC_Cod = 3;
        gvSolAprobados.DataSource = objCtrContrato.ListarSolicitudesContratoxUsuarioxEstado(objDtoUsuario, objDtoContrato);
        gvSolAprobados.DataBind();
        updPanelAprobado.Update();
    }
    public void ObtenerSolicitudesContratoxEstado()
    {
        CtrContrato objCtrContrato = new CtrContrato();
        objDtoContrato.FK_IEC_Cod = 2;
        gvSolPendientePago.DataSource = objCtrContrato.ListarSolicitudesContratoxEstado(objDtoContrato);
        gvSolPendientePago.DataBind();
        objDtoContrato.FK_IEC_Cod = 1;
        gvSolRevision.DataSource = objCtrContrato.ListarSolicitudesContratoxEstado(objDtoContrato);
        gvSolRevision.DataBind();
        objDtoContrato.FK_IEC_Cod = 7;
        gvSolCancelados.DataSource = objCtrContrato.ListarSolicitudesContratoxEstado(objDtoContrato);
        gvSolCancelados.DataBind();
        objDtoContrato.FK_IEC_Cod = 4;
        gvSolRechazadas.DataSource = objCtrContrato.ListarSolicitudesContratoxEstado(objDtoContrato);
        gvSolRechazadas.DataBind();
        objDtoContrato.FK_IEC_Cod = 3;
        gvSolAprobados.DataSource = objCtrContrato.ListarSolicitudesContratoxEstado(objDtoContrato);
        gvSolAprobados.DataBind();
        objDtoContrato.FK_IEC_Cod = 8;
        gvSolPagadoSinRevision.DataSource = objCtrContrato.ListarSolicitudesContratoxEstado(objDtoContrato);
        gvSolPagadoSinRevision.DataBind();
    }

    protected void gvSolAprobado_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Ver")
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvSolRevision.DataKeys[index].Values;
                string id = colsNoVisible[0].ToString();
                string Descripcion = colsNoVisible[1].ToString();

                txtDescripcionModal.Text = Descripcion;
                tituloModal.InnerText = "Descripción de solicitud " + id;


                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#defaultmodal').modal('show');</script>", false);

            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("SolicitudesPlan", "Error = " + ex.Message + "Stac" + ex.StackTrace);

            }

        }
        else if (e.CommandName == "Cancelar")
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvSolRevision.DataKeys[index].Values;
                string id = colsNoVisible[0].ToString();
                hfContentIDSol.Value = id;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#confirmacionmodal').modal('show');</script>", false);
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("SolicitudesPlan", "Error = " + ex.Message + "Stac" + ex.StackTrace);
            }

        }
        else if (e.CommandName == "Rechazar")
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvSolRevision.DataKeys[index].Values;
                string id = colsNoVisible[0].ToString();
                hfContentIDSol.Value = id;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#RechazarModal').modal('show');</script>", false);

            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("SolicitudesPlan", "Error = " + ex.Message + "Stac" + ex.StackTrace);
            }
        }
        else if (e.CommandName == "Aprobar")
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvSolRevision.DataKeys[index].Values;
                string id = colsNoVisible[0].ToString();
                hfContentIDSol.Value = id;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#AprobarModal').modal('show');</script>", false);

            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("SolicitudesPlan", "Error = " + ex.Message + "Stac" + ex.StackTrace);
            }
        }
    }

    protected void btnAceptarCancelarSol_Click(object sender, EventArgs e)
    {
        try
        {
            CtrContrato objCtrContrato = new CtrContrato();
            string valorHF = hfContentIDSol.Value;
            objDtoContrato.PK_IC_Cod = int.Parse(valorHF);
            objDtoContrato.FK_IEC_Cod = 7;
            objCtrContrato.ActualizarContrato(objDtoContrato);
            Utils.AddScriptClientUpdatePanel(updPanelConfirmacion, "mostrarMensajeConfirmacion();");
            if (Session["id_perfil"].ToString() == "1")
            {
                updPanelPendientePago.Update();
                updPanelRevision.Update();
                updPanelCancelado.Update();
                updPanelRechazada.Update();
                ObtenerSolicitudesContratoxUsuarioxEstado();
            }
            else if (Session["id_perfil"].ToString() == "2")
            {

                updPanelPendientePago.Update();
                updPanelRevision.Update();
                updPanelCancelado.Update();
                updPanelRechazada.Update();
                ObtenerSolicitudesContratoxEstado();
            }
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("SolicitudesPlan", "Error = " + ex.Message + "Stac" + ex.StackTrace);

        }

    }

    protected void gvSolCancelados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ver")
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvSolCancelados.DataKeys[index].Values;
                string id = colsNoVisible[0].ToString();
                string Descripcion = colsNoVisible[1].ToString();

                txtDescripcionModal.Text = Descripcion;
                tituloModal.InnerText = "Descripción de solicitud " + id;


                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#defaultmodal').modal('show');</script>", false);

            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("SolicitudesPlan", "Error = " + ex.Message + "Stac" + ex.StackTrace);

            }

        }
    }

    protected void gvSolRechazadas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ver")
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvSolRechazadas.DataKeys[index].Values;
                string id = colsNoVisible[0].ToString();
                string Descripcion = colsNoVisible[1].ToString();

                txtDescripcionModal.Text = Descripcion;
                tituloModal.InnerText = "Descripción de solicitud " + id;


                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#defaultmodal').modal('show');</script>", false);

            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("SolicitudesPlan", "Error = " + ex.Message + "Stac" + ex.StackTrace);

            }

        }
    }

    protected void gvSolPendientePago_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Ver")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvSolPendientePago.DataKeys[index].Values;
                string id = colsNoVisible[0].ToString();
                string Descripcion = colsNoVisible[1].ToString();

                txtDescripcionModal.Text = Descripcion;
                tituloModal.InnerText = "Descripción de solicitud " + id;


                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#defaultmodal').modal('show');</script>", false);



            }
            else if (e.CommandName == "Anexarpago")
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    var colsNoVisible = gvSolPendientePago.DataKeys[index].Values;
                    string id = colsNoVisible[0].ToString();
                    hfContentIDSol.Value = id;

                    string cs = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand("SP_GetImageById", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter paramId = new SqlParameter()
                        {
                            ParameterName = "@Id",
                            Value = id
                        };
                        cmd.Parameters.Add(paramId);
                        con.Open();
                        byte[] ByteArray;
                        if (cmd.ExecuteScalar() != DBNull.Value)
                        {
                            ByteArray = (byte[])cmd.ExecuteScalar();
                            con.Close();
                            string strbase64 = Convert.ToBase64String(ByteArray);
                            Image2.ImageUrl = "data:Image/png;base64," + strbase64;
                            Image2.Visible = true;
                        }
                        else
                        {
                            con.Close();
                            Image2.Visible = false;
                            _log.CustomWriteOnLog("SolicitudesPlan", "No hay imagen aún");
                        }
                    }


                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#modalCargarPago').modal('show');</script>", false);

                }
                catch (Exception ex)
                {
                    _log.CustomWriteOnLog("SolicitudesPlan", "Error = " + ex.Message + "Stac" + ex.StackTrace);
                }
            }
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("SolicitudesPlan", "Error = " + ex.Message + "Stac" + ex.StackTrace);

        }
    }


    protected void gvSolRevision_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (Session["id_perfil"].ToString() == "1")
        {
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
        }
        else if (Session["id_perfil"].ToString() == "2")
        {
            e.Row.Cells[10].Visible = false;
        }

    }

    protected void btnaceptarRechazo_Click(object sender, EventArgs e)
    {
        try
        {
            CtrContrato objCtrContrato = new CtrContrato();
            string valorHF = hfContentIDSol.Value;
            objDtoContrato.PK_IC_Cod = int.Parse(valorHF);
            objDtoContrato.FK_IEC_Cod = 4;
            objCtrContrato.ActualizarContrato(objDtoContrato);
            Utils.AddScriptClientUpdatePanel(UpdatePanel3, "mostrarMensajeCancelacion();");
            if (Session["id_perfil"].ToString() == "1")
            {
                updPanelPendientePago.Update();
                updPanelRevision.Update();
                updPanelCancelado.Update();
                updPanelRechazada.Update();
                updPanelAprobado.Update();
                updPanelSolSinRevision.Update();
                ObtenerSolicitudesContratoxUsuarioxEstado();
            }
            else if (Session["id_perfil"].ToString() == "2")
            {

                updPanelPendientePago.Update();
                updPanelRevision.Update();
                updPanelCancelado.Update();
                updPanelRechazada.Update();
                updPanelAprobado.Update();
                updPanelSolSinRevision.Update();
                ObtenerSolicitudesContratoxEstado();
            }
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("SolicitudesPlan", "Error = " + ex.Message + "Stac" + ex.StackTrace);

        }
    }

    protected void gvSolAprobados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ver")
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvSolAprobados.DataKeys[index].Values;
                string id = colsNoVisible[0].ToString();
                string Descripcion = colsNoVisible[1].ToString();

                txtDescripcionModal.Text = Descripcion;
                tituloModal.InnerText = "Descripción de solicitud " + id;


                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#defaultmodal').modal('show');</script>", false);

            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("SolicitudesPlan", "Error = " + ex.Message + "Stac" + ex.StackTrace);

            }

        }
    }

    protected void gvSolPagadoSinRevision_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Ver")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvSolPagadoSinRevision.DataKeys[index].Values;
                string id = colsNoVisible[0].ToString();
                string Descripcion = colsNoVisible[1].ToString();

                txtDescripcionModal.Text = Descripcion;
                tituloModal.InnerText = "Descripción de solicitud " + id;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#defaultmodal').modal('show');</script>", false);
            }
            else if (e.CommandName == "Cancelar")
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    var colsNoVisible = gvSolPagadoSinRevision.DataKeys[index].Values;
                    string id = colsNoVisible[0].ToString();
                    hfContentIDSol.Value = id;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#confirmacionmodal').modal('show');</script>", false);
                }
                catch (Exception ex)
                {
                    _log.CustomWriteOnLog("SolicitudesPlan", "Error = " + ex.Message + "Stac" + ex.StackTrace);
                }

            }
            else if (e.CommandName == "Rechazar")
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    var colsNoVisible = gvSolPagadoSinRevision.DataKeys[index].Values;
                    string id = colsNoVisible[0].ToString();
                    hfContentIDSol.Value = id;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#RechazarModal').modal('show');</script>", false);

                }
                catch (Exception ex)
                {
                    _log.CustomWriteOnLog("SolicitudesPlan", "Error = " + ex.Message + "Stac" + ex.StackTrace);
                }
            }
            else if (e.CommandName == "VerPago")
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    var colsNoVisible = gvSolPagadoSinRevision.DataKeys[index].Values;
                    string id = colsNoVisible[0].ToString();
                            _log.CustomWriteOnLog("SolicitudesPlan", "Id de imagen de pago +" +id);
                    hfContentIDSol.Value = id;

                    string cs = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand("SP_GetImageById", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter paramId = new SqlParameter()
                        {
                            ParameterName = "@Id",
                            Value = id
                        };
                        cmd.Parameters.Add(paramId);
                        con.Open();
                        byte[] ByteArray;
                        if (cmd.ExecuteScalar() != DBNull.Value)
                        {
                            ByteArray = (byte[])cmd.ExecuteScalar();
                            con.Close();
                            string strbase64 = Convert.ToBase64String(ByteArray);
                            Image1.ImageUrl = "data:Image/png;base64," + strbase64;
                            Image1.Visible = true;
                        }
                        else
                        {
                            con.Close();
                            Image1.Visible = false;
                            _log.CustomWriteOnLog("SolicitudesPlan", "No hay imagen aún");
                        }
                    }
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#modalImagenPago').modal('show');</script>", false);
                }
                catch (Exception ex)
                {
                    _log.CustomWriteOnLog("SolicitudesPlan", "Error = " + ex.Message + "Stac" + ex.StackTrace);
                }
            }
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("SolicitudesPlan", "Error = " + ex.Message + "Stac" + ex.StackTrace);
        }
    }

    protected void gvSolPagadoSinRevision_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (Session["id_perfil"].ToString() == "1")
        {
            //e.Row.Cells[11].Visible = false;
        }
        else if (Session["id_perfil"].ToString() == "2")
        {
            //e.Row.Cells[10].Visible = false;
        }
    }

    protected void btnaceptarAprobarRegistro_Click(object sender, EventArgs e)
    {
        try
        {
            CtrContrato objCtrContrato = new CtrContrato();
            string valorHF = hfContentIDSol.Value;
            objDtoContrato.PK_IC_Cod = int.Parse(valorHF);
            objDtoContrato.FK_IEC_Cod = 2;
            objCtrContrato.ActualizarContrato(objDtoContrato);
            Utils.AddScriptClientUpdatePanel(udpPanelAprobarSolicitud, "mostrarMensajeConfirmacionMandarSinPago();");
            if (Session["id_perfil"].ToString() == "1")
            {
                updPanelPendientePago.Update();
                updPanelRevision.Update();
                updPanelCancelado.Update();
                updPanelRechazada.Update();
                updPanelAprobado.Update();
                updPanelSolSinRevision.Update();
                ObtenerSolicitudesContratoxUsuarioxEstado();
            }
            else if (Session["id_perfil"].ToString() == "2")
            {

                updPanelPendientePago.Update();
                updPanelRevision.Update();
                updPanelCancelado.Update();
                updPanelRechazada.Update();
                updPanelAprobado.Update();
                updPanelSolSinRevision.Update();
                ObtenerSolicitudesContratoxEstado();
            }
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("SolicitudesPlan", "Error = " + ex.Message + "Stac" + ex.StackTrace);

        }
    }

    protected void btnAprobarPago_Click(object sender, EventArgs e)
    {
        try
        {
            CtrContrato objCtrContrato = new CtrContrato();
            string valorHF = hfContentIDSol.Value;
            objDtoContrato.PK_IC_Cod = int.Parse(valorHF);
            objDtoContrato.FK_IEC_Cod = 3;
            objCtrContrato.ActualizarContrato(objDtoContrato);
            Utils.AddScriptClientUpdatePanel(udpPanelAprobarSolicitud, "mostrarMensajepagada();");
            if (Session["id_perfil"].ToString() == "1")
            {
                updPanelPendientePago.Update();
                updPanelRevision.Update();
                updPanelCancelado.Update();
                updPanelRechazada.Update();
                updPanelAprobado.Update();
                updPanelSolSinRevision.Update();
                ObtenerSolicitudesContratoxUsuarioxEstado();
            }
            else if (Session["id_perfil"].ToString() == "2")
            {

                updPanelPendientePago.Update();
                updPanelRevision.Update();
                updPanelCancelado.Update();
                updPanelRechazada.Update();
                updPanelAprobado.Update();
                updPanelSolSinRevision.Update();
                ObtenerSolicitudesContratoxEstado();
            }
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("SolicitudesPlan", "Error = " + ex.Message + "Stac" + ex.StackTrace);
        }
    }

    protected void btnGuardarPago_Click(object sender, EventArgs e)
    {
        try
        {
            CtrContrato objCtrContrato = new CtrContrato();
            string valorHF = hfContentIDSol.Value;
            objDtoContrato.PK_IC_Cod = int.Parse(valorHF);
            objDtoContrato.FK_IEC_Cod = 8;
            objCtrContrato.ActualizarContrato(objDtoContrato);

            Utils.AddScriptClientUpdatePanel(UpdatePanel7, "uploadFileDocuments(" + valorHF + ");");
            if (Session["id_perfil"].ToString() == "1")
            {
                updPanelPendientePago.Update();
                updPanelRevision.Update();
                updPanelCancelado.Update();
                updPanelRechazada.Update();
                updPanelAprobado.Update();
                updPanelSolSinRevision.Update();
                ObtenerSolicitudesContratoxUsuarioxEstado();
            }
            else if (Session["id_perfil"].ToString() == "2")
            {

                updPanelPendientePago.Update();
                updPanelRevision.Update();
                updPanelCancelado.Update();
                updPanelRechazada.Update();
                updPanelAprobado.Update();
                updPanelSolSinRevision.Update();
                ObtenerSolicitudesContratoxEstado();
            }
            Utils.AddScriptClientUpdatePanel(UpdatePanel7, "mostrarMensajRegistrarpago()");
        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("SolicitudesPlan", "Error = " + ex.Message + "Stac" + ex.StackTrace);
        }
    }
}