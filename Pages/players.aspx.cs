using System;
using System.Data;
using System.Web.Script.Serialization;

namespace IBBA.Pages
{
    public partial class players : System.Web.UI.Page
    {
        public string PlayersJson { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPlayersFromDb();
            }
        }

        private void LoadPlayersFromDb()
        {
            DataTable dt = DbHelper.SQL_Select("SELECT * FROM Player ORDER BY team, name");

            var playersList = new System.Collections.Generic.List<object>();

            foreach (DataRow row in dt.Rows)
            {
                playersList.Add(new
                {
                    name = row["name"].ToString(),
                    team = row["team"].ToString(),
                    number = Convert.ToInt32(row["number"]),
                    position = row["position"].ToString(),
                    image = row["img"].ToString(),
                    PPG = row["PPG"].ToString(),
                    RPG = row["RPG"].ToString(),
                    APG = row["APG"].ToString()
                });
            }

            var serializer = new JavaScriptSerializer();
            PlayersJson = serializer.Serialize(playersList);
        }
    }
}
