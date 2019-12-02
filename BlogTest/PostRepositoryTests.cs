using BlogData;
using BlogData.Entities;
using BlogData.Repositories;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BlogTest
{
    [TestFixture]
    public class PostRepositoryTests
    {
        IBlogContext _context;
        IPostRepository _repository;

        [SetUp]
        public void SetUp()
        {
            var mock = Substitute.For<IDbSet<PostEntity>>();
            var queryablePosts = RepositoryMock.Posts.AsQueryable();
            mock.Provider.Returns(queryablePosts.Provider);
            mock.Expression.Returns(queryablePosts.Expression);
            mock.ElementType.Returns(queryablePosts.ElementType);
            mock.GetEnumerator().Returns(queryablePosts.GetEnumerator());
            _context = Substitute.For<IBlogContext>();
            _context.Posts.Returns(mock);
            _repository = new PostRepository(_context);
        }

        [Test]
        public async Task TestMethodAsync()
        {
            // Arrange


            // Act
            //Func<Task> f = async () => await (List<PostEntity>)_repository.GetPendingAprrovalPosts();
            IEnumerable<PostEntity> a = await _repository.GetPendingAprrovalPosts();
            //var result = f();

            // Assert
            a.ToList().Should().HaveCount(RepositoryMock.Posts.Count);
        }
    }
}
