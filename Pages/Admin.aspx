<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mas.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="IBBA.Pages.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table {
            border-collapse: collapse;
            width: 100%;
            margin-bottom: 40px;
        }

        th, td {
            border: 1px solid black;
            padding: 8px;
            text-align: center;
        }

        th {
            background-color: #f2f2f2;
        }

        form.inline-form {
            display: flex;
            flex-wrap: wrap;
            gap: 10px;
            margin-bottom: 20px;
        }

            form.inline-form input {
                padding: 5px;
            }

            form.inline-form button {
                padding: 5px 10px;
            }
    </style>
    <link rel="stylesheet" href="../css/home.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Users</h1>
    <table>
        <thead>
            <tr>
                <% foreach (System.Data.DataColumn col in usersTable.Columns)
                    { %>
                <th><%= col.ColumnName %></th>
                <% } %>
                <th>Actions</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (System.Data.DataRow row in usersTable.Rows)
                { %>
            <form method="post" action="?cmd=update&table=Users&id=<%= row["id"] %>">
                <tr>
                    <% foreach (System.Data.DataColumn col in usersTable.Columns)
                        { %>
                    <% if (col.ColumnName.ToLower() == "id")
                        { %>
                    <td><%= row[col] %></td>
                    <% }
                    else
                    { %>
                    <td>
                        <input name="<%= col.ColumnName %>" value="<%= row[col] %>" /></td>
                    <% } %>
                    <% } %>
                    <td>
                        <button type="submit">Update</button>
            </form>
            <form method="post" action="?cmd=delete&table=Users&id=<%= row["id"] %>" style="display: inline;">
                <button type="submit" onclick="return confirm('Are you sure you want to delete this user?');">Delete</button>
            </form>
            </td>
                </tr>
        <% } %>
        </tbody>
    </table>

    <form method="post" action="?cmd=add&table=Users" style="margin-top: 10px;">
        <table>
            <tr>
                <% foreach (System.Data.DataColumn col in usersTable.Columns)
                    { %>
                <% if (col.ColumnName.ToLower() != "id")
                    { %>
                <td>
                    <input name="<%= col.ColumnName %>" placeholder="<%= col.ColumnName %>" /></td>
                <% } %>
                <% } %>
                <td>
                    <button type="submit">Add</button></td>
            </tr>
        </table>
    </form>

    <hr />

    <h1>Teams</h1>
    <table>
        <thead>
            <tr>
                <% foreach (System.Data.DataColumn col in teamsTable.Columns)
                    { %>
                <th><%= col.ColumnName %></th>
                <% } %>
                <th>Actions</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (System.Data.DataRow row in teamsTable.Rows)
                { %>
            <form method="post" action="?cmd=update&table=Teams&id=<%= row["id"] %>">
                <tr>
                    <% foreach (System.Data.DataColumn col in teamsTable.Columns)
                        { %>
                    <% if (col.ColumnName.ToLower() == "id")
                        { %>
                    <td><%= row[col] %></td>
                    <% }
                    else
                    { %>
                    <td>
                        <input name="<%= col.ColumnName %>" value="<%= row[col] %>" /></td>
                    <% } %>
                    <% } %>
                    <td>
                        <button type="submit">Update</button>
            </form>
            <form method="post" action="?cmd=delete&table=Teams&id=<%= row["id"] %>" style="display: inline;">
                <button type="submit" onclick="return confirm('Are you sure you want to delete this team?');">Delete</button>
            </form>
            </td>
                </tr>
        <% } %>
        </tbody>
    </table>

    <form method="post" action="?cmd=add&table=Teams" style="margin-top: 10px;">
        <table>
            <tr>
                <% foreach (System.Data.DataColumn col in teamsTable.Columns)
                    { %>
                <% if (col.ColumnName.ToLower() != "id")
                    { %>
                <td>
                    <input name="<%= col.ColumnName %>" placeholder="<%= col.ColumnName %>" /></td>
                <% } %>
                <% } %>
                <td>
                    <button type="submit">Add</button></td>
            </tr>
        </table>
    </form>

    <hr />

    <h1>Players</h1>
    <table>
        <thead>
            <tr>
                <% foreach (System.Data.DataColumn col in playersTable.Columns)
                    { %>
                <th><%= col.ColumnName %></th>
                <% } %>
                <th>Actions</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (System.Data.DataRow row in playersTable.Rows)
                { %>
            <form method="post" action="?cmd=update&table=Player&id=<%= row["id"] %>">
                <tr>
                    <% foreach (System.Data.DataColumn col in playersTable.Columns)
                        { %>
                    <% if (col.ColumnName.ToLower() == "id")
                        { %>
                    <td><%= row[col] %></td>
                    <% }
                    else
                    { %>
                    <td>
                        <input name="<%= col.ColumnName %>" value="<%= row[col] %>" /></td>
                    <% } %>
                    <% } %>
                    <td>
                        <button type="submit">Update</button>
            </form>
            <form method="post" action="?cmd=delete&table=Player&id=<%= row["id"] %>" style="display: inline;">
                <button type="submit" onclick="return confirm('Are you sure you want to delete this player?');">Delete</button>
            </form>
            </td>
                </tr>
        <% } %>
        </tbody>
    </table>

    <form method="post" action="?cmd=add&table=Player" style="margin-top: 10px;">
        <table>
            <tr>
                <% foreach (System.Data.DataColumn col in playersTable.Columns)
                    { %>
                <% if (col.ColumnName.ToLower() != "id")
                    { %>
                <td>
                    <input name="<%= col.ColumnName %>" placeholder="<%= col.ColumnName %>" /></td>
                <% } %>
                <% } %>
                <td>
                    <button type="submit">Add</button></td>
            </tr>
        </table>
    </form>

</asp:Content>
