using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practical4_EventRegistration
{
    public partial class registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void cvSkills_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;

            foreach (ListItem item in cblSkills.Items)
            {
                if (item.Selected)
                {
                    args.IsValid = true;
                    break;
                }
            }
        }

        protected void cvTerms_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = chkTerms.Checked;
        }
    }
}