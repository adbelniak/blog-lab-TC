using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using Blog.DAL.Infrastructure;
using Blog.DAL.Model;
using Blog.DAL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using TDD.DbTestHelpers.Core;
using System.Data.Entity.Validation;

namespace Blog.DAL.Tests
{
    [TestClass]
    public class RepositoryTests : DbBaseTest<BlogFixtures>
    {
     

        [TestMethod]
        public void GetAllPost_OnePostInDb_ReturnOnePost()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            BaseSetUp();

            var repository = new BlogRepository();
            // act
            var result = repository.GetAllPosts();
            // assert
            Assert.AreEqual(2, result.Count());
        }
    

        [TestMethod]
        public void AddPost_ReturnThreePost()
        {
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();
            Post post1 = new Post
            {
                Author = "test3",
                Content = "test3content"
            };
            repository.AddPost(post1);
            context.SaveChanges();
            var result = repository.GetAllPosts();
            Assert.AreEqual(3, result.Count());
        }
        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void AddPost_PostWithoutContentWithException()
        {
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();
            Post post1 = new Post();
            repository.AddPost(post1);
        }


        [TestMethod]
        public void AddComment_TwoCommentsInDb_ReturnThreeComments()
        {
            var context = new BlogContext();
            var repository = new BlogRepository();
            Comment comment1 = new Comment
            {
                Author = "Adam",
                Content = "comment",
                PostId = 1
            };
            repository.AddComment(comment1);
            var result = repository.GetAllComments();
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void GetCommentsByPostId_ReturnOneComemnt()
        {
            var context = new BlogContext();
            var repository = new BlogRepository();
            var result = repository.GetCommentByPost(2);
            Assert.AreEqual(1, result.Count());
        }


    }
}
