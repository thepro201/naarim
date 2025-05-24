<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mas.Master" AutoEventWireup="true" CodeBehind="Standings.aspx.cs" Inherits="IBBA.Pages.Standings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>טבלה</title>
    <link rel="stylesheet"href="../css/standings.css"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

<section class="standings">
  <h2>טבלה</h2>
  <table class="standings-table">
    <thead>
      <tr>
        <th></th>
        <th>קבוצה</th>
        <th>משחקים</th>
        <th>נצחונות</th>
        <th>הפסדים</th>
        <th>קלעה</th>
        <th>ספגה</th>
        <th>הפרש</th>
        <th>נצחונות %</th>
        <th>סהכ נקודות</th>
      </tr>
    </thead>
    <tbody id="standingsBody" runat="server"></tbody>

  </table>
</section>
</asp:Content>
