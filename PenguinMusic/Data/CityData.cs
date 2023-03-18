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
                var command = new SqlCommand("SELECT * FROM Cities", connection);
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
    }
}
