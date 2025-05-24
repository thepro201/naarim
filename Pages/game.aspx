<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mas.Master" AutoEventWireup="true" CodeBehind="game.aspx.cs" Inherits="IBBA.Pages.game" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>פרטי משחק</title>
    <link rel="stylesheet" href="../css/game.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="details-container">
  <a href="schedule.aspx" class="back-button">← חזרה למשחקים</a>
  
  <div class="game-header">
    <div class="match-details">
      <div class="team-display">
        <div class="team-logo" id="home-logo"></div>
        <div class="team-name" id="home-team"></div>
      </div>
      
      <div class="score-display">
        <div class="score">
          <span id="home-score">-</span>
          <span class="score-divider">:</span>
          <span id="away-score">-</span>
        </div>
        <div class="game-status" id="game-status"></div>
      </div>

      <div class="team-display">
        <div class="team-logo" id="away-logo"></div>
        <div class="team-name" id="away-team"></div>
      </div>
    </div>

    <div class="datetime" id="datetime"></div>
  </div>

  <div class="game-tabs">
    <div class="tab active">כללי</div>
    <div class="tab">מהלך המשחק</div>
    <div class="tab">סטטיסטיקה</div>
  </div>

  <div class="venue-section">
    <div class="venue-title">אולם:</div>
    <div id="venue" class="venue"></div>
    <div class="map-container" id="map"></div>
  </div>
</div>
    <script src="../js/game.js"></script>

</asp:Content>
