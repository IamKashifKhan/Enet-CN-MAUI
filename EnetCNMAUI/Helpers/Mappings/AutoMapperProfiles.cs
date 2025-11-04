using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EnetCNMAUI.Domain.Models.MVC;

namespace EnetCNMAUI.Helpers.Mappings
{
    public class AutoMapperProfiles : AutoMapper.Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<OffersMapItem, BusinessOfferItem>()
        // Convert DateTime to string for Timestamp
        .ForMember(dest => dest.Timestamp,
                   opt => opt.MapFrom(src => src.Timestamp.ToString("O"))) // ISO 8601 format

        // Convert int isFavorite/isUsed into bool
        .ForMember(dest => dest.isFavorite,
                   opt => opt.MapFrom(src => src.isFavorite == 1))
        .ForMember(dest => dest.isUsed,
                   opt => opt.MapFrom(src => src.isUsed == 1))

        // Make StartDate nullable (map directly)
        .ForMember(dest => dest.StartDate,
                   opt => opt.MapFrom(src => (DateTime?)src.StartDate))

        // Handle IsActivePlan, IsActivePlane, ShowRedemptionLabel, IsRedeemable manually (defaults)
        .ForMember(dest => dest.IsActivePlan, opt => opt.Ignore())
        .ForMember(dest => dest.IsActivePlane, opt => opt.Ignore())
        .ForMember(dest => dest.ShowRedemptionLabel, opt => opt.Ignore())
        .ForMember(dest => dest.IsRedeemable, opt => opt.Ignore())

        // Ignore BusinessCategory if it needs to be populated separately
        .ForMember(dest => dest.BusinessCategory, opt => opt.Ignore());
        }
    }

}
