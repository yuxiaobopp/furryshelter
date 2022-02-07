using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApplication.DbModels;

namespace WebApplication.Controllers
{
    [Route("Api/login")]
    public class LoginController : ControllerBase
    {
        private readonly ApiContext _context;

        [Route("InsertEmployee")]
        [HttpPost]
        public object InsertEmployee(Register Reg)
        {
            try
            {
                if (Reg.Id == 0)
                {
                    Reg.EmployeeName = Reg.EmployeeName;
                    Reg.City = Reg.City;
                    Reg.Email = Reg.Email;
                    Reg.Password = Reg.Password;
                    Reg.Department = Reg.Department;
                    _context.Users.Add(Reg);
                    _context.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "Record SuccessFully Saved." };
                }
            }
            catch (Exception)
            {

                throw;
            }
            return new Response
            { Status = "Error", Message = "Invalid Data." };
        }
        [Route("Login")]
        [HttpPost]
        public Response employeeLogin(Login login)
        {
            var log = _context.Users.Where(x => x.Email.Equals(login.Email) &&
                      x.Password.Equals(login.Password)).FirstOrDefault();

            if (log == null)
            {
                return new Response { Status = "Invalid", Message = "Invalid User." };
            }
            else
                return new Response { Status = "Success", Message = "Login Successfully" };
        }
    }

}
