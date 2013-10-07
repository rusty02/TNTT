using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNTT.Data.Contracts;
using TNTT.Data.Helpers;
using TNTT.Model;

namespace TNTT.Data
{

    /// <summary>
    /// The Code Camper "Unit of Work"
    ///     1) decouples the repos from the controllers
    ///     2) decouples the DbContext and EF from the controllers
    ///     3) manages the UoW
    /// </summary>
    /// <remarks>
    /// This class implements the "Unit of Work" pattern in which
    /// the "UoW" serves as a facade for querying and saving to the database.
    /// Querying is delegated to "repositories".
    /// Each repository serves as a container dedicated to a particular
    /// root entity type such as a <see cref="Contact"/>.
    /// A repository typically exposes "Get" methods for querying and
    /// will offer add, update, and delete methods if those features are supported.
    /// The repositories rely on their parent UoW to provide the interface to the
    /// data layer (which is the EF DbContext in TNTT).
    /// </remarks>
    public class TNTTUow : ITNTTUow, IDisposable
    {
        public TNTTUow(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();

            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        // TNTT Repository
        public IContactsRepository Contacts { get { return GetRepo<IContactsRepository>(); } }
        public IRepository<TrungUong> TrungUongs { get { return GetStandardRepo<TrungUong>(); } }
        public IRepository<Mien> Miens { get { return GetStandardRepo<Mien>(); } }
        public IRepository<LienDoan> LienDoans { get { return GetStandardRepo<LienDoan>(); } }
        public IDoansRepository Doans { get { return GetRepo<IDoansRepository>(); } }
        public IRepository<SaMac> SaMacs { get { return GetStandardRepo<SaMac>(); } }
        public IRepository<SaMacDanhSach> SaMacDanhSachs { get { return GetStandardRepo<SaMacDanhSach>(); } }

        /// <summary>
        /// Save pending changes to the database
        /// </summary>
        public void Commit()
        {
            DbContext.SaveChanges();
        }

        protected void CreateDbContext()
        {
            DbContext = new TNTTContext();

            // Do NOT enable proxied entities, else serialization fails
            DbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            DbContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }


        protected IRepositoryProvider RepositoryProvider { get; set; }

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }
        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        private TNTTContext DbContext { get; set; }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion

    }
}
