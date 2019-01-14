using System;
using System.Collections.Generic;
using Employee.Service.Models;

namespace Employee.Service.DataBaseAccessObject.Saver
{
   public interface ISeviceDataSave
    {
       void SaveEmployee(List<EmployeeInfo> employeeInfo);
       void SaveDepartment(List<Department> department);
       void SaveCompanie(List<Company> company);
    }
}
