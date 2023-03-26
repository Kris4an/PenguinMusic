using PenguinMusic.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PenguinMusic.Data
{
    class DonationData
    {
        public void Add(string name, int amount)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("INSERT INTO Donations (Name, Amount) VALUES(@name, @amount)", connection);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("amount", amount);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public List<Donation> GetTop3Donators()
        {
            List<Donation> donations = new List<Donation>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT Top 3 d.Name, sum(d.Amount) as Amount FROM Donations d group by d.Name order by Amount desc", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    int n = 0;
                    while (reader.Read())
                    {
                        var donation = new Donation(
                            n,
                            reader.GetString(0),
                            reader.GetInt32(1)
                        );
                        n++;
                        donations.Add(donation);
                    }

                }
                connection.Close();
            }
            return donations;
        }
    }
}
