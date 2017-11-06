using System.Linq;

namespace _04.Add_Minion
{
    using System;
    using System.Data.SqlClient;

    public class AddMinion
    {
        public static void Main()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                ["Data Source"] = "(local)",
                ["Initial Catalog"] = "MinionsDB",
                ["integrated Security"] = true
            };

            SqlConnection connection = new SqlConnection(builder.ToString());

            Console.Write("Minion: ");
            var minionData = Console.ReadLine().Split(' ').ToArray();
            Console.Write("Villain: ");
            var villainName = Console.ReadLine();

            var minionName = minionData[0];
            var minionTown = minionData[2];

            //check if every data is already in the
            var command = new SqlCommand(@"SELECT 
                                         (SELECT COUNT(*) FROM Minions WHERE Name = @MinionName),
                                         (SELECT COUNT(*) FROM Villains WHERE Name = @VillainName),
                                         (SELECT COUNT(*) FROM Towns WHERE Name = @TownName)", connection);

            command.Parameters.AddWithValue("@MinionName", minionName);
            command.Parameters.AddWithValue("@VillainName", villainName);
            command.Parameters.AddWithValue("@TownName", minionTown);

            connection.Open();
            var reader = command.ExecuteReader();

                reader.Read();
                var minionCount = (int) reader[0];
                var villainCount = (int) reader[1];
                var townCount = (int) reader[2];
                
                var minionsVillainsCheck = new SqlCommand(@"SELECT * FROM MinionsVillains
                                                            WHERE MinionId = (SELECT Id FROM Minions WHERE Name = @MinionName)
                                                            AND VillainId = (SELECT Id FROM Villains WHERE Name = @VillainName)",
                                                            connection);
                minionsVillainsCheck.Parameters.AddWithValue("@MinionName", minionName);
                minionsVillainsCheck.Parameters.AddWithValue("@VillainName", villainName);
                connection.Close();
                connection.Open();
                reader = minionsVillainsCheck.ExecuteReader();

                if (reader.HasRows)
                {
                    return;
                }

                if (minionCount == 1 && villainCount == 1 && townCount == 0)
                {
                    InsertTown(minionTown, connection);
                }

                else if (minionCount == 1 && villainCount == 0 && townCount == 1)
                {
                    connection.Open();
                    InsertVillain(villainName, connection);
                }

                else if (minionCount == 1 && villainCount == 0 && townCount == 0)
                {
                    InsertVillain(villainName, connection);
                    InsertTown(minionTown, connection);
                }

                reader.Close();
                InsertIntoMinionsVillains(minionName, villainName, connection);
                connection.Close();
        }

        private static void InsertVillain(string villainName, SqlConnection connection)
        {
                var villainInsert = new SqlCommand(@"INSERT INTO Villains(Name, EvilnessFactor)
                                                         VALUES (@VillainName, 'evil')", connection);
                villainInsert.Parameters.AddWithValue("@VillainName", villainName);
                villainInsert.ExecuteNonQuery();
                Console.WriteLine($"Villain {villainName} was added to the database.");
        }

        private static void InsertTown(string minionTown, SqlConnection connection)
        {
                var townInsertion = new SqlCommand(@"INSERT INTO Towns(Name, Country)
                                                         VALUES (@TownName, NULL)", connection);
                townInsertion.Parameters.AddWithValue("@TownName", minionTown);
                townInsertion.ExecuteNonQuery();
                Console.WriteLine($"Town {minionTown} was added to the database.");
        }

        public static void InsertIntoMinionsVillains(string minionName, string villainName, SqlConnection connection)
        {
            var minionsVillainsInsert = new SqlCommand(@"INSERT INTO MinionsVillains(MinionId, VillainId)
                                                         VALUES (
	                                                             (SELECT Id FROM Minions WHERE Name = @MinionName),
	                                                             (SELECT Id FROM Villains WHERE Name = @VillainName)
	                                                            )", connection);
            minionsVillainsInsert.Parameters.AddWithValue("@MinionName", minionName);
            minionsVillainsInsert.Parameters.AddWithValue("@VillainName", villainName);
            minionsVillainsInsert.ExecuteNonQuery();
            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }
    }
}