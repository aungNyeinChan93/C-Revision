using System;
using System.Collections.Generic;

namespace DatabaseTwo.Models;

public partial class Quote
{
    public int QuoteId { get; set; }

    public string Quote1 { get; set; } = null!;

    public string Author { get; set; } = null!;
}
