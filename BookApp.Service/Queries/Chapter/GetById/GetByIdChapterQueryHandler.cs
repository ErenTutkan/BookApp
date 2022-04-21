using AutoMapper;
using BookApp.Core.DTOs;
using BookApp.Core.DTOs.ChapterDtos;
using BookApp.Repository.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Queries.Chapter.GetById
{
    public class GetByIdChapterQueryHandler : IRequestHandler<GetByIdChapterQuery, ResponseDto<ChapterDto>>
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IMapper _mapper;

        public GetByIdChapterQueryHandler(IChapterRepository chapterRepository, IMapper mapper)
        {
            _chapterRepository = chapterRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ChapterDto>> Handle(GetByIdChapterQuery request, CancellationToken cancellationToken)
        {
           var result=await _chapterRepository.GetById(request.Id);
            return ResponseDto<ChapterDto>.Success(_mapper.Map<ChapterDto>(result));
        }
    }
}
