using BookApp.Core.DTOs;
using BookApp.Core.DTOs.ChapterDtos;
using BookApp.Service.Command.Chapter.Delete;
using BookApp.Service.Command.Chapter.Insert;
using BookApp.Service.Command.Chapter.Update;
using BookApp.Service.Queries.Chapter.GetAll;
using BookApp.Service.Queries.Chapter.GetByBookId;
using BookApp.Service.Queries.Chapter.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChaptersController : ControllerCustomBase
    {
        private readonly IMediator _mediator;

        public ChaptersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _mediator.Send(new GetAllChapterQuery()));
        }
        [HttpGet("GetBook/{id:int}")]
        public async Task<IActionResult> GetBook(int id)
        {
            return CreateActionResult(await _mediator.Send(new GetByBookIdChapterQuery() { BookId=id}));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return CreateActionResult(await _mediator.Send(new GetByIdChapterQuery() { Id=id}));
        }
        [HttpPost]
        public async Task<IActionResult> Add(ChapterAddRequestDto newChapter)
        {
            return CreateActionResult(await _mediator.Send(new ChapterInsertCommand() { newChapter = newChapter }));
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id,ChapterUpdateRequestDto update)
        {
            update.Id = id;
            return CreateActionResult(await _mediator.Send(new ChapterUpdateCommand() { updateChapter=update}));
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateActionResult(await _mediator.Send(new ChapterDeleteCommand() { Id=id}));
        }


    }
}
