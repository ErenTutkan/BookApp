using BookApp.Core.DTOs;
using BookApp.Core.DTOs.BookDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Queries.Book.GetByCategory
{
    public class GetByCategoryWithBookQuery:IRequest<ResponseDto<List<BookDto>>>
    {
        public int CategoryId { get; set; }
    }
}
