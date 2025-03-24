using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp1
{
    public partial class PstBack : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                lblMessage.Text = "Page Loaded for the First Time!";
            }
            else
            {
                lblMessage.Text = "Page Reloaded via Postback!";
            }

        }
        protected void btnClick_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "Button Clicked! This is a Postback.";
        }
        protected void ddlOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSelected.Text = "You selected: " + ddlOptions.SelectedItem.Text;
        }
    }
}