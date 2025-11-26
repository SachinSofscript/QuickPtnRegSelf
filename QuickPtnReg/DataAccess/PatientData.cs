using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using QuickPtnReg.Models;
using QuickPtnReg.Pages;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace QuickPtnReg.DataAccess
{
    public class PatientData
    {   
        private readonly IConfiguration _configuration;

        public PatientData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<DepartmentModel>  GetDepartments()
        {
            var Departments = new List<DepartmentModel>();

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

            return Departments;
        }

     


    }
}
