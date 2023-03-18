using PenguinMusic.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PenguinMusic.Data
{
    class PerformerData
    {
        public string GetPerformerName(int id)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand($"SELECT Performer_Name FROM Performers WHERE Performer_ID={id}", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return reader.GetString(0);
                    }

                }
            }
            return "";
        }
        public List<Performers> GetAllPerformers()
        {
            List<Performers> performers = new List<Performers>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM Performers", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var concert = new Performers(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetInt32(2)
                        );

                        performers.Add(concert);
                    }

                }
                connection.Close();
            }
            return performers;
        }
    }
}
