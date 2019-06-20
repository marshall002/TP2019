using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using CTR;

public partial class AdministrarRutina_Extra : System.Web.UI.Page
{
    string connectionString = @"Data Source=LAPTOP-TG82GILV;Integrated Security=true;Initial Catalog=BD_SCLAP";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Log.WriteLog("Page");
            PopulateGridview();
            DateTime fecha = Convert.ToDateTime(Session["Primerdia"].ToString());
            string today = System.DateTime.Now.ToShortDateString();

            string tipoR = Session["Tipo_Rutina"].ToString();
            
            string f = fecha.ToString("yyyy/MM/dd");
            obtener_Rutina_Fecha(f, tipoR, today);
        }
    }
    void PopulateGridview()
    {

        DataTable dtbl = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            DateTime FechaSel = Convert.ToDateTime(Session["PrimerDia"]);
            string fecha = FechaSel.ToString("yyyy-MM-dd'T'HH':'mm':'ss");
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM T_Rutina where DR_FechaRutina = '"+ fecha + "' and FK_ITR_Cod= "+ Session["Tipo_Rutina"].ToString(), sqlCon);
            sqlDa.Fill(dtbl);
        }
        if (dtbl.Rows.Count > 0)
        {

            gvRutina.DataSource = dtbl;
            gvRutina.DataBind();
        }
        else
        {
            dtbl.Rows.Add(dtbl.NewRow());
            gvRutina.DataSource = dtbl;
            gvRutina.DataBind();
            gvRutina.Rows[0].Cells.Clear();
            gvRutina.Rows[0].Cells.Add(new TableCell());
            gvRutina.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
            gvRutina.Rows[0].Cells[0].Text = "No Data Found ..!";


            gvRutina.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        }
        Log.WriteLog("ingreso a popular el gridview");
    }

    public int validarTipo()
    {
        if ((gvRutina.FooterRow.FindControl("txtFK_ITR_CodFooter") as TextBox).Text.Trim().Equals("Crossfit"))
        {
            return 1;
        }
        else
            return 2;
    }

    protected void gvRutina_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("AddNew"))
            {
                Log.WriteLog("entro a funcion add new");
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "INSERT INTO T_Rutina (DR_FechaRutina,DR_FechaRegistro,VR_DescripcionE,FK_ITR_Cod,VR_Duracion,IR_Repeticion) VALUES (@Fecharutina,GETDATE(),@descripcion,@fkitrcod,@duracion,@repetic)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Fecharutina", DateTime.Parse((gvRutina.FooterRow.FindControl("txtfechaRutinaFooter") as TextBox).Text.Trim()));
                    sqlCmd.Parameters.AddWithValue("@descripcion", (gvRutina.FooterRow.FindControl("txtdescripcionFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@fkitrcod", (gvRutina.FooterRow.FindControl("txtFK_ITR_CodFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@duracion", (gvRutina.FooterRow.FindControl("txtduracionFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@repetic", (gvRutina.FooterRow.FindControl("txtrepeticionFooter") as TextBox).Text.Trim());

                    sqlCmd.ExecuteNonQuery();
                    PopulateGridview();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + "Registro exitoso" + "', 'bottom', 'center', null, null);", true);
                    //lblSuccessMessage.Text = "Registro de rutina con exito.";
                    //var textbox = gvRutina.FindControl("txtFK_ITR_CodFooter");
                    lblErrorMessage.Text = "";
                    UPGridview.Update();
                }
            }
        }
        catch (Exception ex)
        {
            lblSuccessMessage.Text = "";
            lblErrorMessage.Text = ex.Message;
            Log.WriteLog("error en add new: " + ex.Message);
        }
    }

    protected void gvRutina_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvRutina.EditIndex = e.NewEditIndex;
        PopulateGridview();
        UPGridview.Update();

    }

    protected void gvRutina_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvRutina.EditIndex = -1;
        PopulateGridview();
        UPGridview.Update();
    }

    protected void gvRutina_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Log.WriteLog("entro a funcion Actualizar");
        try
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE T_Rutina SET DR_FechaRutina=@Fecharutina,VR_DescripcionE=@descripcion,FK_ITR_Cod=@fkitrcod,VR_Duracion=@duracion,IR_Repeticion=@repetic WHERE PK_IR_Cod = @id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Fecharutina", DateTime.Parse((gvRutina.Rows[e.RowIndex].FindControl("txtfechaRutina") as TextBox).Text.Trim()));
                sqlCmd.Parameters.AddWithValue("@descripcion", (gvRutina.Rows[e.RowIndex].FindControl("txtdescripcion") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@fkitrcod", (gvRutina.Rows[e.RowIndex].FindControl("txtFK_ITR_Cod") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@duracion", (gvRutina.Rows[e.RowIndex].FindControl("txtduracion") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@repetic", (gvRutina.Rows[e.RowIndex].FindControl("txtrepeticion") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvRutina.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
                gvRutina.EditIndex = -1;
                UPGridview.Update();
                PopulateGridview();
                UPGridview.Update();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + "Actualizacion exitosa" + "', 'bottom', 'center', null, null);", true);
                //lblSuccessMessage.Text = "Rutina Actualizada con exito.";
                lblErrorMessage.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblSuccessMessage.Text = "";
            Log.WriteLog("Error en el actualizar : " + ex.Message);
        }
    }

    protected void gvRutina_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Log.WriteLog("entro a funcion eliminar");
        try
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = "DELETE FROM T_Rutina WHERE PK_IR_Cod = @id";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvRutina.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
                PopulateGridview();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-green', '" + "Rutina eliminada" + "', 'bottom', 'center', null, null);", true);
                //lblSuccessMessage.Text = "Rutina eliminada con exito";
                lblErrorMessage.Text = "";
                UPGridview.Update();
                

            }
        }
        catch (Exception ex)
        {
            lblSuccessMessage.Text = "";
            Log.WriteLog("Error al borrar" + ex.Message);
        }
    }


    public void obtener_Rutina_Fecha(string a, string b, string c)
    {
        txt.Text = a;
        txt2.Text = b;
        txt3.Text = c;

    }
    protected void Unnamed_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdministrarRutina.aspx");
    }
}