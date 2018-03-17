using Lab_8.Data;
using Lab_8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_8.Repositories
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public User GetUser(int id)
        {
            return _context.Users.Find(id);
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }
        public bool DeleteUser(int id)
        {
            User user = _context.Users.Find(id);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateUser(User user)
        {
            try
            {
                _context.Users.Remove(user);
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public Job GetJob(int jobId)
        {
            return _context.Jobs.Find(jobId);
        }
        public IEnumerable<Job> GetUserJobs(int userId)
        {
            var userJobs = new List<Job>();
            foreach(var job in _context.Jobs)
            {
                if(job.UserId == userId)
                {
                    userJobs.Add(job);
                }
            }
            return userJobs;
        }
        public bool DeleteJob(int jobId)
        {
            try
            {
                _context.Jobs.Remove(_context.Jobs.Find(jobId));
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }
        public bool UpdateJob(Job job)
        {
            try
            {
                var oldRecord = _context.Jobs.Find(job.JobId);
                oldRecord.UserId = job.UserId;
                oldRecord.Title = job.Title;
                oldRecord.Description = job.Description;
                oldRecord.Salary = job.Salary;
                oldRecord.SalaryIsYearly = job.SalaryIsYearly;
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}