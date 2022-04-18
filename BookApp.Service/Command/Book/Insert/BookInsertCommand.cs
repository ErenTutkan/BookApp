using BookApp.Core.DTOs;
using BookApp.Core.DTOs.BookDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Command.Book.Insert
{
    public class BookInsertCommand:IRequest<ResponseDto<int>>
    {
        public BookAddRequestDto newBook{ get; set; }
    }
}
