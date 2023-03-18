using PenguinMusic.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PenguinMusic.Data
{
    class GenreData
    {
        public List<Genres> GetGenres()
        {
            List<Genres> genres = new List<Genres>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM Genres", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var genre = new Genres(
                            reader.GetInt32(0),
                            reader.GetString(1)
                        );

                        genres.Add(genre);
                    }

                }
                connection.Close();
            }
            return genres;
        }
        public string GetGenreById(int id)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand($"SELECT g.Name FROM Genres g where g.Genre_ID={id}", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return reader.GetString(0);
                    }

                }
                connection.Close();
            }
            return "";
        }
    }
    
}
