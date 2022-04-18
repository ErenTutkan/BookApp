using BookApp.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Command.Book.Delete
{
    public class BookDeleteCommand:IRequest<ResponseDto<NoContent>>
    {
        public int Id { get; set; }
    }
}
