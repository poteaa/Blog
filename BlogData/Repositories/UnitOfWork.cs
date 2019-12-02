using BlogData.Entities;
using BlogData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogData.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IBlogContext _context;

        public UnitOfWork(IBlogContext context)
        {
            _context = context;
            Posts = new PostRepository(_context);
            Comments = new CommentRepository(_context);
            Users = new UserRepository(_context);
        }

        public IPostRepository Posts { get; }

        public ICommentRepository Comments { get; }

        public IUserRepository Users { get; }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
