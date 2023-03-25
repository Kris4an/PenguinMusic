using PenguinMusic.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PenguinMusic.Data
{
    class CityData
    {
        public List<Cities> GetCities()
        {
            List<Cities> cities = new List<Cities>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM Cities Order by Country, CIty_Name", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var city = new Cities(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2)
                        );

                        cities.Add(city);
                    }

                }
                connection.Close();
            }
            return cities;
        }
        public Cities GetCity(int id)
        {
            using (var connection = Database.GetConnection())
            {
                Cities city = null;
                var command = new SqlCommand($"SELECT * FROM Cities WHERE City_Id={id}", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        city = new Cities(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2)
                        );
                        break;
                    }
                    connection.Close();
                }
                return city;
            }
        }
        public void Add(string city, string country)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("INSERT INTO Cities (CIty_Name, Country) VALUES(@city, @country)", connection);
                command.Parameters.AddWithValue("city", city);
                command.Parameters.AddWithValue("country", country);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
