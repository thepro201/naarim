using IBBA.helpers;
using System;
using System.Data;

namespace IBBA.Pages
{
    public partial class player_card : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string name = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(name))
                {
                    LoadPlayer(name);
                }
            }
        }

        private void LoadPlayer(string name)
        {
            string sql = $"SELECT * FROM Player WHERE name LIKE N'{name.Replace("'", "''")}'";
            DataTable dt = DbHelper.SQL_Select(sql);

            if (dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];

                playername.InnerText = row["name"].ToString();
                backgroundnumber.InnerText = row["number"].ToString();

                string imgFile = row["img"].ToString();

                playernumber.InnerHtml = $"<img src='../Images/{imgFile}'style='width: 300px; height: 300px; border-radius: 15px;' />";

                playermeta.InnerHtml = $@"
            <div class='meta-item'><span class='meta-label'>קבוצה</span><span class='meta-value'>{row["team"]}</span></div>
            <div class='meta-item'><span class='meta-label'>עמדה</span><span class='meta-value'>{row["position"]}</span></div>";

                statsgrid.InnerHtml = $@"
            <div class='stat-card'><div class='stat-value'>{row["PPG"]}</div><div class='stat-label'>נקודות למשחק</div></div>
            <div class='stat-card'><div class='stat-value'>{row["APG"]}</div><div class='stat-label'>אסיסטים למשחק</div></div>
            <div class='stat-card'><div class='stat-value'>{row["RPG"]}</div><div class='stat-label'>ריבאונדים למשחק</div></div>";
            }
            else
            {
                playername.InnerText = "שחקן לא נמצא";
            }
        }

    }
}


