using Sgu.StudentTesting.BLL;
using Sgu.StudentTesting.BLL.Contracts;
using Ninject;
using Sgu.StudentTesting.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sgu.StudentTesting.DAL.Contracts;

namespace Sgu.StudentTesting.Config
{
    public static class Config
    {

        public static void RegisterServices(StandardKernel kernel)
        {
            kernel.Bind<IUserLogic>().To<UserLogic>();
            kernel.Bind<IUserDao>().To<UserDao>();

            kernel.Bind<IShopLogic>().To<ShopLogic>().InSingletonScope();
            kernel.Bind<IShopDao>().To<ShopDao>().InSingletonScope();

            kernel.Bind<ICommentLogic>().To<CommentLogic>().InSingletonScope();
            kernel.Bind<ICommentDao>().To<CommentDao>().InSingletonScope();

            kernel.Bind<IRatingLogic>().To<RatingLogic>().InSingletonScope();
            kernel.Bind<IRatingDao>().To<RatingDao>().InSingletonScope();
        }
    }
}
