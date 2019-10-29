namespace MusicListapi.Models
{
    public class MusicDatabaseSettings : IMusicDatabaseSettings
    {
        public string MusicCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMusicDatabaseSettings
    {
        string MusicCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}