using Final.UserEntities;
using Final.Web.Models.Entities;
using Final.Web.Repositories;
using System;
using System.Collections.Generic;

namespace Final.Web.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;
        public ProjectService(IProjectRepository rep)
        {
            _repository = rep;
        }

        public ProjectModel GetProject(int id)
        {
            return ToModel(_repository.GetProject(id));
        }
        public IEnumerable<ProjectModel> GetUserProjects(String userId)
        {
            var projects = new List<ProjectModel>();
            foreach(var project in _repository.GetUserProjects(userId))
            {
                projects.Add(ToModel(project));
            }
            return projects;
        }
        public void CreateProject(ProjectModel project)
        {
            _repository.CreateProject(ToProject(project));
        }
        public void UpdateProject(ProjectModel project)
        {
            var projectRecord = _repository.GetProject(project.Id);
            projectRecord.Title = project.Title;
            projectRecord.Description = project.Description;
            projectRecord.Start = project.Start;
            projectRecord.Finish = project.Finish;
            projectRecord.Completed = project.Completed;
            projectRecord.OwnerId = project.OwnerId;

            _repository.UpdateProject(projectRecord);
        }
        public void DeleteProject(int id)
        {
            _repository.DeleteProject(id);
        }

        private ProjectModel ToModel(Project project)
        {
            return new ProjectModel
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Start = project.Start,
                Finish = project.Finish,
                Completed = project.Completed,
                OwnerId = project.OwnerId
            };
        }
        private Project ToProject(ProjectModel project)
        {
            return new Project
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Start = project.Start,
                Finish = project.Finish,
                Completed = project.Completed,
                OwnerId = project.OwnerId
            };
        }



    }
}