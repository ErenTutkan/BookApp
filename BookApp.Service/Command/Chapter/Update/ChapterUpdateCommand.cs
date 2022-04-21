using BookApp.Core.DTOs;
using BookApp.Core.DTOs.ChapterDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Service.Command.Chapter.Update
{
    public class ChapterUpdateCommand:IRequest<ResponseDto<NoContent>>
    {
        public ChapterUpdateRequestDto updateChapter { get; set; }
    }
}
