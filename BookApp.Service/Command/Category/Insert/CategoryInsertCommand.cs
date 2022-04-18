using BookApp.Core.DTOs;
using BookApp.Core.DTOs.CategoryDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Command.Category.Insert
{
    public class CategoryInsertCommand:IRequest<ResponseDto<int>>
    {
        public CategoryAddRequestDto newCategory { get; set; }
    }
}
