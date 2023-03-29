using AutoMapper;
using BusinessLogic.LogicBusiness.Area;
using BusinessLogic.LogicBusiness.Cinema;
using BusinessLogic.LogicBusiness.Hall;
using BusinessLogic.LogicBusiness.Movie;
using BusinessLogic.LogicBusiness.Place;
using BusinessLogic.LogicBusiness.PlaceSession;
using BusinessLogic.LogicBusiness.ResultChek;
using BusinessLogic.LogicBusiness.Row;
using BusinessLogic.LogicBusiness.Session;
using BusinessLogic.LogicBusiness.User;
using DataAccess.Repositories.Area;
using DataAccess.Repositories.Cinema;
using DataAccess.Repositories.Hall;
using DataAccess.Repositories.Movie;
using DataAccess.Repositories.Place;
using DataAccess.Repositories.PlaceSession;
using DataAccess.Repositories.ResultChek;
using DataAccess.Repositories.Row;
using DataAccess.Repositories.Session;
using DataAccess.Repositories.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Web.ServiceFolder
{
    public static class ServicesExtension
    {
        public static void RegisterRepositoriesExtension(this IServiceCollection service, IConfiguration config)
        {
            string connectionString = config.GetConnectionString("TestShop");

            service.AddSingleton<IAreaRepository, AreaRepository>(x => new AreaRepository(connectionString));
            service.AddSingleton<ICinemaRepository, CinemaRepository>(x => new CinemaRepository(connectionString));
            service.AddSingleton<IHallRepository, HallRepository>(x => new HallRepository(connectionString));
            service.AddSingleton<IMovieRepository, MovieRepository>(x => new MovieRepository(connectionString));
            service.AddSingleton<IPlaceRepository, PlaceRepository>(x => new PlaceRepository(connectionString));
            service.AddSingleton<IPlaceSessionRepository, PlaceSessionRepository>(x => new PlaceSessionRepository(connectionString));
            service.AddSingleton<IRowRepository, RowRepository>(x => new RowRepository(connectionString));
            service.AddSingleton<ISessionRepository, SessionRepository>(x => new SessionRepository(connectionString));
            service.AddSingleton<IUserRepository, UserRepository>(x => new UserRepository(connectionString));
            service.AddSingleton<IGetResultCheckRepository, GetResultCheckRepository>(x => new GetResultCheckRepository(connectionString));

        }

        public static void ServicesConfigurationExtension(this IServiceCollection service)
        {
            service.AddTransient<IAreaLogic, AreaLogic>();
            service.AddTransient<ICinemaLogic, CinemaLogic>();
            service.AddTransient<IHallLogic, HallLogic>();
            service.AddTransient<IMovieLogic, MovieLogic>();
            service.AddTransient<IPlaceLogic, PlaceLogic>();
            service.AddTransient<IPlaceSessionLogic, PlaceSessionLogic>();
            service.AddTransient<IRowLogic, RowLogic>();
            service.AddTransient<ISessionLogic, SessionLogic>();
            service.AddTransient<IUserLogic, UserLogic>();
            service.AddTransient<IGetResultCheckLogic, GetResultCheckLogic>();
        }
    }
}
