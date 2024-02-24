namespace ElasticSearchCRUDDotNet7.Api.Services
{
    public interface IElasticSearchService<T> where T : class
    {
        public Task<string> CreateDocumentAsync(T obj);
        public Task<T> GetDocumentAsync(int id);
        public Task<string> DeleteDocumentAsync(int id);
        public Task<IEnumerable<T>> GetAllDocumentsAsync();
        public Task<string> UpdateDocumentAsync(T obj);
    }
}
