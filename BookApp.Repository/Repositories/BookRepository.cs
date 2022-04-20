using BookApp.Core.DTOs.BookCategoryDtos;
using BookApp.Core.DTOs.BookDtos;
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
    public class BookRepository : IBookRepository
    {
        private readonly IDbConnection _connection;

        public BookRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> Add(BookAddRequestDto request)
        {
            var command = "func_insert_book";
            return await _connection.ExecuteScalarAsync<int>(command, new {
                b_name = request.Name,
                b_description = request.Description,
                b_author = request.Author,
                b_picture = request.BookPicture
            }, commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> Delete(int id)
        {
            var command = "call sp_delete_book(@id)";
            var result = await _connection.ExecuteAsync(command, new { id = id });
            return result == -1;
        }

        public async Task<List<Book>> GetAll()
        {
            var command = "func_getall_books";
            var result=await _connection.QueryAsync<Book>(command,commandType:CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Book> GetById(int id)
        {
            var command = "func_getbyid_books";
            var result = await _connection.QuerySingleAsync<Book>(command,new { b_id = id }, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<BookFullDto> GetByIdFullBook(int id)
        {
            var query = $"select * from func_getbyid_fullbook({id})";
            var result = await _connection.QueryAsync<BookFullDto, BookCategoryDto, BookFullDto>(query, (book, categories) =>
            {

                BookFullDto bookFullDto = null;
                if (bookFullDto == null)
                {
                    bookFullDto = new BookFullDto();
                    bookFullDto.Id = book.Id;
                    bookFullDto.BookName = book.BookName;
                    bookFullDto.Author = book.Author;
                    bookFullDto.Description = book.Description;
                    bookFullDto.BookPicture = book.BookPicture;
                }


                if (categories != null)
                {
                    if (!bookFullDto.Categories.Any(x => x.BcId == categories.BcId))
                    {
                        bookFullDto.Categories.Add(categories);
                    }
                }

                return bookFullDto;

            }, splitOn: "bcid");

            List<BookFullDto> bookFullDto = new List<BookFullDto>();
            foreach (var item in result)
            {
                if (!bookFullDto.Any(x => x.Id == item.Id))
                {
                    bookFullDto.Add(item);
                }
                else
                {
                    var book = bookFullDto.First(x => x.Id == item.Id);

                    if (!book.Categories.Any(x => x.BcId == item.Categories.First().BcId))
                    {
                        book.Categories.Add(item.Categories.First());
                    }
                }
            }
            return bookFullDto.First();
        }

        public async Task<List<BookFullDto>> GetFullBook()
        {
            var query = "select * from get_full_book";
            var result = await _connection.QueryAsync<BookFullDto, BookCategoryDto, BookFullDto>(query, (book, categories) =>
            {

                BookFullDto bookFullDto=null;
                if(bookFullDto == null)
                {
                    bookFullDto = new BookFullDto();
                    bookFullDto.Id = book.Id;
                    bookFullDto.BookName = book.BookName;
                    bookFullDto.Author = book.Author;
                    bookFullDto.Description = book.Description;
                    bookFullDto.BookPicture = book.BookPicture;
                }
               

                if (categories != null)
                {
                    if (!bookFullDto.Categories.Any(x => x.BcId == categories.BcId))
                    {
                        bookFullDto.Categories.Add(categories);
                    }
                }
                
                return bookFullDto;
                
            },splitOn:"bcid");

            List<BookFullDto> bookFullDto = new List<BookFullDto>();
            foreach (var item in result)
            {
                if (!bookFullDto.Any(x => x.Id == item.Id))
                {
                    bookFullDto.Add(item);
                }
                else
                {
                    var book=bookFullDto.First(x=>x.Id==item.Id);

                    if (!book.Categories.Any(x=>x.BcId==item.Categories.First().BcId))
                    {
                        book.Categories.Add(item.Categories.First());
                    }
                }
            }
            return bookFullDto.ToList();
        }

        public async Task<bool> Update(BookUpdateRequestDto request)
        {
            var command = "call sp_update_book(@id,@name,@description,@author,@bookpicture)";
            var result = await _connection.ExecuteAsync(command,request);
            return  result== -1;
        }
    }
}
