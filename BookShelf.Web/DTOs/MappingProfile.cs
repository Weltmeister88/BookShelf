using AutoMapper;
using BookShelf.Core.Models;

namespace BookShelf.Web.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookListingDto>()
                .ForMember(dest => dest.Modified, opt => opt.MapFrom(src => src.ModifiedUtc))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.ToString()))
                .ReverseMap();
            CreateMap<Book, BookEditDto>().ReverseMap();
        }
    }
}