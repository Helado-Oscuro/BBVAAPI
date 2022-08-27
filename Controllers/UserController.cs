using BBVA.Models;
using BBVA.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BBVA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private BankContext _context;
        private HttpClient _httpClient;

        public UserController(BankContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
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

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            var user = _context.User.FirstOrDefault(x => x.Id == id);
            _context.User.Remove(user);
            _context.SaveChanges();
            return Ok();
        }


        [HttpGet]
        [Route("dni")]
        public async Task<User> GetUserByDniAsync([FromQuery] string dni)
        {
            var user = _context.User.First(x => x.DNI == dni);

            if (user == null)
            {
                var response = await _httpClient.GetAsync($"https://api.reniec.online/dni/{dni}");
                var content = await response.Content.ReadFromJsonAsync<UserFromReniec>();
                if (content != null)
                {
                    user = new User(content.dni,
                        $"{content.nombres} {content.apellido_paterno} {content.apellido_materno}", false);
                }
            }

            return user;
        }
    }
}