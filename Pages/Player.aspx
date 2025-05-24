<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mas.Master" AutoEventWireup="true" CodeBehind="Player.aspx.cs" Inherits="IBBA.Pages.Player" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>שחקן</title>
    <link rel="stylesheet" href="../css/player.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="signup-container">
        <h1 class="signup-title">פרטי שחקן</h1>
        <div class="form1">
            <div class="form-row">
                <div class="form-group">
                    <label>שם:</label>
                    <span id="name" runat="server"></span>
                    <br />
                    <label>גיל:</label>
                    <span id="age" runat="server"></span>
                    <br />
                    <label>מספר חולצה:</label>
                    <span id="number" runat="server"></span>
                    <br />
                    <label>עמדה:</label>
                    <span id="position" runat="server"></span>
                    <br />
                    <label>קבוצה:</label>
                    <span id="team" runat="server"></span>
                    <br />
                    <label>מגדר:</label>
                    <span id="gender" runat="server"></span>
                    <br />
                    <label>ת"ז:</label>
                    <span id="tz" runat="server"></span>
                    <br />
                </div>
                <div class="form-group">
                    <img id="imgPlayer" runat="server" width="300" height="300" />
                    <form id="formUpload" runat="server" enctype="multipart/form-data">
                        <input type="file" id="fileUpload" name="fileUpload" />
                        <input type="submit" id="btnUpload" value="שנה תמונה" />
                        <span id="lblMessage" runat="server" style="color: red;"></span>
                    </form>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
