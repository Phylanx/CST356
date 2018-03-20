using Final.Web.Models.Entities;
using System;
using System.Collections.Generic;

namespace Final.Web.Services
{
    public interface IProjectService
    {
        ProjectModel GetProject(int id);
        IEnumerable<ProjectModel> GetUserProjects(String userId);
        void CreateProject(ProjectModel project);
        void UpdateProject(ProjectModel project);
        void DeleteProject(int id);
    }
}