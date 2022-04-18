using BookApp.Core.DTOs;
using BookApp.Core.DTOs.CategoryDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Queries.Category.GetById
{
    public class GetByIdCategoryQuery:IRequest<ResponseDto<CategoryDto>>
    {
        public int Id { get; set; }
    }
}
