using BookApp.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Command.Chapter.Delete
{
    public class ChapterDeleteCommand:IRequest<ResponseDto<NoContent>>
    {
        public int Id { get; set; }
    }
}
