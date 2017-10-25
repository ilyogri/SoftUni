namespace _01.Initial_Setup
{
    using System;
    using System.Data.SqlClient;

    public class InitialSetup
    {
        public static void Main()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                ["Data Source"] = "(local)",
                ["integrated Security"] = true
            };

            SqlConnection connection = new SqlConnection(builder.ToString());

            try
            {
                using (connection)
                {
                    connection.Open();
                    var dbCreateQuery = @"CREATE DATABASE MinionsDB";
                    var cmd = new SqlCommand(dbCreateQuery, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                connection.Close();
            }

            builder["initial catalog"] = "MinionsDB";
            connection = new SqlConnection(builder.ToString());

            try
            {
                connection.Open();

                //creating the create table queries
                var createTownsQ = new SqlCommand(@"CREATE TABLE Towns (
                                        	        Id INT IDENTITY PRIMARY KEY,
                                        	        Name VARCHAR(50) NOT NULL,
                                        	        Country VARCHAR(50) NOT NULL )", connection);
                var createMinionsQ = new SqlCommand(@"CREATE TABLE Minions (
                                        	          Id INT IDENTITY PRIMARY KEY,
                                        	          Name VARCHAR(100) NOT NULL,
                                        	          Age INT NOT NULL,
                                        	          TownId INT NOT NULL,
                                        	          CONSTRAINT FK_Minions_Towns
                                        	          FOREIGN KEY(TownId) REFERENCES Towns(Id))", connection);
                var createVillains = new SqlCommand(@"CREATE TABLE Villains (
	                                                  Id INT IDENTITY PRIMARY KEY,
	                                                  Name VARCHAR(50) NOT NULL,
	                                                  EvilnessFactor VARCHAR(50) CHECK 
                                                      (EvilnessFactor IN ('good', 'bad', 'evil', 'super evil', 'super good')))", connection);
                var createMinionsVillains = new SqlCommand(@"CREATE TABLE MinionsVillains (
	                                                         MinionId INT,
	                                                         VillainId INT,
	                                                         PRIMARY KEY(MinionId, VillainId),
                                                             CONSTRAINT FK_MinionsVillains_Minions
                                                             FOREIGN KEY(MinionId) REFERENCES Minions(Id),
                                                             CONSTRAINT FK_MinionsVillains_Villains
                                                             FOREIGN KEY(VillainId) REFERENCES Villains(Id))", connection);

                //executing the create queries
                createTownsQ.ExecuteNonQuery();
                createMinionsQ.ExecuteNonQuery();
                createVillains.ExecuteNonQuery();
                createMinionsVillains.ExecuteNonQuery();

                //creating the insert table queries
                var insertTownsSQL = new SqlCommand("INSERT INTO Towns (Name, Country) VALUES ('Sofia','Bulgaria'), ('Burgas','Bulgaria'), ('Varna', 'Bulgaria'), ('London','UK'),('Liverpool','UK'),('Ocean City','USA'),('Paris','France')", connection);
                var insertMinionsSQL = new SqlCommand("INSERT INTO Minions (Name, Age, TownId) VALUES ('bob',10,1),('kevin',12,2),('steward',9,3), ('rob',22,3), ('michael',5,2),('pep',3,2)", connection);
                var insertVillainsSQL = new SqlCommand("INSERT INTO Villains (Name, EvilnessFactor) VALUES ('Gru','super evil'),('Victor','evil'),('Simon Cat','good'),('Pusheen','super good'),('Mammal','evil')", connection);
                var insertMinionsVillainsSQL = new SqlCommand("INSERT INTO MinionsVillains VALUES (1,2), (3,1),(1,3),(3,3),(4,1),(2,2),(1,1),(3,4), (1, 4), (1,5), (5, 1)", connection);

                //executing the insert table queries
                insertTownsSQL.ExecuteNonQuery();
                insertMinionsSQL.ExecuteNonQuery();
                insertVillainsSQL.ExecuteNonQuery();
                insertMinionsVillainsSQL.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}