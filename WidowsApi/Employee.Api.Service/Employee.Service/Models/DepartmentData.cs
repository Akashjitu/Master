using System.Collections.Generic;

namespace Employee.Service.Models
{
    public class DepartmentData
    {
        public List<Department> Objects { get; set; }
        public Meta Meta { get; set; }
        public bool Error { get; set; }
    }
}
