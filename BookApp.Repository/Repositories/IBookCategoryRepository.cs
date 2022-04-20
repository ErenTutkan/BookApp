using BookApp.Core.DTOs.BookCategoryDtos;
using BookApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Repository.Repositories
{
    public interface IBookCategoryRepository
    {
        Task Add(BookCategoryAddRequestDto request);
        Task<bool> Delete(int id);
    }
}
