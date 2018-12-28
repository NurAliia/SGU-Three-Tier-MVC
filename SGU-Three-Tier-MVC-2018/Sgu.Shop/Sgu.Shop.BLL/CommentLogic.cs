using Common;
using Sgu.StudentTesting.BLL.Contracts;
using Sgu.StudentTesting.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sgu.StudentTesting.BLL
{
    public class CommentLogic: ICommentLogic
    {
        private readonly ICommentDao _commentDao;

        public CommentLogic(ICommentDao commentDao)
        {
            _commentDao = commentDao;
        }

        public void AddComment(Comment comment)
        {
            _commentDao.AddComment(comment);
        }

        public IEnumerable<Comment> GetCommentsByAuthor(int idUser)
        {
            return _commentDao.GetCommentsByAuthor(idUser);
        }
        public IEnumerable<Comment> GetCommentsByShop(int idShop)
        {
            return _commentDao.GetCommentsByShop(idShop);
        }
        public IEnumerable<Comment> GetCommentsByDate(DateTime date)
        {
            return _commentDao.GetCommentsByDate(date);
        }
        public Comment GetCommentById(int idComment)
        {
            return _commentDao.GetCommentById(idComment);
        }
        public void UpdateComment(Comment comment)
        {
            _commentDao.UpdateComment(comment);
        }
        public void DeleteById(int idComment)
        {
            _commentDao.DeleteById(idComment);
        }
    }
}
