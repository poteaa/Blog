using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BlogData.Entities;

namespace BlogData.Repositories
{
    internal class UserRepository : Repository<UserEntity>, IUserRepository
    {
        private IBlogContext _context;
        public UserRepository(IBlogContext context) : base(context)
        {
            _context = context;
        }

        public UserEntity ForLogin(string username, string password)
        {
            return  _context.Users
                .Include(u => u.Role)
                .Where(u => u.Username == username && u.Password == password).FirstOrDefault();
        }
    }
}
