using WebApiBankDashBoard.Interfaces;

namespace WebApiBankDashBoard.Services
{
    public class AccountManagementService : IAccountManagementService
    {
        private readonly IMathService _mathService;
        private readonly IAuthentication _authentication;
        public AccountManagementService(IMathService mathService, IAuthentication authentication)
        {
            _mathService = mathService;
            _authentication = authentication;
        }

        public async Task<decimal> AddToAmount(int userId, decimal value)
        {
            var user = await _authentication.GetUserByIdAsync(userId);

            if (user is null)
            {
                throw new ArgumentNullException("User not found.");
            }

            return _mathService.Sum(user.CurrentBalance, value);
        }

        public async Task<decimal> SubtractFromAmount(int userId, decimal value)
        {
            var user = await _authentication.GetUserByIdAsync(userId);

            if (user is null)
                throw new ArgumentNullException("User not found.");
      

            if (user.CurrentBalance <= 0 || value > user.CurrentBalance)
                throw new ArgumentNullException("Not enough money in you balance.");

            return _mathService.Subtract(user.CurrentBalance, value);
        }
    }
}
