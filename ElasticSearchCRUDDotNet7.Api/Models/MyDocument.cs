namespace ElasticSearchCRUDDotNet7.Api.Models
{
    public class MyDocument
    {
        public int Id { get; set; } = new Random().Next();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;


    }
}
