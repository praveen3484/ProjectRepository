using Contrucks.model;
using Contrucks.model.ViewModels;
using System.Collections.Generic;

namespace Contrucks.Service.Interfaces
{
    public interface IRecentJobPostService
    {
        IEnumerable<NewJobPosts> GetAll();
        void AddData(RecentpostViewmodel usertables);
        NewJobPosts GetAllById(int Id);     
    }
}
