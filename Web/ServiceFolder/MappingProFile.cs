using AutoMapper;
using DataAccess.Models;
using Web.Models;

namespace Web.ServiceFolder
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AreaUI, AreaModel>().ReverseMap();
            CreateMap<CinemaUI, CinemaModel>().ReverseMap();
            CreateMap<HallUI, HallModel>().ReverseMap();
            CreateMap<MovieSessionModelUI, MovieSessionModel>().ReverseMap();
            CreateMap<MovieUI, MovieModel>().ReverseMap();
            CreateMap<PlaceSessionUI, PlaceSessionModel>().ReverseMap();
            CreateMap<PlaceUI, PlaceModel>().ReverseMap();
            CreateMap<RowUI, RowModel>().ReverseMap();
            CreateMap<SessionUI, SessionModel>();
            CreateMap<UserUI, UserModel>().ReverseMap();
            CreateMap<CheckUI, Check>().ReverseMap();

        }
    }
}
