using BookApp.Core.DTOs;
using BookApp.Repository.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Command.Chapter.Insert
{
    internal class ChapterInsertCommandHandler : IRequestHandler<ChapterInsertCommand, ResponseDto<int>>
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ChapterInsertCommandHandler(IChapterRepository chapterRepository, IUnitOfWork unitOfWork)
        {
            _chapterRepository = chapterRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<int>> Handle(ChapterInsertCommand request, CancellationToken cancellationToken)
        {
            var result = await _chapterRepository.Add(request.newChapter);

            _unitOfWork.Commit();
            return ResponseDto<int>.Success(result,201);
        }
    }
}
