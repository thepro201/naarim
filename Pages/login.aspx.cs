using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IBBA.Pages
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["currentPage"] = "Login";
        }

        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            string emaill = email.Value;
            string password = passwordd.Value;

            int count = DbHelper.SQL_SelectCount($"SELECT COUNT(*) FROM users WHERE Email = '{emaill}' AND Password = '{password}'");

            if (count == 0)
            {
                divError.InnerHtml = "שם משתמש או סיסמה לא נכונים";
                return;
            }
            DataTable dt = DbHelper.SQL_Select($"SELECT firstName FROM Users WHERE Email = '{emaill}'");
            DataTable dtt = DbHelper.SQL_Select($"SELECT tz FROM Users WHERE Email = '{emaill}'");
            string name = dt.Rows[0]["firstName"].ToString();
            string tz = dtt.Rows[0]["tz"].ToString();
            Session["isLogin"] = true;
            Session["currentUser"] = emaill;

            Session["Name"] = name;
            // Get isAdmin data
            string sql = $"SELECT isPlayer FROM Users WHERE Email = '{emaill}'";
            bool isPlayer = DbHelper.SQL_SelectBool(sql);

            Session["isPlayer"] = isPlayer;
            string sqll = $"SELECT isAdmin FROM Users WHERE UserName = '{emaill}'";
            bool isAdmin = DbHelper.SQL_SelectBool(sql);

            Session["isAdmin"] = isAdmin;
            if (isPlayer)
            {
                Session["tz"] = tz;
                Response.Redirect("Player.aspx");
            }
            else
            {
                Response.Redirect("Home.aspx");
            }

        }

    }
}