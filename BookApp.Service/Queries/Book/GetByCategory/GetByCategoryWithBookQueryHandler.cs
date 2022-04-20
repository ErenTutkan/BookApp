using AutoMapper;
using BookApp.Core.DTOs;
using BookApp.Core.DTOs.BookDtos;
using BookApp.Repository.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Queries.Book.GetByCategory
{
    public class GetByCategoryWithBookQueryHandler:IRequestHandler<GetByCategoryWithBookQuery,ResponseDto<List<BookDto>>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetByCategoryWithBookQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<BookDto>>> Handle(GetByCategoryWithBookQuery request, CancellationToken cancellationToken)
        {
            var result = await _bookRepository.GetByCategory(request.CategoryId);
            return ResponseDto<List<BookDto>>.Success(_mapper.Map<List<BookDto>>(result));
        }
    }
}
