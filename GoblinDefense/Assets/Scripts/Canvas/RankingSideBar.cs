using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using System.Text;
//using NUnit.Framework;
using UnityEngine.UI;

public class RankingSideBar : MonoBehaviour
{
    private SqlConnectionStringBuilder builder;
    private SqlDataReader reader;


    // SQL read refresh time
    private float nextActionTime;
    private float period;
    
    // SQL query builder
    private StringBuilder sb;
    private string sql;
    
    // Child component of score board.
    private Text rank;


    private void Start()
    {
        // Setting the sql update time. (Evert 30 seconds)
        nextActionTime = 0.0f;
        period = 30f;

        // Database connection setting
        builder = new SqlConnectionStringBuilder();
        builder.DataSource = "foobarcss385.database.windows.net";
        builder.UserID = "kharam";
        builder.Password = "css385_db";
        builder.InitialCatalog = "css385_scoreboard";
        
        // Database query setting
        sb = new StringBuilder();
        sb.Append("SELECT TOP 3 name, score ");
        sb.Append("FROM SCOREBOARD ");
        sb.Append("ORDER BY score DESC");
        sql = sb.ToString();

        rank = GetComponentInChildren<Text>();
    }

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;

            try
            {
                SQLUpdate();
            }
            catch (SqlException e)
            {
                Debug.Log("Database error: " + e.ToString());
            }
        }
    }

    private void SQLUpdate()
    {
        string result = "";
        
        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    for (int i=1 ;reader.Read(); ++i)
                    {
                        result += i + ": " + reader.GetString(0) + ", " + reader.GetInt32(1) + "\n";
                    }

                    Debug.Log("Database is working");
                    rank.text = result;
                }
            }
        }
    }
}