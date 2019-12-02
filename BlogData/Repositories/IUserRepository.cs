using BlogData.Entities;
using System.Threading.Tasks;

namespace BlogData.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        UserEntity ForLogin(string username, string password);
    }
}
