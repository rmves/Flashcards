class Program
{
    static void Main(string[] args)
    {
        string connectionString = @"Data Source=(localdb)\localdbFlashcard;Integrated Security=True";
        DatabaseManager dbManager = new DatabaseManager(connectionString);
        dbManager.CreateDatabaseAndTables();
    }
}