using Microsoft.Azure.CosmosRepository;
using WebApiBankDashBoard.Interfaces;
using WebApiBankDashBoard.Model;

namespace WebApiBankDashBoard.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepository<TransactionStatment> _transactionRepository;
        public TransactionService(IRepositoryFactory factory)
        {
            _transactionRepository = factory.RepositoryOf<TransactionStatment>();
        }

        public async Task<IEnumerable<TransactionStatment>> GetTransactionHistoricByUserIdAsync(int userId)
        {
            return await _transactionRepository.GetAsync(x => x.Id == userId);
        }
    }
}
