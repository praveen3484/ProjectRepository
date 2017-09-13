using Contrucks.model;
using Contrucks.model.ViewModels;
using Contrucks.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrucks.Repository.Repository
{
    public class UserTablesRepository : RepositoryBase<UserTables>, IUserTablesRepository
    {
        public UserTablesRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
    public interface IUserTablesRepository : IRepositoryBase<UserTables>
    {
        IEnumerable<UserTables> GetAll();
        void Add(UserTables usertables);
    }

}
