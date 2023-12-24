using System;
using System.Data;
using System.Data.SqlClient;

public class DatabaseManager
{
    private string connectionString;

    public DatabaseManager(string dbConnectionString)
    {
        connectionString = dbConnectionString;
    }

    public void CreateDatabaseAndTables()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connected to SQL Server.");

                // Create the database
                CreateDatabase(connection);

                // Use the newly created database
                connection.ChangeDatabase("FlashcardApp");

                // Create tables if they don't exist
                CreateTableStacks(connection);
                CreateTableFlashcards(connection);

                Console.WriteLine("Database and tables created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    private void CreateDatabase(SqlConnection connection)
    {
        string createDbQuery = "CREATE DATABASE FlashcardApp";
        SqlCommand createDbCommand = new SqlCommand(createDbQuery, connection);
        createDbCommand.ExecuteNonQuery();
    }

    private void CreateTableStacks(SqlConnection connection)
    {
        string createTableQuery = @"
            CREATE TABLE Stacks (
                StackID INT PRIMARY KEY IDENTITY,
                StackName NVARCHAR(50) NOT NULL
            )";
        SqlCommand createTableCommand = new SqlCommand(createTableQuery, connection);
        createTableCommand.ExecuteNonQuery();
    }

    private void CreateTableFlashcards(SqlConnection connection)
    {
        string createTableQuery = @"
            CREATE TABLE Flashcards (
                FlashcardID INT PRIMARY KEY IDENTITY,
                Question NVARCHAR(255) NOT NULL,
                Answer NVARCHAR(255) NOT NULL,
                StackID INT FOREIGN KEY REFERENCES Stacks(StackID)
            )";
        SqlCommand createTableCommand = new SqlCommand(createTableQuery, connection);
        createTableCommand.ExecuteNonQuery();
    }
}
