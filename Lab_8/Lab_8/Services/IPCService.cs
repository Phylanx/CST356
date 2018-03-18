using Lab_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_8.Services
{
    public interface IPCService
    {
        PCViewModel GetPC(int id);
        IEnumerable<PCViewModel> GetAllUserPCs(String userId);
        void SavePC(PCViewModel pc);
        void UpdatePC(PCViewModel pc);
        void DeletePC(int id);
        int GetTotalStorage(String userId);
    }
}