using System.Collections.Generic;

namespace Inredning.Models
{
    public interface IProjectRepository
    {
        IEnumerable<Project> AllProjects { get; }
        double AllProjectsCost { get; }
        double AverageProjectCost { get; }
        double GetProjectCost(int projectId);
        void AddProject(Project project);
        void UpdateProject(Project project);
        void RemoveProject(Project project);
    }
}