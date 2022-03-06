using Microsoft.AspNetCore.Mvc;
using WebApiBankDashBoard.Interfaces;

namespace WebApiBankDashBoard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankDashboardController : ControllerBase
    {
        private readonly IAccountManagementService _accountManagement;
        private readonly ITransactionService _transactionService;

        public BankDashboardController(IAccountManagementService accountManagement,
                                            ITransactionService transactionService)
        {
            _accountManagement = accountManagement;
            _transactionService = transactionService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddValueToAccountAsyn(int userId, decimal value)
        {
            try
            {
                return new OkObjectResult(await _accountManagement.AddToAmount(userId, value)) ;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Fail too Add value to Account.", error = ex });
            }
        }

        [HttpPost("whitdraw")]
        public async Task<IActionResult> SubtractValueToAccountAsyn(int userId, decimal value)
        {
            try
            {
                return new OkObjectResult(await _accountManagement.AddToAmount(userId, value));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Fail to whitdraw value to Account.", error = ex });
            }
        }

        [HttpGet("transaction-historic")]
        public async Task<IActionResult> GetTransactionHistoricByUserIdAsync(int userId, decimal value)
        {
            try
            {
                return new OkObjectResult(await _transactionService.GetTransactionHistoricByUserIdAsync(userId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Fail too Add value to Account.", error = ex });
            }
        }
    };     
}