using BookApp.Core.DTOs.BookDtos;
using BookApp.Service.Command.Book.Delete;
using BookApp.Service.Command.Book.Insert;
using BookApp.Service.Command.Book.Update;
using BookApp.Service.Queries.Book.GetAll;
using BookApp.Service.Queries.Book.GetAllFull;
using BookApp.Service.Queries.Book.GetByCategory;
using BookApp.Service.Queries.Book.GetById;
using BookApp.Service.Queries.Book.GetFull;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerCustomBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return  CreateActionResult(await _mediator.Send(new GetAllFullBookQuery()));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return CreateActionResult(await _mediator.Send(new GetByIdFullBookQuery() { Id = id }));
        }
        [HttpPost]
        public async Task<IActionResult> Save(BookAddRequestDto request)
        {
            return CreateActionResult(await _mediator.Send(new BookInsertCommand() { newBook = request }));
        }
        [HttpPut]
        public async Task<IActionResult> Update(BookUpdateRequestDto request)
        {
            return CreateActionResult(await _mediator.Send(new BookUpdateCommand() { updateBook=request }));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateActionResult(await _mediator.Send(new BookDeleteCommand() { Id = id }));   
        }
        [HttpGet("GetByCategory/{categoryId:int}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            return CreateActionResult(await _mediator.Send(new GetByCategoryWithBookQuery(){ CategoryId=categoryId}));
        }
    }
}
