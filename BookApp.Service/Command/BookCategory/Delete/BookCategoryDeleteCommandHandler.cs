using BookApp.Core.DTOs;
using BookApp.Repository.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Command.BookCategory.Delete
{
    public class BookCategoryDeleteCommandHandler : IRequestHandler<BookCategoryDeleteCommand, ResponseDto<NoContent>>
    {
        private readonly IBookCategoryRepository _bookCategoryRepository;

        public BookCategoryDeleteCommandHandler(IBookCategoryRepository? bookCategoryRepository)
        {
            _bookCategoryRepository = bookCategoryRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(BookCategoryDeleteCommand request, CancellationToken cancellationToken)
        {
            var result = await _bookCategoryRepository.Delete(request.Id);
            if (result)
            {
                return ResponseDto<NoContent>.Success(204);
            }
            return ResponseDto<NoContent>.Fail(new List<string> { "Hatalı Bir İşlem Gerçekleşti." }, 500);

        }
    }
}
