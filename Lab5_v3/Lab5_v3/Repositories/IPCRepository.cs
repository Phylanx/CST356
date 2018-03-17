using Lab5_v3.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_v3.Repositories
{
    public interface IPCRepository
    {
        PC GetPC(int id);
        IEnumerable<PC> GetAllUserPCs(int userId);
        void SavePC(PC pc);
        void UpdatePC(PC pc);
        void DeletePC(int id);
    }
}
