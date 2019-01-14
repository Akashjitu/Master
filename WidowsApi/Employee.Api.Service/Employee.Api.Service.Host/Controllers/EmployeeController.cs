using System.Net;
using System.Net.Http;
using System.Web.Http;
using Employee.Service.Service;

namespace Employee.Api.Service.Host.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public HttpResponseMessage Get()
        {
            _employeeService.LoadApiData();
             return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}