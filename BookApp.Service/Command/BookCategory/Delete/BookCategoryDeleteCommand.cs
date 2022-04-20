using BookApp.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Command.BookCategory.Delete
{
    public class BookCategoryDeleteCommand:IRequest<ResponseDto<NoContent>>
    {
        public int Id { get; set; }
    }
}
