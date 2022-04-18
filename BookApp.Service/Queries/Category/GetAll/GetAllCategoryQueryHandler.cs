using AutoMapper;
using BookApp.Core.DTOs;
using BookApp.Core.DTOs.CategoryDtos;
using BookApp.Repository.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Queries.Category.GetAll
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, ResponseDto<List<CategoryDto>>>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAll();
            return ResponseDto<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(result),200);
        }
    }
}
