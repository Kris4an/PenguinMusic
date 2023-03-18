using PenguinMusic.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PenguinMusic.Data
{
    class ConcertData
    {
        public List<Concerts> GetAlailableConcerts()
        {
            List<Concerts> concerts = new List<Concerts>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM Concerts WHERE Available='true'", connection);
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
        public List<Concerts> GetConcertsByCity(int id)
        {
            List<Concerts> concerts = new List<Concerts>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand($"select c.* from Concerts c join Performers p on p.Performer_ID=c.Performer_ID join Halls h on h.Halls_ID=c.Hall_ID join Cities cty on cty.City_ID=h.City_ID WHERE c.Available='true' and cty.City_ID={id}", connection);
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
        public List<Concerts> GetConcertsByGenre(int id)
        {
            List<Concerts> concerts = new List<Concerts>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand($"SELECT * FROM Concerts c join Performers p on p.Performer_ID=c.Performer_ID join Genres g on p.Genre_ID=g.Genre_ID where g.Genre_ID={id}", connection);
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
        public List<Concerts> GetAllConcerts()
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
