using Lab_8.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_8.Repositories
{
    public interface IPCRepository
    {
        PC GetPC(int id);
        IEnumerable<PC> GetAllUserPCs(String userId);
        void SavePC(PC pc);
        void UpdatePC(PC pc);
        void DeletePC(int id);
    }
}