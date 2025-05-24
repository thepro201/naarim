using System.Data;
using System.Linq;
using System;

namespace IBBA.Pages
{
    public partial class Admin : System.Web.UI.Page
    {
        protected DataTable usersTable, teamsTable, playersTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["isAdmin"] is bool isAdmin) || !isAdmin)
                Response.Redirect("ErrorPage.aspx");

            HandleForm();
            LoadTables();
        }

        void HandleForm()
        {
            string cmd = Request.QueryString["cmd"];
            string table = Request.QueryString["table"];
            string id = Request.QueryString["id"];

            if (string.IsNullOrEmpty(cmd) || string.IsNullOrEmpty(table)) return;

            if (cmd == "update" && !string.IsNullOrEmpty(id))
            {
                string[] cols = Request.Form.AllKeys;
                string setClause = string.Join(", ", cols.Select(key => $"[{key}] = N'{Request.Form[key].Replace("'", "''")}'"));
                DbHelper.SQL_Update($"UPDATE {table} SET {setClause} WHERE id = '{id}'");
            }
            else if (cmd == "delete" && !string.IsNullOrEmpty(id))
            {
                DbHelper.SQL_Delete($"DELETE FROM {table} WHERE id = '{id}'");
            }
            else if (cmd == "add")
            {
                string[] cols = Request.Form.AllKeys;
                string columns = string.Join(", ", cols.Select(key => $"[{key}]"));
                string values = string.Join(", ", cols.Select(key => $"N'{Request.Form[key].Replace("'", "''")}'"));
                DbHelper.SQL_Insert($"INSERT INTO {table} ({columns}) VALUES ({values})");
            }
        }

        void LoadTables()
        {
            usersTable = DbHelper.SQL_Select("SELECT * FROM Users");
            teamsTable = DbHelper.SQL_Select("SELECT * FROM Teams");
            playersTable = DbHelper.SQL_Select("SELECT * FROM Player");
        }
    }
}