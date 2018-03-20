using Final.UserEntities;
using Final.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final.Web.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _db;
        public ProjectRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Project GetProject(int id)
        {
            return _db.Projects.Find(id);
        }
        public IEnumerable<Project> GetUserProjects(String userId)
        {
            var projects = new List<Project>();
            foreach(var project in _db.Projects)
            {
                if(project.OwnerId == userId) projects.Add(project);
            }
            return projects;
        }
        public void CreateProject(Project project)
        {
            _db.Projects.Add(project);
            _db.SaveChanges();
        }
        public void UpdateProject(Project project)
        {
            _db.SaveChanges();
        }
        public void DeleteProject(int id)
        {
            var project = _db.Projects.Find(id);
            if (project == null) return;
            _db.Projects.Remove(project);
            _db.SaveChanges();
        }
    }
}