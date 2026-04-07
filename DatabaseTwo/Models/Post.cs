using System;
using System.Collections.Generic;

namespace DatabaseTwo.Models;

public partial class Post
{
    public int PostId { get; set; }

    public string Title { get; set; } = null!;

    public string? Despcription { get; set; }

    public string? Author { get; set; }

    public byte[]? Date { get; set; }

    public bool DeleteFlag { get; set; }
}
