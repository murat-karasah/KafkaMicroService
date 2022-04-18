using BuySellService.Domain.Entities;
using BuySellService.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BuySellService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellController : ControllerBase
    {
        private readonly ISellRepository _sellRepository;

        public SellController(ISellRepository sellRepository)
        {
            _sellRepository = sellRepository;
        }



        // GET: api/<BuyController>
        [HttpGet]
        public IActionResult Get()
        {
            var sells = _sellRepository.GetBuy();
            return new OkObjectResult(sells);

        }

        // GET api/<BuyController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var sell = _sellRepository.GetById(id);
            return new OkObjectResult(sell);
        }

        // POST api/<BuyController>
        [HttpPost]
        public IActionResult Post([FromBody] SellEntity sell)
        {
            using (var scope = new TransactionScope())
            {
                _sellRepository.Add(sell);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = sell.Id }, sell);
            }
        }

        // PUT api/<BuyController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SellEntity sell)
        {
            if (sell != null)
            {
                using (var scope = new TransactionScope())
                {
                    _sellRepository.Update(sell);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<BuyController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _sellRepository.Delete(id);
            return new OkResult();
        }
    }
}