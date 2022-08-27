using BBVA.Models;
using BBVA.src.user.domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BBVA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private BankContext _context;

        public UserController(BankContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IList<User> GetAll()
        {
            return _context.User.ToList();
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut] // by id
        public IActionResult Update([FromBody] User user)
        {
            _context.User.Update(user);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete] // by id
        public IActionResult Delete(int id)
        {
            var user = _context.User.FirstOrDefault(x => x.Id == id);
            _context.User.Remove(user);
            _context.SaveChanges();
            return Ok();
        }
    }
}