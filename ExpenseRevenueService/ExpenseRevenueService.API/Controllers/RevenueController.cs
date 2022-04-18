using ExpenseRevenueService.Domain.Entities;
using ExpenseRevenueService.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpenseRevenueService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevenueController : ControllerBase
    {
        private readonly IRevenueRepository _revenueRepository ;

        public RevenueController(IRevenueRepository revenueRepository)
        {
            _revenueRepository = revenueRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var revenue = _revenueRepository.GetExpense();
            return new OkObjectResult(revenue);

        }

        // POST api/<BuyController>
        [HttpPost]
        public IActionResult Post([FromBody] RevenueEntity revenue)
        {
            using (var scope = new TransactionScope())
            {
                _revenueRepository.Add(revenue);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = revenue.Id }, revenue);
            }
        }

        // PUT api/<BuyController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RevenueEntity revenue)
        {
            if (revenue != null)
            {
                using (var scope = new TransactionScope())
                {
                    _revenueRepository.Update(revenue);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
    }
}
