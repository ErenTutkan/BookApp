using BookApp.Core.DTOs;
using BookApp.Repository.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Command.Chapter.Update
{
    public class ChapterUpdateCommandHandler : IRequestHandler<ChapterUpdateCommand, ResponseDto<NoContent>>
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ChapterUpdateCommandHandler(IChapterRepository chapterRepository, IUnitOfWork unitOfWork)
        {
            _chapterRepository = chapterRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<NoContent>> Handle(ChapterUpdateCommand request, CancellationToken cancellationToken)
        {
            var result = await _chapterRepository.Update(request.updateChapter);
            if (result)
            {
                _unitOfWork.Commit();
                return ResponseDto<NoContent>.Success(204);
            }
            return ResponseDto<NoContent>.Fail(new List<string>() { "Hatalı işlem gerçekleşti."},500);
        }
    }
}
