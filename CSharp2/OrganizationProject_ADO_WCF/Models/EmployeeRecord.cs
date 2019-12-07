using System.Runtime.Serialization;

namespace OrganizationProject_ADO_WCF.Models
{
    [DataContract]
    public class EmployeeRecord
    {
        [DataMember]
        public int Id;
        [DataMember]
        public string FirstName;
        [DataMember]
        public string LastName;
        [DataMember]
        public int? DepartmentId;
        [DataMember]
        public DepartmentRecord Department;
    }
}