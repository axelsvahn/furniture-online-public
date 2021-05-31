using Inredning.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Inredning.ViewModels;
using System.Linq;

namespace Inredning.Controllers
{
    [Authorize] // Can remove during testing
    public class OrderPageController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly UserManager<User> _userManager;

        public OrderPageController(IUserRepository userRepository, IProjectRepository projectRepository, IOrderItemRepository orderItemRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _projectRepository = projectRepository;
            _orderItemRepository = orderItemRepository;
            _userManager = userManager;
        }

        public OrderPageViewModel ControlAccess()
        {
            OrderPageViewModel orderPageViewModel = new OrderPageViewModel
            {
                Users = _userRepository.AllUsers,
                OrderItems = _orderItemRepository.AllOrderItems,
                ProjectRepository = _projectRepository
            };

            //total access only for hard coded administrator
            var username = _userManager.GetUserName(User);

            if (username == "ingrid@ballong.se")
            {
                orderPageViewModel.Projects = _projectRepository.AllProjects;
                return orderPageViewModel;
            }
            else //if not ingrid
            {
                //Linq selection restricts user to own projects
                //does not filter order items, but the app only shows totals to Ingrid (implemented in ViewProjects.cshtml)
                orderPageViewModel.Projects = _projectRepository.AllProjects.Where(p => p.DecoratorEmail == username);
                return orderPageViewModel;
            }
        }

        public IActionResult Menu()
        {
            return View();
        }

        // GET
        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProject(Project project)
        {
            if (ModelState.IsValid)
            {
                _projectRepository.AddProject(project);
                return RedirectToAction("Menu");
            }
            else
            {
                ModelState.AddModelError("", "Var god försök igen.");
                return View(project);
            }
        }

        // GET
        public IActionResult CreateOrderItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrderItem(OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                _orderItemRepository.AddOrderItem(orderItem);
                return RedirectToAction("Menu");
            }
            else
            {
                ModelState.AddModelError("", "Var god försök igen.");
                return View(orderItem);
            }  
        }

        public IActionResult ViewProjects()
        {
            return View(ControlAccess());
        }

        public IActionResult SelectProject()
        {
            return View(ControlAccess());
        }

        // GET
        public IActionResult EditProject(int projectId)
        {
            var selectedProject = _projectRepository.AllProjects.FirstOrDefault(p => p.ProjectId == projectId);
                return View(selectedProject);
        }

        [HttpPost]
        public IActionResult EditProject(Project project)
        {
            if (ModelState.IsValid)
            {
                _projectRepository.UpdateProject(project);
                return RedirectToAction("Menu");
            }
            else
            {
                ModelState.AddModelError("", "Var god försök igen.");
                return View(project);
            }
        }

        public IActionResult DeleteProject(int projectId)
        {
            var selectedProject = _projectRepository.AllProjects.FirstOrDefault(p => p.ProjectId == projectId);
            _projectRepository.RemoveProject(selectedProject);
            return RedirectToAction("SelectProject");
        }

        public IActionResult SelectOrderItem()
        {
            return View(ControlAccess());
        }

        // GET
        public IActionResult EditOrderItem(int orderItemId)
        {
            var selectedOrderItem = _orderItemRepository.AllOrderItems.FirstOrDefault(p => p.OrderItemId == orderItemId);
            return View(selectedOrderItem);
        }

        [HttpPost]
        public IActionResult EditOrderItem(OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                _orderItemRepository.UpdateOrderItem(orderItem);
                return RedirectToAction("Menu");
            }
            else
            {
                ModelState.AddModelError("", "Var god försök igen.");
                return View(orderItem);
            }
        }

        public IActionResult DeleteOrderItem(int orderItemId)
        {
            var selectedOrderItem = _orderItemRepository.AllOrderItems.FirstOrDefault(p => p.OrderItemId == orderItemId);
            _orderItemRepository.RemoveOrderItem(selectedOrderItem);
            return RedirectToAction("SelectOrderItem");
        }
    }
}
