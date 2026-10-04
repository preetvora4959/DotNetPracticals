using System;

namespace Practical5_AcademicLeave
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["StudentID"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                lblWelcome.Text = "Welcome, " + Session["StudentName"].ToString()
                    + " (" + Session["StudentID"].ToString() + ")";
            }
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            if (txtReason.Text.Trim() == "")
            {
                lblResult.Text = "Please enter a reason for leave.";
                return;
            }

            string studentId = Session["StudentID"].ToString();
            string leaveType = ddlLeaveType.SelectedValue;
            string date = calLeaveDate.SelectedDate.ToShortDateString();

            Response.Cookies["LastLeaveType"].Value = leaveType;
            Response.Cookies["LastLeaveType"].Expires = DateTime.Now.AddDays(7);

            lblResult.Text = "Leave applied successfully for " + studentId
                + ". Date: " + date
                + ", Type: " + leaveType;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}