using System.Data.SqlClient;

namespace _06.Remove_Villain
{
    using System;

    public class RemoveVillain
    {
        public static void Main()
        {
            SqlConnection connection =
                new SqlConnection("Data Source=(local);Initial Catalog=MinionsDB;Integrated Security=True");

            var villainId = int.Parse(Console.ReadLine());

            var villainNameCmd = new SqlCommand(@"SELECT Name FROM Villains WHERE Id = @villainId", connection);
            var releasedMinionsCmd = new SqlCommand(@"SELECT COUNT(*) FROM MinionsVillains
                                                   WHERE VillainId = @villainId", connection);
            var deleteFromMVCmd = new SqlCommand(@"DELETE FROM MinionsVillains
                                                   WHERE VillainId = @villainId", connection);
            var deleteFromVCmd = new SqlCommand(@"DELETE FROM Villains
                                                  WHERE Id = @villainId", connection);

            deleteFromMVCmd.Parameters.AddWithValue("@villainId", villainId);
            deleteFromVCmd.Parameters.AddWithValue("@villainId", villainId);
            releasedMinionsCmd.Parameters.AddWithValue("@villainId", villainId);
            villainNameCmd.Parameters.AddWithValue("@villainId", villainId);

            connection.Open();
            //gets the villain name
            var villainName = villainNameCmd.ExecuteScalar();
            connection.Close();
            connection.Open();
            //gets the minions counted which will be deleted
            var releasedMinionsCount = (int)releasedMinionsCmd.ExecuteScalar();
            //deletes villains from both tables
            deleteFromMVCmd.ExecuteNonQuery();
            deleteFromVCmd.ExecuteNonQuery();
            connection.Close();

            if (releasedMinionsCount == 0)
            {
                Console.WriteLine("No such villain was found");
            }

            else
            {
                Console.WriteLine($"{villainName} was deleted");
                Console.WriteLine($"{releasedMinionsCount} minions released");
            }
        }
    }
}