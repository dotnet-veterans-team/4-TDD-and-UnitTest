using Microsoft.Azure.CosmosRepository;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using WebApiBankDashBoard.Model;
using WebApiPayment.Test._Ultil;
using WebApiBankDashBoard.Services;
using Xunit;

namespace WebApiPayment.Test.Service
{
    public  class AuthenticationTest
    {
        private Authentication? _authentication;
       
        private readonly Mock<IRepositoryFactory> _userRepository;
        public AuthenticationTest()
        {
            _userRepository = new Mock<IRepositoryFactory>();
        }

        [Fact]
        public async Task GetUserByIdAsync_GetValidUser_ReturnUser()
        {
            //Arrange
            var userFake = UserFaker.GetUser();
            _userRepository.Setup(x => x.RepositoryOf<User>().GetAsync(It.IsAny<string>(), null, It.IsAny<CancellationToken>()))
                                        .ReturnsAsync(userFake);

            _authentication = new Authentication(_userRepository.Object);
            //Act
            var result = await _authentication.GetUserByIdAsync(1);

            //Assert
            Assert.Equal(userFake, result);
        }

    }
}
