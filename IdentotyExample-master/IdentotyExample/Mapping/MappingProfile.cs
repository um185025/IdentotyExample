using AlohaAPIExample.Models.Dto;
using AutoMapper;

namespace AlohaAPIExample.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Root, OutRootDTO>();
            CreateMap<RootLL, OutRootLLDTO>();
            CreateMap<RootMenus, OutRootMenusDTO>();
            CreateMap<RootOrder, OutRootOrderDTO>();
            CreateMap<InOrderDTO, Order>()
                .ForMember(dest => dest.SiteId, opt => opt.MapFrom(src => src.InOrderSiteId));
            CreateMap<NearbySite, OutNearbySiteDTO>();
        }
    }
}
