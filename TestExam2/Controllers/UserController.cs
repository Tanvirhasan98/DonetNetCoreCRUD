using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestExam2.DataContext;
using TestExam2.Models;

namespace TestExam2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDataContext _context;

        public UserController(UserDataContext context)
        {
            _context = context;

        }

        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser()
        {
            var user = _context.Registrations.ToList();
            return Ok(user);
        }


        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(RegistrationModel model)
        {
            model.memberSince = DateTime.Now;
            _context.Registrations.Add(model);
            _context.SaveChanges();
            return Ok("User Added SuccessFully!!");

        }

        [HttpDelete]
        [Route("DeleteAnItem")]
        public IActionResult DeleteAnItem(int id)
        {
            var user = _context.Registrations.FirstOrDefault(m => m.Id == id);
            _context.Registrations.Remove(user);
            _context.SaveChanges();
            return Ok("SuccessFully Removed");
        }
    }
}
