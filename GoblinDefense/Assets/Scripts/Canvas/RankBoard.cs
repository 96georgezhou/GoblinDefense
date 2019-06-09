using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Data.SqlClient;
using System.Text;
using TMPro;
using UnityEngine.UI;

public class RankBoard : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI rank;

    // Use this for initialization
    void Start()
    {
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
                sb.Append("SELECT TOP 16 name, score ");
                sb.Append("FROM SCOREBOARD ");
                sb.Append("ORDER BY score DESC");
                
                string sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        for (int i = 1; reader.Read(); ++i)
                        {
                            var _rank = Instantiate(rank);
//                            _rank.GetComponent<TextMeshPro>().SetText(reader.GetString(0) + ", " + reader.GetInt32(1));
                            _rank.transform.parent = transform;
                            _rank.text = i + " id: "+ reader.GetString(0) + " score: " + reader.GetInt32(1);
//                            Debug.Log(reader.GetString(0) + ", " + reader.GetInt32(1));

                        }
                    }
                }
            }
        }
        catch (SqlException e)
        {
            Debug.Log("SQL error occureed");
        }
    }
}