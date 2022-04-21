using BookApp.Core.DTOs.ChapterDtos;
using BookApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Repository.Repositories
{
    public  interface IChapterRepository
    {
        Task<int> Add(ChapterAddRequestDto newChapter);
        Task<bool> Delete(int id);
        Task<bool> Update(ChapterUpdateRequestDto updateChapter);
        Task<List<Chapter>> GetAll();
        Task<List<Chapter>> GetByBookId(int bookid);
        Task<Chapter> GetById(int id);
    }
}
