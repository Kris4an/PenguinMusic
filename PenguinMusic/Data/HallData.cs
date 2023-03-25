using PenguinMusic.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PenguinMusic.Data
{
    class HallData
    {
        public string GetHallName(int id)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand($"SELECT h.Hall_Name, c.CIty_Name FROM Halls h join Cities c on h.City_ID=c.City_ID where h.Halls_ID={id}", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return reader.GetString(0) + ", " + reader.GetString(1);
                    }

                }
                connection.Close();
            }
            return "";
        }
        public List<Halls> GetAllHalls()
        {
            List<Halls> halls = new List<Halls>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM Halls", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var hall = new Halls(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetInt32(2),
                            reader.GetInt32(3)
                        );

                        halls.Add(hall);
                    }

                }
                connection.Close();
            }
            return halls;
        }
        public List<Halls> GetHallsByCity(int id)
        {
            List<Halls> halls = new List<Halls>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand($"SELECT * FROM Halls WHERE City_ID={id}", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var hall = new Halls(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetInt32(2),
                            reader.GetInt32(3)
                        );

                        halls.Add(hall);
                    }

                }
                connection.Close();
            }
            return halls;
        }
        public void Add(string name, int seats, int cityId)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("INSERT INTO Halls (Hall_Name, City_ID, No_Of_Seats) VALUES(@name, @cityId, @seats)", connection);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("cityId", cityId);
                command.Parameters.AddWithValue("seats", seats);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public Halls GetHallById(int id)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand($"SELECT * FROM Halls where Halls_ID={id}", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Halls(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetInt32(2),
                            reader.GetInt32(3)
                        );
                    }

                }
                connection.Close();
            }
            return new Halls();
        }
    }
}
