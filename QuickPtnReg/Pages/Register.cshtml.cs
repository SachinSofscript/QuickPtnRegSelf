using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace QuickPtnReg.Pages
{
   

    public class RegisterModel : PageModel
    {
        [BindProperty]
        public PatientModel Patient { get; set; }

        public List<DepartmentModel> Departments { get; set; }
        public List<PatientSourceModel> PatientSources { get; set; }

        private readonly IConfiguration _configuration;

        public RegisterModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public IActionResult OnGet()
        {
            Patient= new PatientModel();

            LoadDepartments();
            LoadPatientSourceCodes();
            return Page();
        }


       
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                LoadDepartments();
                LoadPatientSourceCodes();
                return Page();
                //return BadRequest(ModelState);
            }


            using (var connection = new SqlConnection(_configuration.GetConnectionString("HospitalDatabase")))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        Patient.PatientNo = GenerateNextPatientNo(connection,  transaction);
                        InsertPatient(connection, transaction);
                        transaction.Commit();

                        return new JsonResult(new { success = true, message = "Patient registered successfully!", Patient.PatientNo, Patient.PatientFullName });

                        //return RedirectToPage("/Index");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

           
        }

        private void LoadDepartments()
        {
            Departments = new List<DepartmentModel>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("HospitalDatabase")))
            {
                connection.Open();
                using (var command = new SqlCommand("spGetDocSpecialities", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Departments.Add(new DepartmentModel
                            {
                                Code = reader["cd"].ToString(),
                                Name = reader["dcd"].ToString()
                            });
                        }
                    }
                }
            }
        }

        private void LoadPatientSourceCodes()
        {
            PatientSources = new List<PatientSourceModel>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("HospitalDatabase")))
            {
                connection.Open();
                using (var command = new SqlCommand("spGetPatientSources", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PatientSources.Add(new PatientSourceModel
                            {
                                Code = reader["cd"].ToString(),
                                Name = reader["dcd"].ToString()
                            });
                        }
                    }
                }
            }
        }

        private long GenerateNextPatientNo( SqlConnection connection,  SqlTransaction transaction)
        {
            long _result = 0;

            using (var command = new SqlCommand("SpSelUpdAdtDcNos", connection,transaction))
            {
                command.CommandType = CommandType.StoredProcedure;
                //command.Transaction = transaction;
                command.Parameters.AddWithValue("@cocd", '1');
                command.Parameters.AddWithValue("@divcd", 1);
                command.Parameters.AddWithValue("@loccd", 1);
                command.Parameters.AddWithValue("@DocTypeID", 11);
                command.Parameters.AddWithValue("@crtdttm",DateTime.Now );
                command.Parameters.AddWithValue("@crtusrid", "WEBPORTAL");
                //command.ExecuteReader();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _result = long.Parse(reader["srno"].ToString());

                       
                    }
                }
            }
            return _result;
        }



        private void InsertPatient( SqlConnection connection,  SqlTransaction transaction)
        {



            using (var command = new SqlCommand("SpInsPtnQuickReg", connection, transaction))
            {
                //command.Transaction = transaction;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PatientNo", Patient.PatientNo);
                command.Parameters.AddWithValue("@FullName", Patient.PatientFullName);
                command.Parameters.AddWithValue("@FatherName", Patient.PatientMiddleName);
                command.Parameters.AddWithValue("@Age", Patient.Age);
                command.Parameters.AddWithValue("@Sex", Patient.sex);
                command.Parameters.AddWithValue("@DocSpltyCd", Patient.Department);
                command.Parameters.AddWithValue("@MobileNo", Patient.MobileNumber);
                command.Parameters.AddWithValue("@patientSourceCode", Patient.PatientSourceCode);
                command.ExecuteNonQuery();
            }

        }
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

    //public class PatientModel
    //{




    //    public long PatientNo { get; set; } // anamika 20160902

    //    public int PatientTitleCode { get; set; }

    //    public string PatientTitleCodeDesc { get; set; }

    //    public string PatientFirstName { get; set; }

    //    public string PatientMiddleName { get; set; }

    //    public string PatientLastName { get; set; }

    //    public string PatientFullName { get; set; }

    //    public string Gender { get; set; }

    //    public DateTime? BirthDate { get; set; }

    //    public string Age { get; set; }

    //    public int AgeYY { get; set; } // anamika 20131210
    //                                   // 
    //                                   // Public Property InPatientNo() As Integer

    //    public long InPatientNo { get; set; } // anamika 20160907

    //    public int DayCareNo { get; set; }

    //    public bool Status { get; set; }

    //    public bool IsMember { get; set; }

    //    public string MembershipID { get; set; }

    //    public int MRNo { get; set; }

    //    public string EMPNo { get; set; }

    //    public int NtnltyCd { get; set; }

    //    public int DocCd { get; set; }

    //    public string MobileNumber { get; set; }

    //    public string MobileNumber2 { get; set; } // anamika 20160802

    //    public string WhatsAppNo { get; set; } // anamika 20160802

    //    public string Email { get; set; }

    //    public DateTime CrtDtTm { get; set; }

    //    public DateTime VisitCompletedTm { get; set; }
    //    // mayur 20131220

    //    public string SSno { get; set; }

    //    public string peraddress1 { get; set; }

    //    public string prmnt_addrs2 { get; set; }

    //    public string prmnt_pin { get; set; }


    //    public string prmnt_tel { get; set; }

    //    public int prmnt_cntry { get; set; }  
    //    public string city { get; set; }


    //    public int BillTyp { get; set; }

    //    public string TYPFLG { get; set; }

    //    public DateTime EXPDT { get; set; }

    //    public DateTime UserDtTm { get; set; }

    //    public string UserId { get; set; }

    //    public long ArCd { get; set; }


    //    public string prmnt_addrs3 { get; set; }

    //    public int Agemm { get; set; }

    //    public int Agedd { get; set; }

    //    public int cityCode { get; set; }

    //    public int StateCode { get; set; }
    //    // end mayur 20140117

    //    public int VisitNo { get; set; }  

    //    public string FreeFlg { get; set; }  

    //    public int ClncCd { get; set; }  

    //    public int VchrNo { get; set; }  

    //    public string TokenNo { get; set; }   

    //    public double DepositBal { get; set; }  

    //    public bool IsPtnBlackListed { get; set; }  


    //    public char Aadhar { get; set; }  

    //    public int CseTypCd { get; set; }  

    //    public string PanNo { get; set; } // RasikV 20180113

    //    public string Address { get; set; } // RasikV 20180113

    //    public string ArEmpcd { get; set; } // Rushikesh 20190731

    //    public int PtnRefByTyp { get; set; } // Rushikesh 20190731

    //    public string PtnRefBycd { get; set; } // Rushikesh 20190731


    //    public string PtnBlackListedRsn { get; set; } // shital 20191220


    //    public string PtnRmrk { get; set; } // Nikita 20200117

    //    public int CampCd { get; set; }


    //    public int MapConcType { get; set; }  // Amol 24-03-2020 CMCH-141969


    //    public string Agetypflg { get; set; }



    //    public int istranblocked { get; set; }



    //    public string PtnCareModelRmrk { get; set; }



    //    public string PtnCareModelDCd { get; set; }


    //    public string PtnCareModelDescRmrk { get; set; }


    //    public string PtnType { get; set; }


    //    public long PrmntPtnno { get; set; }


    //    public int BillType { get; set; }

    //    public char NRI { get; set; }

    //    public char RegTypFlg { get; set; }
    //}

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

}
