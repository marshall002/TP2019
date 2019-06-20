using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using CTR;
using DTO;

public partial class ActualizarPagos : System.Web.UI.Page
{
    DtoCPago objDTOCP = new DtoCPago();
    CtrCPago objCTRCP = new CtrCPago();
    //DtoUsuario objDTOU = new DtoUsuario();
    CtrUsuario objCTRU = new CtrUsuario();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            llenarDatos();
        }

    }



    protected void btn_actualizar_Click(object sender, EventArgs e)
    {
        string Sesion = "74931448";
        objDTOCP.VCP_NOperacion = txt_operaciones.Text;
        objDTOCP.DCP_Monto = Double.Parse(txt_monto.Text);
        objDTOCP.ICP_NFisio = Int32.Parse(txt_n_cita_fisio.Text);
        objDTOCP.ICP_NNutri = Int32.Parse(txt_n_cita_nutri.Text);
        objDTOCP.FK_CU_Dni = Int32.Parse(Sesion);
        objCTRCP.ActualizarComprobante_Pago(objDTOCP);
    }
    public void llenarDatos()
    {
        int codP = Convert.ToInt32(Session["idcomp"]);
        objDTOCP= objCTRCP.verComprobanteP(codP);
        txt_monto.Text = objDTOCP.DCP_Monto.ToString();
        txt_operaciones.Text = objDTOCP.VCP_NOperacion.ToString();
        txt_n_cita_fisio.Text = objDTOCP.ICP_NFisio.ToString();
        txt_n_cita_nutri.Text = objDTOCP.ICP_NNutri.ToString();


    }
}