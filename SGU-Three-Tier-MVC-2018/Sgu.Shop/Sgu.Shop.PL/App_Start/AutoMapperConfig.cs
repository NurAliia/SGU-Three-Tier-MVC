using AutoMapper;
using Common;
using Sgu.StudentTesting.PL.ViewModel.Comment;
using Sgu.StudentTesting.PL.ViewModel.Shop;
using Sgu.StudentTesting.PL.ViewModels.User;
using System;
using System.Web;

namespace Sgu.StudentTesting.PL.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserDisplayVM>();

                cfg.CreateMap<UserCreateVM, User>()
                    .ForMember(dest => dest.IDUser, opt => opt.Ignore());

                cfg.CreateMap<User, UserCreateVM>();

                cfg.CreateMap<UserCreateVM, UserDisplayVM>()
                  .ForMember(dest => dest.IDUser, opt => opt.Ignore());

                cfg.CreateMap<ShopDisplayVM, Shop>()
                  .ForMember(dest => dest.Moderator, opt => opt.Ignore());

                cfg.CreateMap<ShopCreateVM, Shop>()
                    .ForMember(dest => dest.OpeningHours, opt => opt.MapFrom(src=>src.OpenHours + '-' + src.CloseHours));

                cfg.CreateMap<Shop, ShopCreateVM>()
                    .ForMember(dest => dest.OpenHours, opt => opt.MapFrom(src => src.GetOpeningHours(src, 0)))
                    .ForMember(dest => dest.CloseHours, opt => opt.MapFrom(src => src.GetOpeningHours(src, 1)));

                cfg.CreateMap<CommentCreateVM, Comment>()
                    .ForMember(dest => dest.IDComment, opt => opt.Ignore())
                    .ForMember(dest => dest.NameUser, opt => opt.Ignore());

            });
            Mapper.Configuration.AssertConfigurationIsValid();
            Mapper.AssertConfigurationIsValid();
        }
    }
}