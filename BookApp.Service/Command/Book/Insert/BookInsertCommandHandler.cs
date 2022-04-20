using BookApp.Core.DTOs;
using BookApp.Core.DTOs.BookCategoryDtos;
using BookApp.Repository.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Command.Book.Insert
{
    public class BookInsertCommandHandler : IRequestHandler<BookInsertCommand, ResponseDto<int>>
    {
        private readonly IBookCategoryRepository _bookCategoryRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BookInsertCommandHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork, IBookCategoryRepository bookCategoryRepository)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
            _bookCategoryRepository = bookCategoryRepository;
        }

        public async Task<ResponseDto<int>> Handle(BookInsertCommand request, CancellationToken cancellationToken)
        {
            var result =await _bookRepository.Add(request.newBook);
            foreach (var categoryid in request.newBook.Categories)
            {
                await _bookCategoryRepository.Add(new BookCategoryAddRequestDto() { BookId=result,CategoryId=categoryid});
            }

            _unitOfWork.Commit();
            return ResponseDto<int>.Success(result, 201);
        }
    }
}
