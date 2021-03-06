using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Core.DTOs.BookDtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string BookPicture { get; set; }
    }
}
