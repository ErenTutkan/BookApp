using BookApp.Core.DTOs;
using BookApp.Repository.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Command.Book.Update
{
    public class BookUpdateCommandHandler : IRequestHandler<BookUpdateCommand, ResponseDto<NoContent>>
    {

        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BookUpdateCommandHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<NoContent>> Handle(BookUpdateCommand request, CancellationToken cancellationToken)
        {
            var result =await _bookRepository.Update(request.updateBook);
            if (result)
            {
                _unitOfWork.Commit();
                return ResponseDto<NoContent>.Success(204);
            }
            return ResponseDto<NoContent>.Fail(new List<string> { "Hatalı Bir İşlem oluştu. Daha sonra tekrar deneyin." }, 500);
        }
    }
}
