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

namespace BookApp.Service.Queries.Chapter.GetAll
{
    public class GetAllChapterQueryHandler : IRequestHandler<GetAllChapterQuery, ResponseDto<List<ChapterDto>>>
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IMapper _mapper;

        public GetAllChapterQueryHandler(IChapterRepository chapterRepository, IMapper mapper)
        {
            _chapterRepository = chapterRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<ChapterDto>>> Handle(GetAllChapterQuery request, CancellationToken cancellationToken)
        {
            var result = await _chapterRepository.GetAll();
            return ResponseDto<List<ChapterDto>>.Success(_mapper.Map<List<ChapterDto>>(result));
        }
    }
}
