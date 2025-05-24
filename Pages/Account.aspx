<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mas.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="IBBA.Pages.Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>משתמש</title>
    <link rel="stylesheet" href="../css/account.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="signup-container">
        <h1 class="signup-title">ניהול משתמש</h1>
        <form class="signup-form" id="form1" runat="server">
            <div class="form1">
                <div class="form-row">
                    <div class="form-group">
                        <label for="firstName">שם</label>
                        <input runat="server" type="text" id="firstName" required placeholder="הכנס את שמך">
                    </div>
                    <div class="form-group">
                        <label for="lastName">שם משפחה</label>
                        <input runat="server" type="text" id="lastName" required placeholder="הכנס את שם המשפחה">
                    </div>
                </div>
                <div class="form-group">
                    <label for="email">אימייל</label>
                    <input runat="server" type="email" id="email" required placeholder="הכנס את האימייל שלך">
                </div>
                <div class="form-group">
                    <label for="password">סיסמה קודמת</label>
                    <input runat="server" type="password" id="lastpass" required placeholder="סיסמה קודמת">
                    <div id="div1" runat="server" class="errDiv" style="color: red"></div>
                </div>
                <div class="form-group">
                    <label for="password">סיסמה חדשה</label>
                    <input runat="server" type="password" id="password" required placeholder="צור סיסמה">
                    <div class="password-requirements">
                        הסיסמה חייבת להיות באורך 8 תווים לפחות ולכלול אותיות רישיות, קטנות ומספרים
 
                    </div>
                    <div id="divPassError" runat="server" class="errDiv" style="color: red"></div>
                </div>
                <div class="form-group">
                    <label for="confirmPassword">אשר את הסיסמה</label>
                    <input type="password" id="confirmPassword" required placeholder="אשר את הסיסמה" runat="server">
                </div>
                <div class="form-row">
                    <div class="form-group">
                        <label for="birth">תאריך לידה</label>
                        <input type="date" id="birth" required placeholder="בחר תאריך לידה" runat="server">
                    </div>
                    <div class="form-group">
                        <label for="birth">מין</label>
                        <input type="radio" id="boy" name="gender" required placeholder="בחר מין" runat="server">
                        <label for="boy">זכר</label>
                        <input type="radio" id="girl" name="gender" required placeholder="בחר מין" runat="server">
                        <label for="girl">נקבה</label>
                    </div>

                </div>
                <div class="form-group">
                    <input type="checkbox" id="player" name="player" runat="server">
                    <label for="player">שחקן פעיל</label>
                </div>
                <div class="form-group" id="showtz" style="display: none" runat="server">
                    <label for="tz">תעודת זהות</label>
                    <input id="tz" maxlength="9" oninput="limitTzLength(this)" runat="server">
                </div>
                <div id="divError" style="color:red" runat="server" class="errDiv"></div>
                <button id="btnSave" runat="server" onserverclick="btnSave_ServerClick" class="signup-btn">שמור פרטים</button>
            </div>
            <div class="login-link">
                <button id="btnLogin" runat="server" onserverclick="btnLogin_ServerClick" class="signup-btn">התנתק</button>
            </div>
        </form>
    </div>

    <script src="../js/account.js"></script>
</asp:Content>
