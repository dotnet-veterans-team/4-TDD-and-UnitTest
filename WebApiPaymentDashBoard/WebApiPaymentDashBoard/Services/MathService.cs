using WebApiBankDashBoard.Interfaces;

namespace WebApiBankDashBoard.Services
{
    public class MathService : IMathService
    {
        public decimal Subtract(decimal x, decimal y) => x - y;

        public decimal Sum(decimal x, decimal y) => x + y;
    }
}
