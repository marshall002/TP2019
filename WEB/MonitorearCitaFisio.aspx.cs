using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;


public partial class MonitorearCitaFisio : System.Web.UI.Page
{
    CtrMonitoriarCitaFisio ct = new CtrMonitoriarCitaFisio();
    protected void Page_Load(object sender, EventArgs e)
    {
        gvListaMoniCitaFisio.DataSource = ct.VMonitoriarCitaFisio();
        gvListaMoniCitaFisio.DataBind();
    }
}