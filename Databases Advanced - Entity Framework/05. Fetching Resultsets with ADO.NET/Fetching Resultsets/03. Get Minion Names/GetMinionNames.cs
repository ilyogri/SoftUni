using System.Data.SqlClient;

namespace _03.Get_Minion_Names
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class GetMinionNames
    {
        public static void Main()
        {
            SqlConnection connection =
                new SqlConnection("Data Source=(local);Initial Catalog=MinionsDB;Integrated Security=True");

            var villainId = int.Parse(Console.ReadLine());
            var cmd = new SqlCommand(@"SELECT DISTINCT v.Name, m.Name, m.Age
                                       FROM Villains AS v
                                       FULL JOIN MinionsVillains AS mn ON v.Id = mn.VillainId
                                       FULL JOIN Minions AS m ON m.Id = mn.MinionId
                                       WHERE v.Id = @VillainId
                                       ORDER BY m.Age", connection);
            cmd.Parameters.AddWithValue("@VillainId", villainId);

            connection.Open();
            var reader = cmd.ExecuteReader();

            using (reader)
            {
                if (!reader.Read())
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                    return;
                }

                Console.WriteLine($"Villain: {reader[0]}");

                if (reader[1] == DBNull.Value)
                {
                    Console.WriteLine("(no minions)");
                    return;
                }

                var counter = 1;

                while (reader.Read())
                {
                    Console.WriteLine($"{counter}. {reader[1]} {reader[2]}");
                    counter++;
                }
            }
            connection.Close();
        }
    }
}