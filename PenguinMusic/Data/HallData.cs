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
    }
}
