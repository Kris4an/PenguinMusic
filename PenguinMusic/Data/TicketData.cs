using PenguinMusic.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PenguinMusic.Data
{
    class TicketData
    {
        public void BuyTicket(string name, int concertId)
        {
            Concerts c = new ConcertData().getConcertById(concertId);
            if(GetSoldTicketsByConcetId(concertId)+1>=new HallData().GetHallById(c.HallId).NoOfSeats)
            {
                using (var connection = Database.GetConnection())
                {
                    var command = new SqlCommand($"Update Concerts SET Available={false} WHERE Concert_ID={concertId}", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    var command2 = new SqlCommand("INSERT INTO Sold_Tickets (Name, Concert_ID) VALUES(@name, @concertId)", connection);
                    command2.Parameters.AddWithValue("name", name);
                    command2.Parameters.AddWithValue("concertId", concertId);
                    command2.ExecuteNonQuery();
                    connection.Close();
                }
                return;
            }
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("INSERT INTO Sold_Tickets (Name, Concert_ID) VALUES(@name, @concertId)", connection);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("concertId", concertId);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public int GetSoldTicketsByConcetId(int id)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand($"SELECT COUNT(Concert_ID) FROM Sold_Tickets WHERE Concert_ID={id}", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }

                }
                connection.Close();
            }
            return 0;
        }
        public List<Ticket> GetSoldTickets()
        {
            List<Ticket> tickets = new List<Ticket>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM Sold_Tickets", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ticket = new Ticket(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetInt32(2)
                        );

                        tickets.Add(ticket);
                    }

                }
                connection.Close();
            }
            return tickets;
        }
    }
}
