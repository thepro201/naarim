<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mas.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="IBBA.Pages.signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>הרשמה</title>
    <link rel="stylesheet" href="../css/signup.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="signup-container">
        <h1 class="signup-title">יצירת משתמש</h1>
        <form class="signup-form" id="signupForm" runat="server">
            <div class="form1">
                <div class="form-row">
                    <div class="form-group">
                        <label for="firstName">שם</label>
                        <input type="text" id="firstName" required placeholder="הכנס את שמך" runat="server">
                    </div>
                    <div class="form-group">
                        <label for="lastName">שם משפחה</label>
                        <input type="text" id="lastName" required placeholder="הכנס את שם המשפחה" runat="server">
                    </div>
                </div>
                <div class="form-group">
                    <label for="email">אימייל</label>
                    <input type="email" id="email" required placeholder="הכנס את האימייל שלך" runat="server">
                </div>
                <div class="form-group">
                    <label for="password">סיסמה</label>
                    <input type="password" id="password" required placeholder="צור סיסמה" runat="server">
                    <div class="password-requirements">
                        הסיסמה חייבת להיות באורך 8 תווים לפחות ולכלול אותיות רישיות, קטנות ומספרים
     
                    </div>
                    <div id="divPassError" runat="server" class="errDiv" style="color:red"></div>
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
                        <label>מין</label>
                        <input type="radio" value="boy" name="gender" required placeholder="בחר מין" runat="server">
                        <label for="boy">זכר</label>
                        <input type="radio" value="girl" name="gender" required placeholder="בחר מין" runat="server">
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
                <button type="submit" runat="server" onserverclick="btnSubmit_ServerClick">צור משתמש</button>
                <div id="divError" runat="server" class="errDiv"></div>
                <div class="terms">
                    על ידי הרשמה, אתה מסכים ל <a href="https://policies.google.com/terms?hl=iw" target="_blank">תנאים והגבלות</a> ו 
     
                    <a href="https://www.isoc.org.il/about/privacy-policy" target="_blank">מדיניות פרטיות</a>
                </div>
            </div>
            <div class="login-link">
                כבר יש משתמש? <a href="login.aspx">התחבר</a>
            </div>
        </form>
    </div>

    <script src="../js/signup.js"></script>
</asp:Content>
