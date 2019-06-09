using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using System.Data.SqlClient;
using System.Text;

public class ScoreUpload : MonoBehaviour
{

    // Input field from user input.
    [SerializeField] private TextMeshProUGUI nickName;

    private string userInput;


    public void uploadScore()
    {
        if(nickName.text != null)
            if (nickName.text.Length < 2)
            {
                userInput = "Anonymous";
            }
            else
            {
                userInput = nickName.text;
                userInput = userInput.Remove(userInput.Length - 1);
            }


        try
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "foobarcss385.database.windows.net";
            builder.UserID = "kharam";
            builder.Password = "css385_db";
            builder.InitialCatalog = "css385_scoreboard";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO SCOREBOARD(name, score)  ");
                sb.Append("VALUES ( '"+ userInput +"', " + StaticVariable.score + ") ");
                StaticVariable.score = 0;
                string sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (SqlException e)
        {
            Debug.Log("SQL error occureed");
        }
        
        
    }
}
