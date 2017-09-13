using Contrucks.model;
using Contrucks.model.ViewModels;
using Contrucks.Repository.Infrastructure;
using Contrucks.Repository.Repository;
using System;
using System.Collections.Generic;

namespace Contrucks.Service
{
    public class UserTablesService : IUserTablesService
    {
        private readonly IUserTablesRepository usertableRepository;
        private readonly IContractorRepository contractorRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserTablesService(IUserTablesRepository usertableRepository,IContractorRepository contractorRepository, IUnitOfWork unitOfWork)
        {
            this.usertableRepository = usertableRepository;
            this.contractorRepository = contractorRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<UserTables> GetAllCustomers()
        {
            return usertableRepository.GetAll();
        }

        public void AddUser(ContractorRegistrationViewModel usertables)
        {
            try
            {

                UserTables njp = new UserTables
                {
                    IsActive = true,
                    CreatedBy = usertables.ContractorName
                };
                usertableRepository.Add(njp);
                unitOfWork.Commit();

                Contractors cts = new Contractors
                {
                    UserTableId = usertables.UserTableId,
                    StateId = usertables.StateId,
                    CityId = usertables.CityId,
                    ContractorName = usertables.ContractorName,
                    ContractorAge = usertables.ContractorAge,
                    ContractorPhone = usertables.ContractorPhone,
                    IsActive = true,
                    CreatedBy = usertables.CreatedBy
                };
                contractorRepository.Add(cts);
                unitOfWork.Commit();
            }
            catch ( Exception ex)
            {

                throw ;
            }
        }       
    }
}
