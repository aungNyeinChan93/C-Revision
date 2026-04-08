using System;
using System.Collections.Generic;
using System.Text;

namespace Tuto_07_JSON.Models
{
    public class Birds
    {
        public List<Bird> birds { get; set; }
    }

    public class Bird
    {
        public int Id { get; set; }
        public string? BirdMyanmarName { get; set; }
        public string? BirdEnglishName { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
    }

}
