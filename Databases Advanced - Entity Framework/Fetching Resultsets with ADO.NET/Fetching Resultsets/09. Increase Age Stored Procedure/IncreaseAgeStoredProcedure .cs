namespace _09.Increase_Age_Stored_Procedure
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class IncreaseAgeStoredProcedure
    {
        public static void Main()
        {
            SqlConnection connection =
                new SqlConnection("Data Source=(local);Initial Catalog=MinionsDB;Integrated Security=True");

            var minionId = int.Parse(Console.ReadLine());
            var updateAgeCmd = new SqlCommand("usp_GetOlder", connection);
            updateAgeCmd.CommandType = CommandType.StoredProcedure;
            updateAgeCmd.Parameters.AddWithValue("@MinionId", minionId);

            var printMinionData = new SqlCommand("SELECT Name, Age FROM Minions WHERE Id = @minionId", connection);
            printMinionData.Parameters.AddWithValue("@minionId", minionId);

            connection.Open();
            updateAgeCmd.ExecuteNonQuery();
            var reader = printMinionData.ExecuteReader();
            reader.Read();
            Console.WriteLine($"{reader[0]} {reader[1]}");
        }
    }
}