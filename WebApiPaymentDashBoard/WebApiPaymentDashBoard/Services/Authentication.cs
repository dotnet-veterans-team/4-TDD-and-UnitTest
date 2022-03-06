using Microsoft.Azure.CosmosRepository;
using WebApiBankDashBoard.Interfaces;
using WebApiBankDashBoard.Model;

namespace WebApiBankDashBoard.Services
{
    public class Authentication : IAuthentication
    {
        private readonly IRepository<User> _userRepository;
        public Authentication(IRepositoryFactory factory)
        {
            _userRepository = factory.RepositoryOf<User>();
        }
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetAsync(userId.ToString());
        }
    }
}
