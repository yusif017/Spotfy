using AutoMapper;
using Spofy.Business.Abstract;
using Business.AutoMapper;
using Spotfy.Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using Spofy.Business.Concrete;
using Spotfy.Business.Abstract;
using Spotfy.Core.Utilities.MailHelper;
using Spotfy.DataAccess.Abstract;
using Spotfy.DataAccess.Concrete.EntityFramework;
using SpotfyBusiness.Concrete;
using SpotfyDataAccess.Concrete.EntityFramework;
using Sptfy.DataAccsess.Abstract;
using Sptfy.DataAccsess.Concrete.EntityFramework;
using Business.Concrete;

namespace SpotfyBusiness.DependencyResolvers
{
    public static class ServiceRegistration
    {
        public static void Run(this IServiceCollection service)
        {
            service.AddScoped<AppDbContext>();


           service.AddScoped<IUserDAL, EFUserDAL>();
           service.AddScoped<IUserService, UserManager>();


            service.AddScoped<IMusicDAL, EFMusicDAL>();
            service.AddScoped<IMusicService, MusicManager>();

            service.AddScoped<IAlibomDAL, EFAlibomDAL>();
            service.AddScoped<IAlibomService, AlibomManager>();

            service.AddScoped<IAlibomMusicDAL, EFAlibomMusicDAL>();
            service.AddScoped<IAlibomMusicService, AlibomMusicManager>();

            service.AddScoped<IWishListDAL, EFWishListDAL>();
            service.AddScoped<IWishListService, WishListManager>();

            service.AddScoped<IEmailHelper, EmailHelper>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<MappingProfile>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            service.AddSingleton(mapper);
        }
    }
}
