using Microsoft.Azure.CosmosRepository;
using Moq;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using WebApiPayment.Test._Ultil;
using WebApiBankDashBoard.Model;
using WebApiBankDashBoard.Services;
using Xunit;

namespace WebApiPayment.Test.Service
{
    public  class TransactionServiceTest
    {
        private TransactionService? _transactionService;
       
        private readonly Mock<IRepositoryFactory> _transactionRepository;
        public TransactionServiceTest()
        {
            _transactionRepository = new Mock<IRepositoryFactory>();
        }

        [Fact]
        public async Task TransactionStatment_UserFound_IEnumerableOfTransactionStatment()
        {
            //Arrange
            var transactions = TransactionStatmentFaker.GetUserTransactionStatment(5, "Vitor L. S.");
            _transactionRepository.Setup(x => x.RepositoryOf<TransactionStatment>()
                                                .GetAsync(It.IsAny<Expression<Func<TransactionStatment, bool>>>(), It.IsAny<CancellationToken>()))
                                                .ReturnsAsync(transactions);

            _transactionService = new TransactionService(_transactionRepository.Object);
            //Act
            var result = await _transactionService.GetTransactionHistoricByUserIdAsync(1);

            //Assert
            Assert.Equal(transactions.Count(), result.ToList().Count());
        }


    }
}
