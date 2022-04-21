using BookApp.Core.DTOs;
using BookApp.Core.DTOs.ChapterDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Queries.Chapter.GetById
{
    public class GetByIdChapterQuery:IRequest<ResponseDto<ChapterDto>>
    {
        public int Id { get; set; }
    }
}
