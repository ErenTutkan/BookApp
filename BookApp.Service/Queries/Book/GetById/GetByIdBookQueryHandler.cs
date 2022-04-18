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

namespace BookApp.Service.Queries.Book.GetById
{
    public class GetByIdBookQueryHandler : IRequestHandler<GetByIdBookQuery, ResponseDto<BookDto>>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdBookQueryHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<BookDto>> Handle(GetByIdBookQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetById(request.Id);
            return ResponseDto<BookDto>.Success(_mapper.Map<BookDto>(result), 200);

        }
    }
}
