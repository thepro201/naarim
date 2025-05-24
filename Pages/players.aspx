<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mas.Master" AutoEventWireup="true" CodeBehind="players.aspx.cs" Inherits="IBBA.Pages.players" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>שחקנים</title>
    <link rel="stylesheet" href="../css/players.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="page-title">שחקנים</h1>

    <div class="filters">
        <select class="filter-select" id="team-filter">
            <option value="all">כל הקבוצות</option>
        </select>

        <select class="filter-select" id="position-filter">
            <option value="all">כל העמדות</option>
            <option value="רכז">רכז</option>
            <option value="קלעי">קלעי</option>
            <option value="חצי פינה">חצי פינה</option>
            <option value="ציר פינה">ציר פינה</option>
            <option value="גבוה">גבוה</option>
        </select>
    </div>

    <div class="players-container" id="players-container"></div>

    <script>
        var players = <%= PlayersJson %>;
    </script>
    <script src="../js/players.js"></script>
</asp:Content>
