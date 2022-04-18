using BookApp.Core.DTOs;
using BookApp.Repository.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Command.Category.Update
{
    internal class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, ResponseDto<NoContent>>
    {
        private readonly ICategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryUpdateCommandHandler(ICategoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<NoContent>> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
        {
            var result=await _repository.Update(request.updateCategory);
            if (result)
            {
                _unitOfWork.Commit();
                return ResponseDto<NoContent>.Success(204);
            }
            return ResponseDto<NoContent>.Fail(new List<string> { "Hata Güncelleme Gerçekleşemedi" }, 500);
            
           
        }
    }
}
