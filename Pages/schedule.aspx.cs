using IBBA.helpers;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace IBBA.Pages
{
    public partial class schedule : Page
    {
        public List<Team> TeamsList { get; set; }
        public List<Game> GamesList { get; set; }

        public string RoundOptionsHtml { get; set; }
        public string TeamsOptionsHtml { get; set; }
        public string GamesJson { get; set; }
        public string TeamsJson { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TeamsList = DbHelper.GetTeams();

                GamesList = GenerateSchedule(TeamsList);

                RoundOptionsHtml = "";
                for (int i = 1; i <= 22; i++)
                {
                    RoundOptionsHtml += $"<option value='Round {i}'>מחזור {i}</option>";
                }
                TeamsOptionsHtml = "";
                foreach (var team in TeamsList)
                {
                    TeamsOptionsHtml += $"<option value='{team.TeamName}'>{team.TeamName}</option>";
                }

                var serializer = new JavaScriptSerializer();
                GamesJson = serializer.Serialize(GamesList);
                TeamsJson = serializer.Serialize(TeamsList);
            }
        }

        private List<Game> GenerateSchedule(List<Team> teams)
        {
            var games = new List<Game>();
            int numTeams = teams.Count;

            bool addedDummy = false;
            if (numTeams % 2 != 0)
            {
                teams.Add(new Team { Id = -1, TeamName = "Bye", City = "None", Icon = "default" });
                numTeams++;
                addedDummy = true;
            }

            int totalRounds = (numTeams - 1) * 2;
            int gamesPerRound = numTeams / 2;

            List<Team> rotation = new List<Team>(teams);
            Team fixedTeam = rotation[0];
            rotation.RemoveAt(0);

            DateTime seasonStart = new DateTime(2024, 9, 1);
            DateTime seasonEnd = new DateTime(2025, 5, 31);
            int totalDays = (seasonEnd - seasonStart).Days;

            int totalGames = totalRounds * gamesPerRound;

            double daysBetweenGames = (double)totalDays / totalGames;

            DateTime currentGameDate = seasonStart;
            TimeSpan dayStartTime = new TimeSpan(18, 0, 0);
            TimeSpan interval = TimeSpan.FromMinutes(45);
            int gamesToday = 0;
            int maxGamesPerDay = 1;

            for (int round = 0; round < totalRounds; round++)
            {
                for (int i = 0; i < gamesPerRound; i++)
                {
                    Team home, away;

                    if (i == 0)
                    {
                        home = (round % 2 == 0) ? fixedTeam : rotation[rotation.Count - 1];
                        away = (round % 2 == 0) ? rotation[rotation.Count - 1] : fixedTeam;
                    }
                    else
                    {
                        Team t1 = rotation[i - 1];
                        Team t2 = rotation[rotation.Count - i];

                        home = (round % 2 == 0) ? t1 : t2;
                        away = (round % 2 == 0) ? t2 : t1;
                    }

                    if (home.Id == -1 || away.Id == -1)
                        continue;

                    if (gamesToday >= maxGamesPerDay)
                    {
                        currentGameDate = currentGameDate.AddDays(daysBetweenGames);
                        gamesToday = 0;
                    }

                    DateTime gameDateTime = currentGameDate.Date + dayStartTime + TimeSpan.FromMinutes(gamesToday * interval.TotalMinutes);

                    games.Add(new Game
                    {
                        HomeTeam = home,
                        AwayTeam = away,
                        Date = gameDateTime.ToString("yyyy-MM-ddTHH:mm:ss"),
                        Venue = home.City
                    });

                    gamesToday++;
                }
                rotation.Insert(0, rotation[rotation.Count - 1]);
                rotation.RemoveAt(rotation.Count - 1);
            }

            if (addedDummy)
                teams.RemoveAt(teams.Count - 1);

            return games;
        }


    }
}
