using System;

namespace Practical5_AcademicLeave
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.Cookies["StudentID"] != null)
            {
                txtStudentId.Text = Request.Cookies["StudentID"].Value;
                chkRemember.Checked = true;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string studentId = txtStudentId.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (studentId == "ST101" && password == "1234")
            {
                Session["StudentID"] = studentId;
                Session["StudentName"] = "Preet Vora";

                if (chkRemember.Checked)
                {
                    Response.Cookies["StudentID"].Value = studentId;
                    Response.Cookies["StudentID"].Expires = DateTime.Now.AddDays(7);
                }

                Response.Redirect("Home.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid Student ID or Password.";
            }
        }
    }
}