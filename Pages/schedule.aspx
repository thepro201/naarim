<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mas.Master" AutoEventWireup="true" CodeBehind="schedule.aspx.cs" Inherits="IBBA.Pages.schedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>משחקים</title>
    <link rel="stylesheet" href="../css/schedule.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="page-title">משחקים</h1>

    <div class="filter-section">

        <select class="filter-select" id="team-filter">
            <option value="all">כל הקבוצות</option>
            <%= TeamsOptionsHtml %>
        </select>
        <select class="filter-select" id="month-filter">
            <option value="all">כל החודשים</option>
            <option value="September">ספטמבר 2024</option>
            <option value="October">אוקטובר 2024</option>
            <option value="November">נובמבר 2024</option>
            <option value="December">2024 דצמבר</option>
            <option value="January">ינואר 2025</option>
            <option value="February">פבואר 2025</option>
            <option value="March">מרץ 2025</option>
            <option value="April">אפריל 2025</option>
            <option value="May">מאי 2025</option>
            <option value="June">יוני 2025</option>
            <option value="July">יולי 2025</option>
        </select>
        <select class="filter-select" id="round-filter">
            <option value="all">כל המחזורים</option>
            <%= RoundOptionsHtml %>
        </select>
    </div>

    <div class="schedule-container" id="schedule-container"></div>

    <script type="text/javascript">
        var games = <%= GamesJson %>;
        var teams = <%= TeamsJson %>;
    </script>

    <script src="../js/schedule.js"></script>
</asp:Content>
