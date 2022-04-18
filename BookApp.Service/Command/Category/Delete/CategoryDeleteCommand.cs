using BookApp.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Command.Category.Delete
{
    public class CategoryDeleteCommand:IRequest<ResponseDto<NoContent>>
    {
        public int Id { get; set; }
    }
}
