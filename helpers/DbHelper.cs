using IBBA.helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public static class DbHelper
{
    //Name of database file in App_Data folder
    public const string DBName = "Database1.mdf"; //Database file name.

    public const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\" + DBName + ";Integrated Security=True";

    //Insert (C)
    public static int SQL_Insert(string sql)
    {
        return SetData(sql);
    }
    //Update(U)
    public static int SQL_Update(string sql)
    {
        return SetData(sql);
    }
    //Delete(D)
    public static int SQL_Delete(string sql)
    {
        return SetData(sql);
    }
    //Select (R)
    public static DataTable SQL_Select(string sql)
    {
        return GetData(sql);
    }

    //Select Count
    public static int SQL_SelectCount(string sql)
    {
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(sql, con);

        con.Open();
        object scalar = cmd.ExecuteScalar();
        con.Close();

        return (int)scalar;
    }
    public static bool SQL_SelectBool(string sql)
    {
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(sql, con);

        con.Open();
        object result = cmd.ExecuteScalar();
        con.Close();

        if (result == null || result == DBNull.Value)
            return false;
        return (bool)result;
    }

    public static string DataTableToString(DataTable dt)
    {

        string str = "<table>";

        //Write header row
        str += "<tr>";
        foreach (DataColumn column in dt.Columns)
            str += "<th>" + column.ColumnName + "</th>";
        str += "</tr>";

        //Write data rows
        foreach (DataRow row in dt.Rows)
        {
            str += "<tr>";

            foreach (DataColumn column in dt.Columns)
                str += "<td>" + row[column] + "</td>";

            str += "</tr>";
        }

        str += "</Table>";
        return str;

    }

    // Gets A data from the database acording to the SELECT Command in sql;
    // Returns DataTable with the Table.
    private static DataTable GetData(string sql)
    {
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        dataAdapter.Fill(ds, "Users");

        return ds.Tables[0];
    }

    private static int SetData(string sql)
    {
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(sql, con);

        con.Open();
        int n = cmd.ExecuteNonQuery();
        con.Close();

        return n;
    }
    public static List<Team> GetTeams()
    {
        var teams = new List<Team>();
        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            var cmd = new SqlCommand("SELECT teamName, city, icon FROM Teams", conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                teams.Add(new Team
                {
                    TeamName = reader["teamName"].ToString(),
                    City = reader["city"].ToString(),
                    Icon = reader["icon"].ToString()
                });
            }
        }
        return teams;
    }



}