using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IBBA.Pages
{
	public partial class Account : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["currentPage"] = "Account";
                DataTable dt = DbHelper.SQL_Select($"SELECT firstName, lastName, Email, Password, birth, gender, isPlayer, tz FROM Users WHERE Email = '{Session["currentUser"]}'");
                firstName.Value = dt.Rows[0]["firstName"].ToString();
                lastName.Value = dt.Rows[0]["lastName"].ToString();
                email.Value = dt.Rows[0]["Email"].ToString();
                confirmPassword.Value = dt.Rows[0]["Password"].ToString();
                birth.Value = dt.Rows[0]["birth"].ToString();
                if (dt.Rows[0]["gender"].ToString() == "boy")
                {
                    boy.Checked = true;
                    girl.Checked = false;
                }
                else
                {
                    boy.Checked = false;
                    girl.Checked = true;
                }
                player.Checked = Convert.ToBoolean(dt.Rows[0]["isPlayer"]);
                if (Convert.ToBoolean(dt.Rows[0]["isPlayer"]))
                {
                    showtz.Style["display"] = "block";  // להציג את האלמנט
                }
                else
                {
                    showtz.Style["display"] = "none";   // להסתיר את האלמנט
                }
                tz.Value = dt.Rows[0]["tz"].ToString();
            }
            
        }

        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Home.aspx");
        }
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            DataTable dt = DbHelper.SQL_Select($"SELECT Password FROM Users WHERE Email = '{Session["currentUser"]}'");
            string previes = dt.Rows[0]["Password"].ToString();
            bool change = false;
            if (password.Value != "")
            {
                if (lastpass.Value == previes)
                {
                    if (password.Value == confirmPassword.Value)
                    {
                        if (password.Value != lastpass.Value)
                        {
                            change = true;
                        }
                        else
                            divPassError.InnerHtml = "הסיסמה החדשה לא יכולה להיות אותה סיסמה כמו הסיסמה הקודמת";
                    }
                    else
                        divPassError.InnerHtml = "הסיסמה לא תואמת לאישור הסיסמה";
                }
                else
                    divPassError.InnerHtml = "הסיסמה הקודמת לא תואמת";
            }
            string gender = boy.Checked ? "boy" : "girl";
            bool isPlayer = player.Checked;

            string sql = "";
            if (change)
            {
                sql = $@"
UPDATE Users SET 
    firstName = N'{firstName.Value}',
    lastName = N'{lastName.Value}',
    Password = '{password.Value}',
    birth = '{birth.Value}',
    gender = '{gender}',
    isPlayer = '{isPlayer}',
    tz = '{tz.Value}'
WHERE Email = '{email.Value}'";
            }
            else
            {
                sql = $@"
UPDATE Users SET 
    firstName = N'{firstName.Value}',
    lastName = N'{lastName.Value}',
    birth = '{birth.Value}',
    gender = '{gender}',
    isPlayer = '{isPlayer}',
    tz = '{tz.Value}'
WHERE Email = '{email.Value}'";
            }
            DbHelper.SQL_Update(sql);

        }
    }
}