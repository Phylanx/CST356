using Lab_8.Entities;
using Lab_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8.Services
{
    public interface IService
    {
        UserModel GetUser(int id);
        IEnumerable<UserModel> GetAllUsers();
        bool DeleteUser(int id);
        bool UpdateUser(UserModel user);

        JobModel GetJob(int jobId);
        IEnumerable<JobModel> GetUserJobs(int userId);
        bool DeleteJob(int userId);
        bool UpdateJob(JobModel job);
    }
}
