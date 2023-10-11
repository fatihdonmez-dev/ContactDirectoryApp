namespace Report.API.Settings
{
    public interface IDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ReportCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
