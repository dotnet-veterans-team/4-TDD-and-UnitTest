using Moq;
using System;
using System.Threading.Tasks;
using WebApiPayment.Test._Ultil;
using WebApiBankDashBoard.Interfaces;
using WebApiBankDashBoard.Model;
using WebApiBankDashBoard.Services;
using Xunit;

namespace WebApiPayment.Test.Service
{
    public class AccountManagementServiceTest
    {
        private AccountManagementService? _accountManagementService;
        private readonly Mock<IMathService> _mathService;
        private readonly Mock<IAuthentication> _authentication;
        public AccountManagementServiceTest()
        {
            _mathService = new Mock<IMathService>();
            _authentication = new Mock<IAuthentication>();
        }


        [Fact]
        public async Task AddToBalance_GetValidList_ReturnDecimalAmount()
        {
            //Arrange
            _authentication.Setup(x => x.GetUserByIdAsync(It.IsAny<int>())).ReturnsAsync(UserFaker.GetUser());
            _mathService.Setup(x => x.Sum(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns((decimal)152.6);

            _accountManagementService = new AccountManagementService(_mathService.Object, _authentication.Object);
            //Act
            var result = await _accountManagementService.AddToAmount(1, 10);

            //Assert
            Assert.IsType<decimal>(result);
        }

        [Fact]
        public async Task AddToBalance_UserNotFound_ArgumentNullException()
        {
            //Arrange
            _authentication.Setup(x => x.GetUserByIdAsync(It.IsAny<int>())).ReturnsAsync((User)null);

            _accountManagementService = new AccountManagementService(_mathService.Object, _authentication.Object);

            //Act/Assert
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _accountManagementService.AddToAmount(1, 10));
            Assert.Equal(ex.Result.ParamName, "User not found.");
        }

        [Fact]
        public async Task SubtractValueFromBalance_SubtractfromBalance_ReturnDecimalAmount()
        {
            //Arrange
            var user = UserFaker.GetUser();
            _authentication.Setup(x => x.GetUserByIdAsync(It.IsAny<int>())).ReturnsAsync(user);

            _mathService.Setup(x => x.Subtract(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns((decimal)10);

            _accountManagementService = new AccountManagementService(_mathService.Object, _authentication.Object);
            //Act
            var result = await _accountManagementService.SubtractFromAmount(1, user.CurrentBalance);

            //Assert
            Assert.IsType<decimal>(result);
        }

        [Fact]
        public async Task SubtractValueFromBalance_NotEnoughAmountInBalance_ArgumentNullException()
        {
            //Arrange
            var user = UserFaker.GetUser();
            _authentication.Setup(x => x.GetUserByIdAsync(It.IsAny<int>())).ReturnsAsync(user);

            _accountManagementService = new AccountManagementService(_mathService.Object, _authentication.Object);
            
            //Act/Assert
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _accountManagementService.SubtractFromAmount(1, user.CurrentBalance + 1));
            Assert.Equal(ex.Result.ParamName, "Not enough money in you balance.");
        }

        [Fact]
        public async Task SubtractValueFromBalance_NegativeBalance_ArgumentNullException()
        {
            //Arrange
            var user = UserFaker.GetUser(); user.CurrentBalance = -10;
            _authentication.Setup(x => x.GetUserByIdAsync(It.IsAny<int>())).ReturnsAsync(user);

            _accountManagementService = new AccountManagementService(_mathService.Object, _authentication.Object);

            //Act/Assert
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _accountManagementService.SubtractFromAmount(1, 10));
            Assert.Equal(ex.Result.ParamName, "Not enough money in you balance.");
        }

        [Fact]
        public async Task SubtractValueFromBalance_UserNotFound_ArgumentNullException()
        {
            //Arrange
            var user = UserFaker.GetUser();
            _authentication.Setup(x => x.GetUserByIdAsync(It.IsAny<int>())).ReturnsAsync((User)null);

            _mathService.Setup(x => x.Subtract(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns((decimal)10);

            _accountManagementService = new AccountManagementService(_mathService.Object, _authentication.Object);
            //Act/Assert
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _accountManagementService.SubtractFromAmount(1, 10));
            Assert.Equal(ex.Result.ParamName, "User not found.");
        }
    }
}

