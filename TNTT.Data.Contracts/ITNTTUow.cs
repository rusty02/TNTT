using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNTT.Model;

namespace TNTT.Data.Contracts
{
    public interface ITNTTUow
    {
        void Commit();

        // Repositories
        IContactsRepository Contacts { get; }
        IRepository<TrungUong> TrungUongs { get; }
        IRepository<Mien> Miens { get; }
        IRepository<LienDoan> LienDoans { get; }
        IDoansRepository Doans { get; }
        IRepository<SaMac> SaMacs { get; }
        IRepository<SaMacDanhSach> SaMacDanhSachs { get; }
    }
}
