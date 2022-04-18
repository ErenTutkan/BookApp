using BookApp.Core.DTOs;
using BookApp.Repository.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Command.Book.Delete
{
    public class BookDeleteCommandHandler : IRequestHandler<BookDeleteCommand, ResponseDto<NoContent>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BookDeleteCommandHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<NoContent>> Handle(BookDeleteCommand request, CancellationToken cancellationToken)
        {
            var result =await _bookRepository.Delete(request.Id);
            if (result)
            {
                _unitOfWork.Commit();
                return ResponseDto<NoContent>.Success(204);
            }
            return ResponseDto<NoContent>.Fail(new List<string> { "Hatalı Bir İşlem oluştu. Daha sonra tekrar deneyin."},500);

        }
    }
}
