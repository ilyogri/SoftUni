namespace _07.Print_All_Minion_Names
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class PrintAllMinionNames
    {
        public static void Main()
        {
            SqlConnection connection =
                new SqlConnection("Data Source=(local);Initial Catalog=MinionsDB;Integrated Security=True");

            var minionsIds = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var getNamesCmdText = string.Format(@"SELECT Name
                                               FROM Minions
                                               WHERE Id IN ({0})
                                               ORDER BY Name", string.Join(", ", minionsIds));
            var getNamesCmd = new SqlCommand(getNamesCmdText, connection);
            connection.Open();
            var reader = getNamesCmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["Name"]);
            }
        }
    }
}