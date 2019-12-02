using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using BlogData.Entities;

namespace BlogData
{
    public interface IBlogContext : IDisposable
    {
        DbSet<CommentEntity> Comments { get; set; }
        DbSet<PostEntity> Posts { get; set; }
        DbSet<RoleEntity> Roles { get; set; }
        DbSet<UserEntity> Users { get; set; }

        Task<int> SaveChangesAsync();
        DbEntityEntry Entry(object entity);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet Set(Type entityType);
    }
}