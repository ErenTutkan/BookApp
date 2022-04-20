using BookApp.Core.DTOs.BookCategoryDtos;
using BookApp.Core.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Repository.Repositories
{
    public class BookCategoryRepository : IBookCategoryRepository
    {
        private readonly IDbConnection _connection;

        public BookCategoryRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task Add(BookCategoryAddRequestDto request)
        {
            var command = $"call sp_book_category_insert({request.BookId},{request.CategoryId})";
            var result = await _connection.ExecuteAsync(command, request);
            
        }

        public async Task<bool> Delete(int id)
        {
            var command = $"delete from books_categories where id={id}";
            var result=await _connection.ExecuteAsync(command, null)>0;
            return result;

        }

    }
}
