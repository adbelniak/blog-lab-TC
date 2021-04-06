using System.Linq;
using System.Collections.Generic;
using Blog.DAL.Infrastructure;
using Blog.DAL.Model;
using System;

namespace Blog.DAL.Repository
{
    public class BlogRepository
    {
        private readonly BlogContext _context;

        public BlogRepository()
        {
            _context = new BlogContext();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts;
        }
        public IEnumerable<Comment> GetAllComments()
        {
            return _context.Comments;
        }

        public void AddPost(Post post)
        {
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            context.Posts.Add(post);
            context.SaveChanges();
        }
        public void AddComment(Comment comment)
        {
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            context.Comments.Add(comment);
            context.SaveChanges();
        }

        public IEnumerable<Comment> GetCommentByPost(long postid)
        {
            var u = from comment in _context.Comments where comment.PostId == postid select comment;
            return u;
            
        }
    }
}
