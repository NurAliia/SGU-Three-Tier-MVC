using System;
using System.Collections.Generic;
using Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgu.StudentTesting.DAL.Contracts
{
    public interface ICommentDao
    {
        int AddComment(Comment comment);
        IEnumerable<Comment> GetCommentsByAuthor(int idUser);
        IEnumerable<Comment> GetCommentsByShop(int idShop);
        IEnumerable<Comment> GetCommentsByDate(DateTime date);
        Comment GetCommentById(int idComment);
        bool UpdateComment(Comment comment);
        bool DeleteById(int idComment);
    }
}
