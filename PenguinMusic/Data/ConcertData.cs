using PenguinMusic.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PenguinMusic.Data
{
    class ConcertData
    {
        public List<Concerts> GetConcerts()
        {
            List<Concerts> concerts = new List<Concerts>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM Concerts", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var concert = new Concerts(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            reader.GetDateTime(3),
                            reader.GetBoolean(4),
                            reader.GetInt32(5)
                        );

                        concerts.Add(concert);
                    }

                }
                connection.Close();
            }
            return concerts;
        }
    }
}
