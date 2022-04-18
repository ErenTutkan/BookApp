using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Core.DTOs.BookDtos
{
    public class BookAddRequestDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string BookPicture { get; set; }
    }
}
