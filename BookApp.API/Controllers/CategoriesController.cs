using BookApp.Core.DTOs;
using BookApp.Core.DTOs.CategoryDtos;
using BookApp.Service.Command.Category.Delete;
using BookApp.Service.Command.Category.Insert;
using BookApp.Service.Command.Category.Update;
using BookApp.Service.Queries.Category.GetAll;
using BookApp.Service.Queries.Category.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController :ControllerCustomBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await  _mediator.Send(new GetAllCategoryQuery()));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return CreateActionResult(await _mediator.Send(new GetByIdCategoryQuery() { Id=id}));
        }
        [HttpPost]
        public async Task<IActionResult> Save(CategoryAddRequestDto category)
        {
            return CreateActionResult(await _mediator.Send(new CategoryInsertCommand() { newCategory = category }));
        }
        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateRequestDto updateCategory)
        {
            return CreateActionResult(await _mediator.Send(new CategoryUpdateCommand() { updateCategory = updateCategory }));
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateActionResult(await _mediator.Send(new CategoryDeleteCommand() { Id=id}));
        }
    }
}
