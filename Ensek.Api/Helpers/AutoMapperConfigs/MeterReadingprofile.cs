using AutoMapper;
using Ensek.Api.Models.MeterReading;
using Ensek.Data.Entities;

namespace Ensek.Api.Helpers.AutoMapperConfigs
{
    /// <summary>
    /// 
    /// </summary>
    public class MeterReadingProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public MeterReadingProfile()
        {
            CreateMap<MeterReading, MeterReadingModel>()
                .ForMember(dest => dest.MeterReadValue, opt => opt.MapFrom(src => src.ReadValue))
                .ForMember(dest => dest.MeterReadingDateTime, opt => opt.MapFrom(src => src.ReadDate))
                .ReverseMap();

            CreateMap<MeterReading, MeterReadingImportModel>()
                .ForMember(dest => dest.ImportStatus, opt => opt.Ignore())
                .ForMember(dest => dest.ReasonNotImported, opt => opt.Ignore())
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.AccountId))
                .ForMember(dest => dest.MeterReadValue, opt => opt.MapFrom(src => src.ReadValue))
                .ForMember(dest => dest.MeterReadingDateTime, opt => opt.MapFrom(src => src.ReadDate))
                .ReverseMap();

            CreateMap<InvalidMeterReadingModel, MeterReadingModel>();
        }
    }
}
