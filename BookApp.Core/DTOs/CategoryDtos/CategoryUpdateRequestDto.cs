using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Core.DTOs.CategoryDtos
{
    public class CategoryUpdateRequestDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
