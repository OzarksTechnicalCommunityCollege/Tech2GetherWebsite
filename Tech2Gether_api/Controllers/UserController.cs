using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tech2Gether_api.Data;

namespace Tech2Gether_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // Database connection
        private readonly T2TContext _context;

        // Constructor
        public UserController(T2TContext context)
        {
            _context = context;
        }

        // Get: api/users
        [HttpGet("GetAllUsers", Name = "GeetAllUsers")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

    }
}
