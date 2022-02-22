using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestForIntegrium.WebApi.EF;
using TestForIntegrium.WebApi.Models;

namespace TestForIntegrium.WebApi.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            User user = _context.Users.FirstOrDefault(u => u.UserId == id);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            if (user != null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            if (user != null)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _context.Users.Remove(new User{UserId = id});
            _context.SaveChanges();
            return Ok(true);
        }
    }
}
