using BookApp.Core.DTOs;
using BookApp.Core.DTOs.BookDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Queries.Book.GetById
{
    public class GetByIdBookQuery:IRequest<ResponseDto<BookDto>>
    {
        public int Id { get; set; }
    }
}
