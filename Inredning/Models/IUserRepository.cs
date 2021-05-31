using System.Collections.Generic;

namespace Inredning.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> AllUsers { get; }
    }
}