using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Core.DTOs.ChapterDtos
{
    public class ChapterUpdateRequestDto
    {
        public int Id { get; set; }
        public string ChapterName { get; set; }
        public string Episode { get; set; }
        
    }
}
