
namespace _02.Get_Villains__Names
{
    using System;
    using System.Data.SqlClient;

    public class GetVillainsNames
    {
        public static void Main()
        {
            SqlConnection connection =
                new SqlConnection("Data Source=(local);Initial Catalog=MinionsDB;Integrated Security=True");

            var cmd = new SqlCommand(@"SELECT v.Name, COUNT(m.Id) AS MinionsCount
                                           FROM Villains AS v
                                           JOIN MinionsVillains AS mn ON v.Id = mn.VillainId
                                           JOIN Minions AS m ON m.Id = mn.MinionId
                                           GROUP BY v.Name
                                           HAVING COUNT(m.Id) > 3
                                           ORDER BY MinionsCount DESC", connection);
            connection.Open();
            var reader = cmd.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} {reader[1]}");
                }
            }

            connection.Close();
        }
    }
}