using System;
using System.Collections.Generic;

namespace DatabaseTwo.Models;

public partial class Blog
{
    public int BlogId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedDate { get; set; }
}
