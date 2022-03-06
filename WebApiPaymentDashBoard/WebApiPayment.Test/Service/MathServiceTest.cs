using System.Threading.Tasks;
using WebApiBankDashBoard.Services;
using Xunit;

namespace WebApiPayment.Test.Service
{
    public class MathServiceTest
    {
        private MathService? mathService;
        public MathServiceTest() => mathService = new MathService();
        
        [Theory]
        [InlineData(1.0, 2.0, 3.0)]
        [InlineData(-4, -6, -10)]
        [InlineData(-2, 2, 0)]
        public async Task Sum_GetTheResultFromSum_ReturnExpectedValue(decimal x, decimal y, decimal expectedValue)
        {
            //Act
            var result = mathService.Sum(x, y);

            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData(2.0, 1.0, 1.0)]
        [InlineData(4, 4, 0)]
        [InlineData(6, 2 , 4)]
        public async Task Subtract_GetTheResultFromSubtract_ReturnExpectedValue(decimal x, decimal y, decimal expectedValue)
        {
            //Act
            var result = mathService.Subtract(x, y);

            //Assert
            Assert.Equal(expectedValue, result);
        }
    }
}
