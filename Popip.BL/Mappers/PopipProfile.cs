using AutoMapper;
using Popip.Infrastructure.Dtos;
using Popip.Model.Entities;

namespace Popip.Infrastructure.Mappers
{
    public class PopipProfile : Profile
    {
        public PopipProfile()
        {
            CreateMap<Item, ItemDto>()
                .ForMember(dto => dto.FullName, options => options.MapFrom(entity => $"{entity.Name} - {entity.Description}"))
                .ReverseMap();
        }
    }
}
