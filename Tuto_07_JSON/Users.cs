using System;
using System.Collections.Generic;
using System.Text;

namespace Tuto_07_JSON
{
    public class Users
    {
        List<User> users { get; set; } = [];

    }

    public class User 
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;

        public string? Email { get; set; }

        public int Age { get; set; }
    }

}
