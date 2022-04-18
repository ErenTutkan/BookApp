using BookApp.Core.DTOs.BookDtos;
using BookApp.Service.Command.Book.Delete;
using BookApp.Service.Command.Book.Insert;
using BookApp.Service.Command.Book.Update;
using BookApp.Service.Queries.Book.GetAll;
using BookApp.Service.Queries.Book.GetById;
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
            return  CreateActionResult(await _mediator.Send(new GelAllBookQuery()));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return CreateActionResult(await _mediator.Send(new GetByIdBookQuery() { Id = id }));
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
    }
}
