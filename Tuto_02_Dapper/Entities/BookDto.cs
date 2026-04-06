using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuto_02_Dapper.Entities
{
    public class BookDto
    {
        public int? BookId { get; set; } 
         public string Title { get; set; } =string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Year { get; set; }
    }
}
