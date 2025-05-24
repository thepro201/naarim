<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mas.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="IBBA.Pages.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>נערים א' מחוזית מרכז</title>
    <link rel="stylesheet"href="../css/home.css"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero">
        <div>
            <h1>נערים א' מחוזית מרכז</h1>
            <p>.הליגה הטובה בארץ</p>
        </div>
    </div>

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
                    <th>הפרש</th>
                    <th>נצחונות %</th>
                </tr>
            </thead>

            <tbody id="standingsBody" runat="server"></tbody>
        </table>

    </section>
</asp:Content>
