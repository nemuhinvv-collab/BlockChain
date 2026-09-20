using BlockChain.Application.Contracts;
using BlockChain.Application.Requests;
using BlockChain.Application.Responses;
using BlockChain.Application.Responses.BaseResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlockChain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockChainRequestController : ControllerBase
    {
        private readonly ILogger<BlockChainRequestController> _logger;
        private readonly IBlockHistoryRequestService _blockHistoryRequestService;

        public BlockChainRequestController(ILogger<BlockChainRequestController> logger, IBlockHistoryRequestService blockHistoryRequestService)
        {
            _logger = logger;
            _blockHistoryRequestService = blockHistoryRequestService;
        }
        /// <summary>
        /// Get Block history requests with results from Cypher API based on the provided query parameters.
        /// </summary>
        /// <param name="query"> The query parameters for the block history request. Contains page number and page size</param>
        /// <returns>Document retrieved from Cypher API</returns>
        /// <response code="200">Contains the requested block history data</response>
        /// <response code="404">No data found </response>

        [HttpGet]
        [ProducesResponseType(typeof(IList<BlockHistoryQueryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBlockHistoryPaged([FromQuery] GetHistoryEntryPageRequest query)
        {
            var result = await _blockHistoryRequestService.GetBlockHistoryPaged(query);
            return result is null || !result.Any() ? NotFound() : Ok(result);
        }
    }
}
