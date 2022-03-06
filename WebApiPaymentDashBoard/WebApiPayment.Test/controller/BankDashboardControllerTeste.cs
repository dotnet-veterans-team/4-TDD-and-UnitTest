using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiBankDashBoard.Controllers;
using WebApiBankDashBoard.Interfaces;
using Xunit;

namespace WebApiPayment.Test.controller
{
    public class BankDashboardControllerTeste
    {
        private BankDashboardController? _bankDashboardController;
        private readonly Mock<IAccountManagementService> _accountManagement;
        private readonly Mock<ITransactionService> _transactionService;

        public BankDashboardControllerTeste()
        {
            _accountManagement = new Mock<IAccountManagementService>();
            _transactionService = new Mock<ITransactionService>();
        }

        [Fact]
        public async void AddValueToAccountAsyn_AddValueSucces_ReturnAmount()
        {
            //Arrange
            _accountManagement.Setup(x => x.AddToAmount(It.IsAny<int>(), It.IsAny<decimal>())).ReturnsAsync((decimal)10.3);
            _bankDashboardController = new BankDashboardController(_accountManagement.Object, _transactionService.Object);
            //Act
            var result = await _bankDashboardController.AddValueToAccountAsyn(It.IsAny<int>(), It.IsAny<decimal>());
            var okResult = result as OkObjectResult;
            //Assert
            Assert.IsType<decimal>(okResult.Value);
        }
    }
}