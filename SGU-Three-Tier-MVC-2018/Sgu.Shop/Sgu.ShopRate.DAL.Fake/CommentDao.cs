using Common;
using Sgu.StudentTesting.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sgu.ShopRate.DAL.Fake
{
    public class CommentDao : ICommentDao
    {
        private static Dictionary<int, Comment> _storageComment = new Dictionary<int, Comment>();

        public int AddComment(Comment comment)
        {
            int max = 0;
            if (_storageComment.Any())
            {
                max = _storageComment.Values.Max(Item => Item.IDShop);
            }
            comment.IDShop = ++max;
            _storageComment.Add(comment.IDShop, comment);
            return max;
        }
        public IEnumerable<Comment> GetCommentsByAuthor(int idUser)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Comment> GetCommentsByShop(int idShop)
        {
            return _storageComment.Values.Where(item=>item.IDShop==idShop);
        }
        public IEnumerable<Comment> GetCommentsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }
        public Comment GetCommentById(int idComment)
        {
            if (!_storageComment.TryGetValue(idComment, out var result))
            {
                result = null;
            }
            return result;
        }
        public bool UpdateComment(Comment comment)
        {
            throw new NotImplementedException();
        }
        public bool DeleteById(int idComment)
        {
            return _storageComment.Remove(idComment);
        }
    }
}
