using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WEP_API_001.Models;

namespace WEP_API_001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private string connectionString = WebApplication.CreateBuilder().Configuration.GetConnectionString("DefaultConnection");

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "Select * from Employees";
                var emps = connection.Query<Employee>(query).ToList();
                
                return Ok(emps);
            }
        }
        [HttpPost]
        public IActionResult CreateEmployee([FromForm]EmployeeDTO employeeDTO)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string insertQuery = @$"Insert into Employees(Name,Surname,Email,Login,Password,Status,Role,CreatedDate)
                                        Values('{employeeDTO.Name}'
                                        ,'{employeeDTO.Surname}'
                                        ,'{employeeDTO.Email}'
                                        ,'{employeeDTO.Login}'
                                        ,'{employeeDTO.Password}'
                                        ,{(int)Employee.Status_Enum.Created}
                                        ,{(int)employeeDTO.Role}
                                        ,'{DateTime.Now.ToString("dd.MM.yy")}');";
                connection.Execute(insertQuery);

                return Ok("Employee Created");
            }
        }

        [HttpGet("GetMulti")]
        public async Task<IActionResult> GetAllMultipleQueryEmployees()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = @"Select * from Employees;
                                 Select * from Staffs";

                var emps = await connection.QueryMultipleAsync(query);

                var firstTable = emps.ReadAsync<Employee>().Result;
                var secound = emps.ReadAsync<Staffs>().Result;
                return Ok(secound);
            }
        }
    }
}
