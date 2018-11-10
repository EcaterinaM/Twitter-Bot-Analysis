using AutoMapper;
using DataDomain.DataModel;
using DomainModels.Models.Twitter;

namespace Infrastructure.Automapper.Profiles
{
    class HashtagHistoryProfile : Profile
    {
        public HashtagHistoryProfile()
        {
            CreateMap<HashtagHistory, HashtagHistoryModel>()
                .ForMember(s => s.HashtagValue, opt => opt.MapFrom(src => src.HashtagValue))
                .ForMember(s => s.NegativeSentimentCounter, opt => opt.MapFrom(src => src.NegativeSentimentCounter))
                .ForMember(s => s.NeutralSentimentCounter, opt => opt.MapFrom(src => src.NeutralSentimentCounter))
                .ForMember(s => s.PositiveSentimentCounter, opt => opt.MapFrom(src => src.PositiveSentimentCounter))
                .ForMember(s => s.SearchTime, opt => opt.MapFrom(src => src.SearchTime))
                .ReverseMap();
        }
    }
}
