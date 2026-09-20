using Blockchain.Application.Contracts;
using Blockchain.Domain.Enums;
using Blockchain.Application.Queries;
using Blockchain.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlockChain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockChainController : ControllerBase
    {
        private readonly IBlockHistoryService _blockHistoryService;
        public BlockChainController(IBlockHistoryService blockHistoryService)
        {
            _blockHistoryService = blockHistoryService;
        }
        /// <summary>
        /// Query block chain items.
        /// </summary>
        /// <param name="cypherRequest"> The block chain token to query. Possible values are: BTC, ETH, LTC  Token mode type Possible values are: Main, Test3</param>
        /// <returns>Docunet retrieved from Cypher API</returns>
        /// <response code="200">Returns the latest block chain data</response>
        /// <response code="404">No data found </response>
        /// <response code="400">Token type or mode type is not provided or invalid</response>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBlockChainBlocks([FromQuery]CypherRequest cypherRequest, CancellationToken token)
        {
            var result = await _blockHistoryService.GetBlockCypher(cypherRequest, token);
            return result != null ? Ok(result) : NotFound();
        }
    }
}
