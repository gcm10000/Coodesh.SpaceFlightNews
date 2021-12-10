using Coodesh.SpaceFlightNews.DTO;
using Coodesh.SpaceFlightNews.ViewModel;
using System;

namespace Coodesh.SpaceFlightNews.Services
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<ViewModel.Article, DTO.Article>()
                .ForMember(destination => destination.IdAPI, 
                                   map => map.MapFrom(source => source.Id))
                .ForMember(destination => destination.Id, 
                               options => options.Ignore());

            CreateMap<DTO.Article, ViewModel.Article>()
                .ForMember(destination => destination.Id,
                                   map => map.MapFrom(source => source.Id));


            CreateMap<ViewModel.Event, DTO.Event>()
                .ForMember(destination => destination.Id,
                               options => options.Ignore()).ReverseMap();

            CreateMap<ViewModel.Launch, DTO.Launch>()
                .ForMember(destination => destination.Id,
                               options => options.Ignore()).ReverseMap();
        }
    }
}
