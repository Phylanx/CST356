using Lab_8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8.Repositories
{
    public interface IRepository
    {
        User GetUser(int id);
        IEnumerable<User> GetAllUsers();
        bool DeleteUser(int id);
        bool UpdateUser(User user);

        Job GetJob(int jobId);
        IEnumerable<Job> GetUserJobs(int userId);
        bool DeleteJob(int jobId);
        bool UpdateJob(Job job);
    }
}
