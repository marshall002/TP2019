using DTO;
using CTR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VerificarPagoJD : System.Web.UI.Page
{
    CtrCPago ct = new CtrCPago();
    protected void Page_Load(object sender, EventArgs e)
    {
        gvLista.DataSource = ct.VComPago();
        gvLista.DataBind();
    }
}