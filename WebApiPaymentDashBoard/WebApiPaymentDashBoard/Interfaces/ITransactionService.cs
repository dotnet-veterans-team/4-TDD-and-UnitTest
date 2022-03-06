using WebApiBankDashBoard.Model;

namespace WebApiBankDashBoard.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionStatment>> GetTransactionHistoricByUserIdAsync(int userId);
    }
}
