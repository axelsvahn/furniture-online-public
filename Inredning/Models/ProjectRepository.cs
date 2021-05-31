using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Inredning.Models
{
    public class ProjectRepository : IProjectRepository
    {
        AppDbContext _appDbContext;
        IOrderItemRepository _orderItemRepository;

        public ProjectRepository(AppDbContext appDbContext, IOrderItemRepository orderItemRepository)
        {
            _appDbContext = appDbContext;
            _orderItemRepository = orderItemRepository;
        }

        public IEnumerable<Project> AllProjects
        {
            get
            {
                return _appDbContext.Projects;
            }
        }

        public double GetProjectCost(int projectId)
        {
            double totalCost = default;

            foreach (OrderItem o in _orderItemRepository.AllOrderItems.Where(o => o.ProjectId == projectId))
            {
                totalCost = totalCost + (o.IndividualPrice * o.Amount);
            }
            return totalCost;
        }

        [NotMapped] // probably not needed but here just to remember it
        public double AllProjectsCost
        {
            get
            {
                if (_appDbContext.Projects.Count() == 0) 
                {
                    return 0;
                }
                else //the following code results in bugs if there are order items with no associated project
                {
                    double totalCost = default;
                    foreach (OrderItem o in _orderItemRepository.AllOrderItems)
                    {
                        totalCost = totalCost + (o.IndividualPrice * o.Amount);
                    }
                    return totalCost;
                }
            }
        }

        [NotMapped] // probably not needed but here just to remember it
        public double AverageProjectCost
        {
            get
            {
                if (_appDbContext.Projects.Count() == 0) //avoid division by 0
                {
                    return 0;
                }
                else
                {
                    return AllProjectsCost / _appDbContext.Projects.Count();
                }
            }
        }

        public void AddProject(Project project)
        {
            _appDbContext.Projects.Add(project);
            _appDbContext.SaveChanges();
        }

        public void UpdateProject(Project updatedProject)
        {
            foreach (Project p in AllProjects)
                if (p.DecoratorEmail == updatedProject.DecoratorEmail)
                {
                    p.ProjectName = updatedProject.ProjectName;
                }
            _appDbContext.SaveChanges();
        }

        public void RemoveProject(Project project)
        {
            _appDbContext.Projects.Remove(project);
            _appDbContext.SaveChanges();
        }
    }
}
