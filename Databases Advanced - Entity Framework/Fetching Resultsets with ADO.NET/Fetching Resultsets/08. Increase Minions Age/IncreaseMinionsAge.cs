namespace _08.Increase_Minions_Age
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class IncreaseMinionsAge
    {
        public static void Main()
        {
            SqlConnection connection =
                new SqlConnection("Data Source=(local);Initial Catalog=MinionsDB;Integrated Security=True");

            var minionsIds = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //updating age and name (title case)
            var updateAgeAndNameQuery = string.Format($@"UPDATE Minions
                                                         SET Age+=1, Name = UPPER(LEFT(Name, 1)) + 
                                                           LOWER(SUBSTRING(Name, 2, LEN(Name)))
                                                         WHERE Id IN ({string.Join(", ", minionsIds)})");
            //printing all minion names and age
            var printAllMinionsCmd = new SqlCommand(@"SELECT Name, Age FROM Minions", connection);
            var updateAgeAndNameCmd = new SqlCommand(updateAgeAndNameQuery, connection);
            connection.Open();
            updateAgeAndNameCmd.ExecuteNonQuery();
            var resultReader = printAllMinionsCmd.ExecuteReader();
            while (resultReader.Read())
            {
                Console.WriteLine($"{resultReader[0]} {resultReader[1]}");
            }
        }
    }
}