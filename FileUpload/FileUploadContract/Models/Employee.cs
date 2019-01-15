using System;
using System.Data;
using System.Runtime.Serialization;

namespace FileUploadContract.Models
{
    [DataContract]
   public class Employee
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Department { get; set; }

        [DataMember]
        public string Designation { get; set; }

       static int id = 1;
        public static Employee FromCsv(string csvLine)
        {
            var values = csvLine.Split(',');
            var employee = new Employee
            {
                ID = id++,
                FirstName = values[0],
                LastName = values[1],
                Department = values[2],
                Designation = values[3]
            };
            
            return employee;
        }
    }


    [DataContract]
    public class Reference
    {

        [DataMember]
        public string[] FilesName { get; set; }


        [DataMember]
        public string SessionId { get; set; }
    }
}
