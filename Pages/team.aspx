<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mas.Master" AutoEventWireup="true" CodeBehind="team.aspx.cs" Inherits="IBBA.Pages.team" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>פרטי קבוצה</title>
    <link rel="stylesheet" href="../css/team.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="team-content">
        <div class="team-header">
            <div class="container">
                <a href="teams.aspx" class="back-button">← חזרה לקבוצות</a>
                <div class="team-header-content">
                    <img id="teamlogo" runat="server" class="team-logo-xl" />
                    <div class="team-info">
                        <h1><span id="teamname" runat="server" /></h1>
                        <p><span id="teamcity" runat="server" /></p>
                        <p><span id="teamcoach" runat="server" /></p>
                    </div>
                </div>
            </div>

            <div class="team-details">
                <div class="stats-card">
                    <h2>סטטיסטיקות העונה</h2>
                    <div class="stats-grid">
                        <div class="stat-item">
                            <div class="stat-value"><span id="played" runat="server" /></div>
                            <div class="stat-label">משחקים</div>
                        </div>
                        <div class="stat-item">
                            <div class="stat-value"><span id="won" runat="server" /></div>
                            <div class="stat-label">נצחונות</div>
                        </div>
                        <div class="stat-item">
                            <div class="stat-value"><span id="lost" runat="server" /></div>
                            <div class="stat-label">הפסדים</div>
                        </div>
                        <div class="stat-item">
                            <div class="stat-value"><span id="winrate" runat="server" /></div>
                            <div class="stat-label">% נצחונות</div>
                        </div>
                    </div>
                </div>
                <div class="stats-card">
                    <h2>דירוג</h2>
                    <div class="stats-grid">
                        <div class="stat-item">
                            <div class="stat-value"><span id="rank" runat="server" /></div>
                            <div class="stat-label">מקום</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
