using static WEP_API_001.Models.Employee;

namespace WEP_API_001.Models
{
    public class EmployeeDTO
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role_Enum Role { get; set; }

    }
}
