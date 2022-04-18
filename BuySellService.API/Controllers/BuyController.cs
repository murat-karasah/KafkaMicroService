using BuySellService.Domain.Entities;
using BuySellService.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BuySellService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyController : ControllerBase
    {
        private readonly IBuyRepository _buyRepository;

        public BuyController(IBuyRepository buyRepository)
        {
            _buyRepository = buyRepository;
        }

        // GET: api/<BuyController>
        [HttpGet]
        public IActionResult Get()
        {
            var buys = _buyRepository.GetBuy();
            return new OkObjectResult(buys);

        }

        // GET api/<BuyController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var buy = _buyRepository.GetById(id);
            return new OkObjectResult(buy);
        }

        // POST api/<BuyController>
        [HttpPost]
        public IActionResult Post([FromBody] BuyEntity buy)
        {
            using (var scope = new TransactionScope())
            {
                _buyRepository.Add(buy);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = buy.Id }, buy);
            }
        }

        // PUT api/<BuyController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BuyEntity buy)
        {
            if (buy != null)
            {
                using (var scope = new TransactionScope())
                {
                    _buyRepository.Update(buy);
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
            _buyRepository.Delete(id);
            return new OkResult();
        }
    }
}
