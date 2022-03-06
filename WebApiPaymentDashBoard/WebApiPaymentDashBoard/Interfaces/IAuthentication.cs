using WebApiBankDashBoard.Model;

namespace WebApiBankDashBoard.Interfaces
{
    public interface IAuthentication
    {
        Task<User> GetUserByIdAsync(int userId);
    }
}
