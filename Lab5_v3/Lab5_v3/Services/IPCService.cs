using Lab5_v3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5_v3.Services
{
    public interface IPCService
    {
        PCViewModel GetPC(int id);
        IEnumerable<PCViewModel> GetAllUserPCs(int userId);
        void SavePC(PCViewModel pc);
        void UpdatePC(PCViewModel pc);
        void DeletePC(int id);
        int GetTotalStorage(int userId);
    }
}