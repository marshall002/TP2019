using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;

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
                _log.CustomWriteOnLog("SolicitudesPlan", "ERROR EN PAGE LOAD " + ex.Message);
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
                tituloModal.InnerText ="Descripción de solicitud "+ id;

               
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#defaultmodal').modal('show');</script>", false);

            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("SolicitudesPlan", "Error = " + ex.Message + "Stac" + ex.StackTrace);

            }

        }
        else if (e.CommandName == "Cancelar")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var colsNoVisible = gvSolRevision.DataKeys[index].Values;
            string id = colsNoVisible[0].ToString();
            hfContentIDSol.Value = id;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#confirmacionmodal').modal('show');</script>", false);

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
}