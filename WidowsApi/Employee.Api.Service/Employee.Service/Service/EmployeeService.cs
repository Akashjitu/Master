using Employee.Service.Manager;

namespace Employee.Service.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeServiceManage _employeeServiceManage;

        public EmployeeService(IEmployeeServiceManage employeeServiceManage)
        {
            _employeeServiceManage = employeeServiceManage;
        }

        public void LoadApiData()
        {
            _employeeServiceManage.ConsumeApi();
        }

        //public string GetEmployee(string name)
        //{

        //}

        //public string GetEmployee(int id)
        //{

        //}
    }
}