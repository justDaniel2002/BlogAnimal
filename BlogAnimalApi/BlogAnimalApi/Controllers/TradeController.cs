using BlogAnimalApi.DTO;
using BlogAnimalApi.DTO.requestDTO;
using BlogAnimalApi.Entity;
using BlogAnimalApi.Helper;
using BlogAnimalApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogAnimalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeController : ControllerBase
    {

        private readonly TradeService tradeService;
        private readonly Util util;
        public TradeController(TradeService tradeService, Util util)
        {
            this.tradeService = tradeService;
            this.util = util;
        }

        // GET: api/<TradeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await tradeService.getAll());
        }


        // POST api/<TradeController>
        [HttpPost("commentTrade")]
        public async Task<IActionResult> commentTrade(TradeCommentDTO tradeCommentDTO)
        {
            try
            {
                await tradeService.commentTrade(tradeCommentDTO);
                return StatusCode(StatusCodes.Status201Created);
            }catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        // POST api/<TradeController>
        [HttpPost()]
        public async Task<IActionResult> createTrade(CreateTradeDTO tradeDTO)
        {
            try
            {
                await tradeService.createTrade(tradeDTO);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        // PUT api/<TradeController>/5
        [HttpPut("setTrade/{id}")]
        public async Task<IActionResult> setTrade(string id)
        {
            try
            {
                await tradeService.setTrade(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> updateTrade(UpdateTradeDTO tradeDTO)
        {
            try
            {
                TradePost trade = await tradeService.UpdateTrade(tradeDTO);
                return Ok(trade);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }

        // DELETE api/<TradeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(string id)
        {
            try
            {
                await tradeService.deleteTrade(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        // PUT api/<TradeController>/5
        [HttpPut("secure/{id}")]
        public async Task<IActionResult> secureTrade(string id)
        {
            try
            {
                await tradeService.secureTrade(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
