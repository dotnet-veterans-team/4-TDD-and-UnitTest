using WebApiBankDashBoard.Model;

namespace WebApiBankDashBoard.Interfaces
{
    public interface IAccountManagementService
    {
        Task<decimal> AddToAmount(int userId, decimal value);

        Task<decimal> SubtractFromAmount(int userId, decimal value);
    }
}
