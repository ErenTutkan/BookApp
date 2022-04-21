using AutoMapper;
using BookApp.Core.DTOs.BookDtos;
using BookApp.Core.DTOs.CategoryDtos;
using BookApp.Core.DTOs.ChapterDtos;
using BookApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Chapter, ChapterDto>().ReverseMap();

        }
    }
}
