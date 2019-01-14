using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Employee.Service.Models;
using Service.DataBaseAccessObject;

namespace Employee.Service.DataBaseAccessObject.Saver
{
    public class SeviceDataSave : ISeviceDataSave
    {
        public void SaveCompanie(List<Company> company)
        {
            if (company == null)
                return;
            using (var db = new CompanyDbEntities())
            {
              var companis=  company.Where(i=> !db.tb_Company.Any(k=>k.Id== i.Id)).Select(i => new tb_Company()
                {
                  Id = i.Id,
                  Name = i.Name
                });
                db.tb_Company.AddRange(companis);
                db.SaveChanges();
            }
        }

        public void SaveDepartment(List<Department> department)
        {
            if (department == null)
                return;

            using (var db = new CompanyDbEntities())
            {
                var departments = department.Where(i => !db.tb_Department.Any(k => k.Id == i.Id)).Select(i => new tb_Department()
                {
                    Id = i.Id,
                     Name = i.Name,
                     CompanyId = i.company_id
                });
                db.tb_Department.AddRange(departments);
                db.SaveChanges();
            }
        }

        public void SaveEmployee(List<EmployeeInfo> employeeInfo)
        {
            if (employeeInfo == null)
                return;

            using (var db = new CompanyDbEntities())
            {
                var employees = employeeInfo.Where(i => !db.tb_Employees.Any(k => k.Id == i.Id)).Select(i => new tb_Employees()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Deparment_Id = i.department_id
                });
                db.tb_Employees.AddRange(employees);
                db.SaveChanges();
            }
        }
    }
}