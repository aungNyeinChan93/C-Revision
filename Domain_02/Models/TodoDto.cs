using System;
using System.Collections.Generic;
using System.Text;

namespace Domain_02.Models
{
    public class TodoDto
    {
        public int id { get; set; }
        public string todo { get; set; }
        public bool completed { get; set; }
        public int userId { get; set; }
    }
}
