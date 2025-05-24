<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mas.Master" AutoEventWireup="true" CodeBehind="player-card.aspx.cs" Inherits="IBBA.Pages.player_card" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>כרטיס שחקן</title>
    <link rel="stylesheet" href="../css/player-card.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <a href="players.aspx" class="back-button">← חזרה לשחקנים
  </a>
        <div class="player-hero" runat="server">
            <div class="player-photo" id="playernumber" runat="server"></div>
            <div class="player-info" runat="server">
                <div class="player-number" id="backgroundnumber" runat="server"></div>
                <h1 class="player-name" id="playername" runat="server"></h1>
                <div class="player-meta" id="playermeta" runat="server"></div>
            </div>
        </div>

        <div class="stats-grid" id="statsgrid" runat="server"></div>
    </div>


</asp:Content>
