using ExpenseRevenueService.Domain.Entities;
using ExpenseRevenueService.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpenseRevenueService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var expenses = _expenseRepository.GetExpense();
            return new OkObjectResult(expenses);

        }

        // POST api/<BuyController>
        [HttpPost]
        public IActionResult Post([FromBody] ExpenseEntity expense)
        {
            using (var scope = new TransactionScope())
            {
                _expenseRepository.Add(expense);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = expense.Id }, expense);
            }
        }

        // PUT api/<BuyController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ExpenseEntity expense)
        {
            if (expense != null)
            {
                using (var scope = new TransactionScope())
                {
                    _expenseRepository.Update(expense);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

       
    }
}
