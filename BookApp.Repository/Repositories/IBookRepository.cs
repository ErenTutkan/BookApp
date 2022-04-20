using BookApp.Core.DTOs.BookDtos;
using BookApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Repository.Repositories
{
    public interface IBookRepository
    {
        Task<int> Add(BookAddRequestDto request);
        Task<bool> Update(BookUpdateRequestDto request);
        Task<bool> Delete(int id);
        Task<List<Book>> GetAll();
        Task<Book> GetById(int id);
        Task<List<BookFullDto>> GetFullBook();
        Task<BookFullDto> GetByIdFullBook(int id);
    }
}
