namespace WEP_API_001.Models;


public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public Status_Enum Status { get; set; }
    public Role_Enum Role { get; set; }
    public string? CreatedDate { get; set; }
    public string? ModifyDate { get; set; }
    public string? DeletedDate { get; set; }
    public enum Status_Enum
    {
        Created = 1,
        Updated,
        Deleted,
    }
    public enum Role_Enum
    {
        Admin = 1,
        Programmer,
        Officeer,
        Cleaner,
        Recruiter
    }
}


