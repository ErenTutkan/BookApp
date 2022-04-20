using BookApp.Core.DTOs;
using BookApp.Core.DTOs.BookDtos;
using BookApp.Repository.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Queries.Book.GetFull
{
    public class GetByIdFullBookQueryHandler : IRequestHandler<GetByIdFullBookQuery, ResponseDto<BookFullDto>>
    {
        private readonly IBookRepository _bookRepository;

        public GetByIdFullBookQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResponseDto<BookFullDto>> Handle(GetByIdFullBookQuery request, CancellationToken cancellationToken)
        {
            var result = await _bookRepository.GetByIdFullBook(request.Id);
            return ResponseDto<BookFullDto>.Success(result);
        }
    }
}
