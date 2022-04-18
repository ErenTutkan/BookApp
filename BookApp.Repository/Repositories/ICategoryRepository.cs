using BookApp.Core.DTOs;
using BookApp.Core.DTOs.CategoryDtos;
using BookApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Repository.Repositories
{
    public interface ICategoryRepository
    {
        Task<int> Add(CategoryAddRequestDto request);
        Task<bool> Update(CategoryUpdateRequestDto request);
        Task<bool> Delete(int id);
        Task<List<Category>> GetAll();
        Task<Category> GetById(int id);
    }
}
