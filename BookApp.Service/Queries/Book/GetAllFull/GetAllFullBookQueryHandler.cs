using BookApp.Core.DTOs;
using BookApp.Core.DTOs.BookDtos;
using BookApp.Repository.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Queries.Book.GetAllFull
{
    public class GetAllFullBookQueryHandler : IRequestHandler<GetAllFullBookQuery, ResponseDto<List<BookFullDto>>>
    {
        private readonly IBookRepository _bookRepository;

        public GetAllFullBookQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResponseDto<List<BookFullDto>>> Handle(GetAllFullBookQuery request, CancellationToken cancellationToken)
        {
            var result = await _bookRepository.GetFullBook();
            return ResponseDto<List<BookFullDto>>.Success(result,200);
        }
    }
}
