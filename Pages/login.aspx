<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mas.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="IBBA.Pages.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>התחברות</title>
    <link rel="stylesheet"href="../css/login.css"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login-container" >
        <h1 class="login-title">ברוך שובך</h1>
        <form class="login-form" id="form1" runat="server">
        <div class="form1">
            <div class="form-group">
                <label for="email">אימייל</label>
                <input type="email" id="email" runat="server" required placeholder="הכנס את האימייל שלך">
            </div>

            <div class="form-group">
                <label for="password">סיסמה</label>
                <input type="password" id="passwordd" runat="server" required placeholder="הכנס את הסיסמה שלך">
            </div>

            <button class="login-btn" id="btnLogin" runat="server" onserverclick="btnLogin_ServerClick">התחברות</button>
            
            <div id="divError" runat="server" class="errDiv" style="color:red"></div>
            <div class="forgot-password">
                <a href="signup.aspx">?שכחת סיסמה</a>
            </div>

            <div class="register-link">
                אין משתמש? <a href="signup.aspx">הרשמה</a>
            </div>
        </div>
       </form>
    </div>
</asp:Content>
