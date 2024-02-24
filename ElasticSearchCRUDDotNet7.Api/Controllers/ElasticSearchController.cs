using ElasticSearchCRUDDotNet7.Api.Models;
using ElasticSearchCRUDDotNet7.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElasticSearchCRUDDotNet7.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElasticSearchController : ControllerBase
    {
        private readonly IElasticSearchService<MyDocument> _elasticSearchService;
        public ElasticSearchController(IElasticSearchService<MyDocument> elasticSearchService)
        {
            _elasticSearchService = elasticSearchService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDocumentsAsync()
        {
            var response = await _elasticSearchService.GetAllDocumentsAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("read/{id}")]
        public async Task<IActionResult> GetDocument(int id)
        {
            var document = await _elasticSearchService.GetDocumentAsync(id);
            if (document is null)
                return NotFound();
            return Ok(document);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDocument([FromBody]MyDocument myDocument)
        {
            var result = _elasticSearchService.UpdateDocumentAsync(myDocument);
            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _elasticSearchService.DeleteDocumentAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] MyDocument myDocument)
        {
            var result = await _elasticSearchService.CreateDocumentAsync(myDocument);
            return Ok(result);
        }

    }
}
