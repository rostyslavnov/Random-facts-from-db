using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace project
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // polaczenie z baza danych
           string connectionString = "Data Source=LAPTOP-D44GI3J9;Initial Catalog=project;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // zapytanie do bazy danych
                string query = "SELECT factText FROM facts";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // lista z faktami
                        var facts = new List<string>();

                        while (reader.Read())
                        {
                            facts.Add(reader["factText"].ToString());
                        }

                        // random
                        Random rand = new Random();
                        int index = rand.Next(facts.Count);
                        Console.WriteLine("Losowy fakt: " + facts[index]);
                    }
                }
                connection.Close();
                Console.ReadLine();
            }
        }
    }
}
