using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Core.DTOs.BookCategoryDtos
{
    public class BookCategoryAddRequestDto
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }
    }
}
