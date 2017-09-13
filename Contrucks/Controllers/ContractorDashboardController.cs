using Contrucks.model.ViewModels;
using Contrucks.Service;
using Contrucks.Service.Interfaces;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Contrucks.Controllers
{
    [EnableCors("*","*", "*")]
    public class ContractorDashboardController : ApiController
    {
        private readonly IUserTablesService usertableservices;
        IRecentJobPostService recentPostService;
        public ContractorDashboardController()
        {   

        }
        public ContractorDashboardController(IRecentJobPostService rec,IUserTablesService userservice)
        {
            recentPostService = rec;
            usertableservices = userservice;
        }
        // GET: /Details/

        [Route("api/ContractorDashboard/GetAllData")]
        public IHttpActionResult GetAllData()
        {
            //var user = User.Identity.GetUserId();

            var authors = recentPostService.GetAll();
            return Ok(authors);

        }

        //Post
        [Route("api/ContractorDashboard/SetData")]
        public IHttpActionResult SetData(RecentpostViewmodel recentVM)
        {
            usertableservices.AddUser(new ContractorRegistrationViewModel());
            recentPostService.AddData(recentVM);
            return Ok();
        }

        //Get recently added job posts
        [Route("api/ContractorDashboard/RecentJobPosts")]
        public IHttpActionResult GetRecentJobPosts(int Id)
        {
            var result= recentPostService.GetAllById(Id);
           return Ok(result);
        }
    }


}


