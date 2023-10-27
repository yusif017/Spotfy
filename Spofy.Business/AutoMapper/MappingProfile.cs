
using AutoMapper;
using Entities.DTOs.WishListDTO;
using Spotfy.Entities.Concreate;
using Spotfy.Entities.Concrete;
using Spotfy.Entities.DTOs.AlibomDTOs;
using Spotfy.Entities.DTOs.AlibomMusicDtos;
using Spotfy.Entities.DTOs.MusicDTOs;
using Spotfy.Entities.DTOs.UserDTOs;
using Spotfy.Entities.DTOs.WishListDTO;

namespace Business.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<UserLoginDTO, User>().ReverseMap();
            CreateMap<UserRegisterDTO, User>().ReverseMap();

            CreateMap<AlibomMusicListAddDto, AlibomMusic>();


            CreateMap<WishListAddItemDTO, WishList>().ReverseMap();
            CreateMap<WishList, WishListItemDTO>()
            .ForMember(x => x.Title, o => o.MapFrom(s => s.Music.Title));

            CreateMap<MusicCreateDTO, Music>().ReverseMap();

            CreateMap<AlibomCreateDTO, Alibom>().ReverseMap();

        }
    }
}
