using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OrganizationProject_ADO_WCF.Models
{
    [DataContract]
    public class DepartmentRecord
    {
        [DataMember]
        public int Id;
        [DataMember]
        public string Name;
        [DataMember]
        public List<EmployeeRecord> Employees;
    }
}