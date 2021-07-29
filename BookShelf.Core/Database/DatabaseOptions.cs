namespace BookShelf.Core.Database
{
    public class DatabaseOptions : IConfigurationOptions
    {
        public static string ConfigurationKey => "Database";
        public string DatabaseName { get; set; }
    }
}