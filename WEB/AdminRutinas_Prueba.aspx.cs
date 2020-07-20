using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class AdminRutinas_Prueba : System.Web.UI.Page
{
    string connectionString = @"Data Source=LAPTOP-UEI1JFVM;Integrated Security=true;Initial Catalog=BD_SCLAP";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateGridview();
        }
    }

    void PopulateGridview()
    {
        DataTable dtbl = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM T_Rutinas", sqlCon);
            sqlDa.Fill(dtbl);
        }
        if (dtbl.Rows.Count > 0)
        {
            gvRuti.DataSource = dtbl;
            gvRuti.DataBind();
        }
        else
        {
            dtbl.Rows.Add(dtbl.NewRow());
            gvRuti.DataSource = dtbl;
            gvRuti.DataBind();
            gvRuti.Rows[0].Cells.Clear();
            gvRuti.Rows[0].Cells.Add(new TableCell());
            gvRuti.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
            gvRuti.Rows[0].Cells[0].Text = "No Data Found ..!";
            gvRuti.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        }

    }

    protected void gvRuti_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("AddNew"))
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "INSERT INTO T_Rutinas (DR_Fecha,DR_Descripcion,DR_Duracion,DR_Repeticion) VALUES (@DR_Fecha,@DR_Descripcion,@DR_Duracion,@DR_Repeticion)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@DR_Fecha", (gvRuti.FooterRow.FindControl("txtDR_FechaFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@DR_Descripcion", (gvRuti.FooterRow.FindControl("txtDR_DescripcionFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@DR_Duracion", (gvRuti.FooterRow.FindControl("txtDR_DuracionFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@DR_Repeticion", (gvRuti.FooterRow.FindControl("txtDR_RepeticionFooter") as TextBox).Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridview();
                    lblSuccessMessage.Text = "New Record Added";
                    lblErrorMessage.Text = "";
                }
            }
        }
        catch (Exception ex)
        {
            lblSuccessMessage.Text = "";
            lblErrorMessage.Text = ex.Message;
        }
    }

    protected void gvRuti_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvRuti.EditIndex = e.NewEditIndex;
        PopulateGridview();
    }

    protected void gvRuti_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvRuti.EditIndex = -1;
        PopulateGridview();
    }

    protected void gvRuti_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE T_Rutinas SET DR_Fecha=@DR_Fecha,DR_Descripcion=@DR_Descripcion,DR_Duracion=@DR_Duracion,DR_Repeticion=@DR_Repeticion WHERE PK_IR_Rutinas = @id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@DR_Fecha", (gvRuti.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@DR_Descripcion", (gvRuti.Rows[e.RowIndex].FindControl("txtLastName") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@DR_Duracion", (gvRuti.Rows[e.RowIndex].FindControl("txtContact") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@DR_Duracion", (gvRuti.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvRuti.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
                gvRuti.EditIndex = -1;
                PopulateGridview();
                lblSuccessMessage.Text = "Selected Record Updated";
                lblErrorMessage.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblSuccessMessage.Text = "";
            lblErrorMessage.Text = ex.Message;
        }
    }

    protected void gvRuti_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM T_Rutinas WHERE PK_IR_Rutinas = @id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvRuti.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
                PopulateGridview();
                lblSuccessMessage.Text = "Selected Record Deleted";
                lblErrorMessage.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblSuccessMessage.Text = "";
            lblErrorMessage.Text = ex.Message;
        }
    }
}