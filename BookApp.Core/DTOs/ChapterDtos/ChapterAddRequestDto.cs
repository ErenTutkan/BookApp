using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Core.DTOs.ChapterDtos
{
    public class ChapterAddRequestDto
    {
        public string ChapterName { get; set; }
        public string Episode { get; set; }
        public int BookId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
