using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

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
        public string add_info_1 { get; set; }
    }

    public class PatientModel
    {
        public long PatientNo { get; set; }


       
        [Required (ErrorMessage ="Patient name is required.")]
        public string PatientFullName { get; set; }


        public string PatientMiddleName { get; set; }



        [Required(ErrorMessage = "Patient age is required.")]
        public int Age { get; set; }

        
        [Required(ErrorMessage = "Patient Gender is required.")]
        public string sex { get; set; }


        [Required(ErrorMessage = "Patient department is required.")]

        public string Department { get; set; }


        [Required(ErrorMessage = "Patient contact number is required.")]
        public string MobileNumber { get; set; }


        [Required(ErrorMessage = "Patient source is required.")]

        public int PatientSourceCode { get; set; }


        [MaxLength(150)]
        public string? PatientAddressLine1 { get; set; }


        [MaxLength(150)]
        public string? PatientAddressLine2 { get; set; }




        [MaxLength(150)]
        public string? PatientAddressLine3 { get; set; }



    }
}
