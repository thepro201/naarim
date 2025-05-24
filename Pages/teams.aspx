<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mas.Master" AutoEventWireup="true" CodeBehind="teams.aspx.cs" Inherits="IBBA.Pages.teams" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>קבוצות</title>
    <link rel="stylesheet"href="../css/teams.css"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="page-title">הקבוצות</h1>

<div class="teams-container" id="teams-container">
</div>
<script>
    var teams = <%= TeamsJson %>;
    </script>
<script src="../js/teams.js"></script>

</asp:Content>
