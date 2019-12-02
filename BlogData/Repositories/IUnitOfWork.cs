using System;
using System.Threading.Tasks;

namespace BlogData.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository Posts { get; }

        Task<int> Commit();
    }
}
