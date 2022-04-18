using BookApp.Core.DTOs;
using BookApp.Repository.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Command.Category.Insert
{
    public class CategoryInsertCommandHandler : IRequestHandler<CategoryInsertCommand, ResponseDto<int>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryInsertCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<int>> Handle(CategoryInsertCommand request, CancellationToken cancellationToken)
        {
         var result=  await _categoryRepository.Add(request.newCategory);
            _unitOfWork.Commit(); 
            return ResponseDto<int>.Success(result,201);
        }
    }
}
