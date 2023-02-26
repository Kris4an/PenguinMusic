using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PenguinMusic.Data
{
    public static class Database
    {
        private static string connectionString = "Server=COMP7\\MSSQLSERVERNEW; Database=Penguin_music; Integrated Security=true";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
