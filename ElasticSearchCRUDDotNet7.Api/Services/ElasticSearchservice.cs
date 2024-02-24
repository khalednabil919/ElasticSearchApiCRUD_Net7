
using Nest;
using System.Reflection.Metadata.Ecma335;

namespace ElasticSearchCRUDDotNet7.Api.Services
{
    public class ElasticSearchservice<T> : IElasticSearchService<T> where T : class
    {
        private readonly ElasticClient _elasticClient;

        public ElasticSearchservice(ElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }
        public async Task<string> CreateDocumentAsync(T obj)
        {
            var response = await _elasticClient.IndexDocumentAsync(obj);
            return response.IsValid ? "Successfully Created":"Failed";
        }

        public async Task<string> DeleteDocumentAsync(int id)
        {
            var response = await _elasticClient.DeleteAsync(new DocumentPath<T>(id));
            return response.IsValid ? "Successfully Deleted" : "Failed";
        }

        public async Task<IEnumerable<T>> GetAllDocumentsAsync()
        {
            var searchResponse = await _elasticClient.SearchAsync<T>(s => s.MatchAll().Size(100));
            return searchResponse.Documents;
        }

        public async Task<T> GetDocumentAsync(int id)
        {
            var response = await _elasticClient.GetAsync(new DocumentPath<T>(id));
            return response.Source;
        }

        public async Task<string> UpdateDocumentAsync(T obj)
        {
            var response = await _elasticClient.UpdateAsync(new DocumentPath<T>(obj), u => u
                        .Doc(obj)
                        .RetryOnConflict(3));
            return response.IsValid ? "Successfully Updated" : "Failed";
        }
    }
}
