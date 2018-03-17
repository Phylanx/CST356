using Lab_8.Entities;
using Lab_8.Models;
using Lab_8.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_8.Services
{
    public class Service : IService
    {
        private readonly IRepository _repository;
        public Service(IRepository repository)
        {
            _repository = repository;
        }
        public UserModel GetUser(int id)
        {
            return ToUserModel(_repository.GetUser(id));
        }
        public IEnumerable<UserModel> GetAllUsers()
        {
            var allUsers = new List<UserModel>();
            foreach(var user in _repository.GetAllUsers())
            {
                allUsers.Add(ToUserModel(user));
            }
            return allUsers;
        }
        public bool DeleteUser(int id)
        {
            return _repository.DeleteUser(id);
        }
        public bool UpdateUser(UserModel user)
        {
            return _repository.UpdateUser(ToUser(user));
        }

        public JobModel GetJob(int jobId)
        {
            return  ToJobModel(_repository.GetJob(jobId));
        }
        public IEnumerable<JobModel> GetUserJobs(int userId)
        {
            var userJobs = new List<JobModel>();
            foreach (var job in _repository.GetUserJobs(userId))
            {
                userJobs.Add(ToJobModel(job));
            }
            return userJobs;
        }
        public bool DeleteJob(int jobId)
        {
            return _repository.DeleteJob(jobId);
        }
        public bool UpdateJob(JobModel job)
        {
            return _repository.UpdateJob(ToJob(job));
        }

        private User ToUser(UserModel user)
        {
            return new User
            {
                Id = user.Id,
                FName = user.FName,
                MName = user.MName,
                LName = user.LName,
                BDay = user.BDay
            };
        }
        private UserModel ToUserModel(User user)
        {
            return new UserModel
            {
                Id = user.Id,
                FName = user.FName,
                MName = user.MName,
                LName = user.LName,
                BDay = user.BDay
            };
        }

        private Job ToJob(JobModel job)
        {
            return new Job
            {
                JobId = job.JobId,
                UserId = job.UserId,
                Title = job.Title,
                Description = job.Description,
                Salary = job.Salary,
                SalaryIsYearly = job.SalaryIsYearly
            };
        }
        private JobModel ToJobModel(Job job)
        {
            return new JobModel
            {
                JobId = job.JobId,
                UserId = job.UserId,
                Title = job.Title,
                Description = job.Description,
                Salary = job.Salary,
                SalaryIsYearly = job.SalaryIsYearly
            };
        }
    }
}