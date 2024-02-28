namespace QuickPtnReg.Models
{
    public class DepartmentModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class PatientSourceModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class PatientModel
    {
        public long PatientNo { get; set; }
        public string PatientFullName { get; set; }
        public string PatientMiddleName { get; set; }
        public int Age { get; set; }
        public string sex { get; set; }
        public string Department { get; set; }
        public string MobileNumber { get; set; }
        public int PatientSourceCode { get; set; }
    }
}
