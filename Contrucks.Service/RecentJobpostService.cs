using Contrucks.model;
using Contrucks.model.ViewModels;
using Contrucks.Repository.Infrastructure;
using Contrucks.Repository.Repository;
using Contrucks.Service.Interfaces;
using System.Collections.Generic;

namespace Contrucks.Service
{
    public class RecentJobPostService : IRecentJobPostService
    {
        private readonly IRecentpostsRepository usertableRepository;
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializing reference variables of IRecentpostsRepository and IUnitOfWork
        /// </summary>
        /// <param name="usertableRepository"></param>
        /// <param name="unitOfWork"></param>
        public RecentJobPostService(IRecentpostsRepository usertableRepository, IUnitOfWork unitOfWork)
        {
            this.usertableRepository = usertableRepository;
            this.unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Getting all the data regarding Job Posts Details 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NewJobPosts> GetAll()
        {
            return usertableRepository.GetAll();
        }

        /// <summary>
        /// Adding another New Job Posts detail into DB
        /// </summary>
        /// <param name="usertables"></param>
        public void AddData(RecentpostViewmodel usertables)
        {
            //ConTruckContext context = new ConTruckContext();
            NewJobPosts njp = new NewJobPosts
            {
                distance = usertables.distance,
                JobTitle = usertables.JobTitle,
                JobDescription = usertables.JobDescription,
                JobStartDate = usertables.JobStartDate,
                JobEndDate = usertables.JobEndDate,
                EstimatedTime = usertables.EstimatedTime,
                SourceAddress = usertables.SourceAddress,
                DestinationAddress = usertables.DestinationAddress,
                LoadWeight = usertables.LoadWeight,
                Budget = usertables.Budget
            };
            usertableRepository.Add(njp);
            unitOfWork.Commit();
        }
        
        public NewJobPosts GetAllById(int Id)
        {
            return usertableRepository.GetAllById(Id);
             
        }
    }
}