using Lab5_v2.Data.Entities;
using Lab5_v2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5_v2.Services
{
    public class BusinessLogicService : IBusinessLogicService
    {
        private readonly IUserService _service;
        public BusinessLogicService(IUserService service)
        {
            _service = service;
        }

        public String GetAverageAge()
        {
            int count = 0;
            int sum = 0;
            foreach(var user in _service.GetAllUserModels())
            {
                sum += user.age;
                ++count;
            }
            return (count == 0) ? "N/A" : (sum / count).ToString();
        }
    }
}