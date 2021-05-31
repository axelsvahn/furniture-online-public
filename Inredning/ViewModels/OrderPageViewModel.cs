using System.Collections.Generic;
using Inredning.Models;

namespace Inredning.ViewModels
{
    public class OrderPageViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public IProjectRepository ProjectRepository { get; set; }
    }

}
