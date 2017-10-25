namespace _05.Change_Town_Names_Casing
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class ChangeTownNamesCasing
    {
        public static void Main()
        {
            SqlConnection connection =
                new SqlConnection("Data Source=(local);Initial Catalog=MinionsDB;Integrated Security=True");

            var country = Console.ReadLine();
            
            //list which will hold the non uppered case town names
            var affectedTownsList = new List<string>();
            
            //command which returns the non uppered case town names (in uppered case)
            var printNonUpperedCmd = new SqlCommand(@"SELECT UPPER(Name) FROM Towns
                                                      WHERE Name != UPPER(Name) 
                                                      collate SQL_Latin1_General_CP1_CS_AS
                                                      AND Country = @Country"
                                , connection);
            printNonUpperedCmd.Parameters.AddWithValue("@Country", country);
            connection.Open();
            var reader = printNonUpperedCmd.ExecuteReader();
            
            while (reader.Read())
            {
                affectedTownsList.Add(reader[0].ToString());
            }

            connection.Close();
            //changing the given country town names to upper case
            var changeNameCommand = new SqlCommand(@"UPDATE Towns
                                                     SET Name = UPPER(Name)
                                                     WHERE Country = @Country", connection);
            changeNameCommand.Parameters.AddWithValue("@Country", country);
            connection.Open();
            changeNameCommand.ExecuteNonQuery();
            connection.Close();
            if (affectedTownsList.Count == 0)
            {
                Console.WriteLine("No town names were affected.");
            }

            else
            {
                Console.WriteLine($"{affectedTownsList.Count} town names were affected.");
                Console.WriteLine($"[{String.Join(", ", affectedTownsList)}]");
            }
        }
    }
}