using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Service.Models
{
  public  class CompanyData
    {
        public List<Company> Objects { get; set; }
        public Meta Meta { get; set; }
        public bool Error { get; set; }
    }
}
