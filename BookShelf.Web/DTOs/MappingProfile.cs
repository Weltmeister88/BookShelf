using AutoMapper;
using BookShelf.Core.Models;

namespace BookShelf.Web.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, AuthorAddDto>().ReverseMap();
        }
    }
}