using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNTT.Data.Contracts;
using TNTT.Model;

namespace TNTT.Data
{
    public class DoansRepository : EFRepository<Doan>, IDoansRepository
    {
        public DoansRepository(DbContext context) : base(context) { }

        public IQueryable<Doan> GetByMienId(int id)
        {
            return DbSet.Where(d => d.MienId == id);
        }

        public Doan GetByName(string doanName, int mienId)
        {
            return DbSet.FirstOrDefault(ns => ns.Name == doanName && ns.MienId == mienId);
        }
    }
}
