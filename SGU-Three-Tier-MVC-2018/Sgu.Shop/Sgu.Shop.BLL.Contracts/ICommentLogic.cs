using System;
using System.Collections.Generic;
using Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgu.StudentTesting.BLL.Contracts
{
    public interface ICommentLogic
    {
        void AddComment(Comment comment);
        IEnumerable<Comment> GetCommentsByAuthor(int idUser);
        IEnumerable<Comment> GetCommentsByShop(int idShop);
        IEnumerable<Comment> GetCommentsByDate(DateTime date);
        Comment GetCommentById(int idComment);
        void UpdateComment(Comment comment);
        void DeleteById(int idComment);
    }
}
