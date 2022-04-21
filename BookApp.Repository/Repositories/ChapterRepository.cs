using BookApp.Core.DTOs.ChapterDtos;
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
    public class ChapterRepository : IChapterRepository
    {
        private readonly IDbConnection _connection;

        public ChapterRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> Add(ChapterAddRequestDto newChapter)
        {
            var command = "func_insert_chapter";
            var result=await _connection.ExecuteScalarAsync<int>(command,new {c_name=newChapter.ChapterName,c_episode=newChapter.Episode,
                b_id=newChapter.BookId,c_date=newChapter.CreateDate});
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var command = $"call sp_delete_chapter({id})";
            var result = await _connection.ExecuteAsync(command);
            return result == -1;
        }

        public async Task<List<Chapter>> GetAll()
        {
            var query = "select id,chaptername,episode,bookid,create_date createdate from chapters order by createdate desc";
            var result = await _connection.QueryAsync<Chapter>(query);
            return result.ToList();
        }

        public async Task<List<Chapter>> GetByBookId(int bookid)
        {
            var query = $"select id,chaptername,episode,bookid,create_date createdate from chapters  where bookid={bookid} order by createdate desc";
            var result = await _connection.QueryAsync<Chapter>(query);
            return result.ToList();
        }

        public async Task<Chapter> GetById(int id)
        {
            var query = $"select id,chaptername,episode,bookid,create_date createdate from chapters  where id={id}";
            var result = await _connection.QuerySingleAsync<Chapter>(query);
            return result;
        }

        public async Task<bool> Update(ChapterUpdateRequestDto updateChapter)
        {
            var command = $"call sp_update_chapter({updateChapter.Id},{updateChapter.ChapterName},{updateChapter.Episode})";
            return await _connection.ExecuteAsync(command)==-1;
        }
    }
}
