
using System;
using System.Threading.Tasks;
using Employee.Service.Constants;
using Employee.Service.DataBaseAccessObject.Saver;
using Employee.Service.Models;
using Employee.Service.ServiceConsumer;

namespace Employee.Service.Manager
{
    public class EmployeeServiceManage : IEmployeeServiceManage
    {
        private readonly IApiServiceConsumer _apiServiceConsumer;
       private  readonly ISeviceDataSave _seviceDataSave;
        EmployeeData _employeeData;
        DepartmentData _departmentData;
        CompanyData _companiesData;
        public EmployeeServiceManage(IApiServiceConsumer apiServiceConsumer, ISeviceDataSave seviceDataSave)
        {
            _apiServiceConsumer = apiServiceConsumer;
            _seviceDataSave = seviceDataSave;
        }

        public void ConsumeApi()

        {

            Task.Factory.StartNew(() =>
            {
                 _employeeData = _apiServiceConsumer.GetApiData<EmployeeData>(ServiceConstant.EmployeeUrl);
                 _departmentData = _apiServiceConsumer.GetApiData<DepartmentData>(ServiceConstant.DepartmentUrl);
                 _companiesData = _apiServiceConsumer.GetApiData<CompanyData>(ServiceConstant.CompanyUrl);
            }).ContinueWith((save) =>
            {
                _seviceDataSave.SaveEmployee(_employeeData.Objects);
                _seviceDataSave.SaveDepartment(_departmentData.Objects);
                _seviceDataSave.SaveCompanie(_companiesData.Objects);
               
            });
            
        }
    }
}
