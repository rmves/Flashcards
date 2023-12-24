using System.Configuration;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        DatabaseManager dbManager = new DatabaseManager(connectionString);
        dbManager.CreateDatabaseAndTables();


    }
}