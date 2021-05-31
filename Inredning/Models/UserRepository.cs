using System.Collections.Generic;

namespace Inredning.Models
{
    public class UserRepository : IUserRepository
    {
        AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<User> AllUsers
        {
            get
            {
                return _appDbContext.Users;
            }
        }
    }
}