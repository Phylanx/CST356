using Final.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final.Web.Repositories
{
    public interface IProjectRepository
    {
        Project GetProject(int id);
        IEnumerable<Project> GetUserProjects(String userId);
        void CreateProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(int id);
    }
}