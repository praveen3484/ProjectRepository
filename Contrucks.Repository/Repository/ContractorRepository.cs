using Contrucks.model;
using Contrucks.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrucks.Repository.Repository
{
   public class ContractorRepository : RepositoryBase<Contractors>, IContractorRepository
    { 
            public ContractorRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
            {
            }
        
    }
    public interface IContractorRepository : IRepositoryBase<Contractors>
    {
        IEnumerable<Contractors> GetAll();
        void Add(Contractors contractors);
    }
}
