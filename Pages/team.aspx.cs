using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IBBA.Pages
{
    public partial class team : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string teamName = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(teamName))
                {
                    LoadTeam(teamName);
                }
            }
        }

        private void LoadTeam(string name)
        {
            string sql = $"SELECT * FROM Teams WHERE teamName = N'{name.Replace("'", "''")}'";
            DataTable dt = DbHelper.SQL_Select(sql);

            if (dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];

                teamname.InnerText = row["teamName"].ToString();
                teamcity.InnerText = row["city"].ToString();
                teamcoach.InnerText = row["coach"].ToString();

                teamlogo.Src = $"../Images/{row["icon"]}.png";

                int games = Convert.ToInt32(row["games"]);
                int wins = Convert.ToInt32(row["wins"]);
                int losts = games - wins;
                double winRate = games > 0 ? (wins / (double)games) * 100 : 0;

                played.InnerText = games.ToString();
                won.InnerText = wins.ToString();
                lost.InnerText = losts.ToString();
                winrate.InnerText = $"{winRate:F1}%";

                // לדרוג צריך SELECT עם ORDER BY
                string rankSql = "SELECT teamName FROM Teams ORDER BY wins DESC";
                DataTable rankDt = DbHelper.SQL_Select(rankSql);
                int rankIndex = 1;

                for (int i = 0; i < rankDt.Rows.Count; i++)
                {
                    if (rankDt.Rows[i]["teamName"].ToString() == name)
                    {
                        rankIndex = i + 1;
                        break;
                    }
                }

                rank.InnerText = $"#{rankIndex}";
            }
            else
            {
                teamname.InnerText = "הקבוצה לא נמצאה";
            }
        }



    }
}