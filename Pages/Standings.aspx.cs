using System;
using System.Data;

namespace IBBA.Pages
{
    public partial class Standings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTeamsTable();
            }
        }

        private void LoadTeamsTable()
        {
            DataTable dt = DbHelper.SQL_Select(@"
                SELECT *, (points - gotPoints) AS diff
                FROM Teams
                ORDER BY wins DESC, (points - gotPoints) DESC
            ");

            string html = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                string teamName = row["teamName"].ToString();
                int games = Convert.ToInt32(row["games"]);
                int wins = Convert.ToInt32(row["wins"]);
                int losses = games - wins;
                int pointsScored = Convert.ToInt32(row["points"]);
                int pointsConceded = Convert.ToInt32(row["gotPoints"]);
                int diff = Convert.ToInt32(row["diff"]);
                double winPercent = games > 0 ? ((double)wins / games * 100) : 0;
                string icon = row["icon"].ToString();

                html += $@"
<tr>
    <td>{i + 1}</td>
    <td>
       <a href='team.aspx?id={Uri.EscapeDataString(teamName)}'>
            <img src='../Images/{icon}.png' width='50' height='50' />
        </a>
        <a href='team.aspx?id={Uri.EscapeDataString(teamName)}' class='teamname'>{teamName}</a>
    </td>
    <td>{games}</td>
    <td>{wins}</td>
    <td>{losses}</td>
    <td>{pointsScored}</td>
    <td>{pointsConceded}</td>
    <td>{diff}</td>
    <td>{winPercent:F1}%</td>
    <td>{(wins*2) + losses}</td>
</tr>";
            }

            standingsBody.InnerHtml = html;
        }
    }
}
