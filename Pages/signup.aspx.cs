using System;
using System.Data.SqlClient;

namespace IBBA.Pages
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["currentPage"] = "Signup";
        }


        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            string ffirstName = firstName.Value;
            string llastName = lastName.Value;
            string eemail = email.Value;
            string ppassword = password.Value;
            string cconfirmPassword = confirmPassword.Value;
            string bbirth = birth.Value;
            string ggender = Request.Form["gender"];
            string ttz = tz.Value;
            bool iisPlayer = showtz.Visible;

            if (ppassword != cconfirmPassword)
            {
                divPassError.InnerHtml = "הסיסמאות לא תואמות";
                return;
            }
            int count = DbHelper.SQL_SelectCount($"SELECT COUNT(*) FROM users WHERE Email = '{eemail}'");
            if (count > 0)
            {
                divError.InnerHtml = "Account already exists";
                return;
            }

            //Add the new user to the database
            DbHelper.SQL_Insert($@"
INSERT INTO users 
(Email, Password, firstName, lastName, birth, gender, tz, isPlayer) 
VALUES (
    '{eemail}', 
    '{ppassword}', 
    N'{ffirstName}', 
    N'{llastName}', 
    '{bbirth}', 
    N'{ggender}', 
    '{ttz}', 
    N'{iisPlayer}'
)");


            Response.Redirect("login.aspx");
        }
    }
}
