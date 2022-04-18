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

namespace BookApp.Service.Queries.Book.GetAll
{
    public class GetAllBookQueryHandler : IRequestHandler<GelAllBookQuery, ResponseDto<List<BookDto>>>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public GetAllBookQueryHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<BookDto>>> Handle(GelAllBookQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAll();
            return ResponseDto<List<BookDto>>.Success(_mapper.Map<List<BookDto>>(result), 200);
        }
    }
}
