using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Sgu.StudentTesting.Config;
using Sgu.StudentTesting.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.UnitTest
{
    [TestClass]
    class CommentLogicTest
    {
        [TestMethod]
        public void CreateComment()
        {
            var kernel = new StandardKernel();
            Config.RegisterServices(kernel);
            var commentLogic = kernel.Get<ICommentDao>("Fake");
            Comment oldComment = new Comment()
            {
                IDUser = 1,
                Text = "nice shop assistance",
                IDShop = 1
            };
            var result = commentLogic.AddComment(oldComment);
            var comment = commentLogic.GetCommentById(result);
            Assert.IsNotNull(comment,"Comment is null");
            Assert.AreEqual(oldComment.Text, comment.Text, "Не совпали комменты при добавлении");
        }
        [TestMethod]
        public void GetCommentByShop()
        {
            var kernel = new StandardKernel();
            Config.RegisterServices(kernel);
            var commentLogic = kernel.Get<ICommentDao>("Fake");
           
            var result = commentLogic.GetCommentsByShop(1);

            Assert.IsInstanceOfType(result, typeof(List<Comment>));
        }
        [TestMethod]
        public void GetCommentById()
        {
            var kernel = new StandardKernel();
            Config.RegisterServices(kernel);
            var commentLogic = kernel.Get<ICommentDao>("Fake");
           
            var result = commentLogic.GetCommentById(1);

            Assert.IsNotNull(result,"Comment is null");
        }
        [TestMethod]
        public void DeleteById()
        {
            var kernel = new StandardKernel();
            Config.RegisterServices(kernel);
            var commentLogic = kernel.Get<ICommentDao>("Fake");                        
            Assert.IsTrue(commentLogic.DeleteById(1));
        }
    }
}
