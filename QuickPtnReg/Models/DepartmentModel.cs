using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace QuickPtnReg.Models
{
    public class DepartmentModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class DepartmentUnitsModel
    {
        public int UnitCd { get; set; }
        public string UnitName { get; set; }
    }


    public class PatientSourceModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string add_info_1 { get; set; }
    }

    public class PatientModel
    {
        public long PatientNo { get; set; }

        public string? PatientFullName { get; set; }

        [Required(ErrorMessage = "first name is required.")]
        [MaxLength(100)]
        public string PatientLastName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string PatientFirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "last name is required.")]
        [MaxLength(100)]
        public string? PatientMiddleNamePart { get; set; }

        public string? PatientMiddleName { get; set; }


        [Required(ErrorMessage = "Patient age is required.")]
        public int Age { get; set; }

        
        [Required(ErrorMessage = "Patient Gender is required.")]
        public string sex { get; set; }

        public string? Department { get; set; }


        [Required(ErrorMessage = "Patient contact number is required.")]
        [RegularExpression(@"^\d{10,12}$", ErrorMessage = "Mobile number must be 10 to 12 digits.")]
        public string MobileNumber { get; set; }

        public int PatientSourceCode { get; set; }


        [MaxLength(150)]
        public string? PatientAddressLine1 { get; set; } = string.Empty;


        [MaxLength(150)]
        public string? PatientAddressLine2 { get; set; } = string.Empty;


        [MaxLength(150)]
        public string? PatientAddressLine3 { get; set; } = string.Empty;

        public int DepartmentUnit { get; set; }
        public int MaritalStatus { get; set; }


    }
}
