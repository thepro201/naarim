using System;
using System.Data;
using System.Web.Script.Serialization; // הוסף reference לSystem.Web.Extensions אם צריך

namespace IBBA.Pages
{
    public partial class teams : System.Web.UI.Page
    {
        public string TeamsJson { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTeamsFromDb();
            }
        }

        private void LoadTeamsFromDb()
        {
            DataTable dt = DbHelper.SQL_Select("SELECT * FROM Teams ORDER BY teamName");

            var teamsList = new System.Collections.Generic.List<object>();

            foreach (DataRow row in dt.Rows)
            {
                teamsList.Add(new
                {
                    name = row["teamName"].ToString(),
                    played = Convert.ToInt32(row["games"]),
                    won = Convert.ToInt32(row["wins"]),
                    points = Convert.ToInt32(row["points"]),
                    gotp = Convert.ToInt32(row["gotPoints"]),
                    icon = row["icon"].ToString(),
                    city = row["city"] != DBNull.Value ? row["city"].ToString() : "",
                    coach = row["coach"] != DBNull.Value ? row["coach"].ToString() : ""
                });
            }

            var serializer = new JavaScriptSerializer();
            TeamsJson = serializer.Serialize(teamsList);
        }
    }
}
