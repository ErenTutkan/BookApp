using BookApp.Core.Models;
using BookApp.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.Core.DTOs.CategoryDtos;
using System.Data;
using Dapper;

namespace BookApp.Repository.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbConnection _connection;

        public CategoryRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> Add(CategoryAddRequestDto request)
        {
            var command= "func_category_create";
            return await _connection.ExecuteScalarAsync<int>(command,new {category_name=request.CategoryName},commandType:CommandType.StoredProcedure);

        }

        public async Task<bool> Delete(int id)
        {
            var command = "call sp_category_delete(@id)";
            var result=await _connection.ExecuteAsync(command,new {id=id});
            return true;
        }

        public async Task<Category> GetById(int id)
        {
            var command = "func_getbyid_category";
            var result=await _connection.QuerySingleAsync<Category>(command,new {c_id=id}, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<List<Category>> GetAll()
        {
            var command = "func_getall_category";
            var result= await _connection.QueryAsync<Category>(command, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<bool> Update(CategoryUpdateRequestDto request)
        {
            var command = "call sp_category_update(@id,@categoryname)";
            var result=await _connection.ExecuteAsync(command,request);
            return true;
        }
    }
}
