using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace WebApp1
{

    public partial class AddRecords : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WebCon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    Response.Write("Page loaded");
            //}
            //else
            //{
            //    Response.Write("Page posted back");
            //}
        }

      

        protected void Add_Records_Click(object sender, EventArgs e)
        {
            string Query = "INSERT INTO details Values(@Name,@Age,@Email)";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@Name", TxtName.Text);
            cmd.Parameters.AddWithValue("@Age", TxtAge.Text);
            cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();

                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Records Enter Successfully')</script>");
                con.Close();
            }
            else
            {
                Response.Write("<script>alert('Connection Failed')</script>");
            }


        }


        protected void View_Records_Click(object sender, EventArgs e)
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
                string Query = "SELECT * FROM details";
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                gvData.DataSource = dt;
               gvData.DataBind();
            }
          
        }
        protected void gvData_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvData.SelectedRow;
            HiddenField_ID.Value = gvData.DataKeys[row.RowIndex].Value.ToString();
            TxtName.Text = row.Cells[2].Text;
            TxtAge.Text = row.Cells[3].Text;
            TxtEmail.Text = row.Cells[4].Text;
        }

        protected void Update_Records_Click(object sender, EventArgs e)
        {
            if(HiddenField_ID.Value != "")
            {
                string Query = "UPDATE details SET name=@Name,age=@Age,email=@Email WHERE id=@ID";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@ID", HiddenField_ID.Value);
                cmd.Parameters.AddWithValue("@Name", TxtName.Text);
                cmd.Parameters.AddWithValue("@Age", TxtAge.Text);
                cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);

                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                    int RowAffected = cmd.ExecuteNonQuery();
                    if (RowAffected > 0)
                    {
                        Response.Write("<script>alert('Records Updated Successfully')</script>");
                        View_Records_Click(null,null);
                        con.Close();
                    }
                    else
                    {
                        Response.Write("<script>alert('Records not Updated')</script>");
                    }

                   
                }
            }
            else
            {
                Response.Write("<script>alert('Please select a record to update')</script>");

            }

        }
        protected void gvData_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            int id = Convert.ToInt32(gvData.DataKeys[e.RowIndex].Value);
            string Query = "delete From details where id = @id";
            SqlCommand cmd = new SqlCommand(Query,con);
            cmd.Parameters.AddWithValue ("@id", id);
            if (con.State == System.Data.ConnectionState.Closed) { 
            con.Open();

            }
            int RowAffected = cmd.ExecuteNonQuery();
            con.Close();
            if (RowAffected > 0) {
                Response.Write("<script>alert('Record Deleted Successfully')</script>");
                View_Records_Click(null, null); 
            }
            else
            {
                Response.Write("<script>alert('Delete Failed')</script>");
            }
        }
    }
}