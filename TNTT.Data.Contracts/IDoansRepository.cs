using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNTT.Model;

namespace TNTT.Data.Contracts
{
    public interface IDoansRepository : IRepository<Doan>
    {
        IQueryable<Doan> GetByMienId(int id);
        Doan GetByName(string doanName, int mienId);
    }
}
