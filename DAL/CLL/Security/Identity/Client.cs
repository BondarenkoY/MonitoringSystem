using System;
using System.Collections.Generic;
using System.Text;

namespace CLL.Security.Identity
{
    public class Client
        : User
    {
        public Client(int userId, string name, string login, int password)
            : base(userId, name, nameof(Client), password)
        {
        }
    }
}
