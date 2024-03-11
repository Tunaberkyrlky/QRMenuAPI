using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRMenuAPI.Data;
using QRMenuAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace QRMenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(ApplicationContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _userManager.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> GetApplicationUser(string id)
        {
       
            var applicationUser = await _userManager.FindByIdAsync(id);

            if (applicationUser == null)
            {
                return NotFound();
            }

            return applicationUser;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]                                                                   //do not change password using put
        public  ActionResult PutApplicationUser(string id, ApplicationUser applicationUser/*, string? password= null, string? currentPassword = null*/)
        {
            var existingApplicationUser = _userManager.FindByIdAsync(id).Result;

            existingApplicationUser.UserName = applicationUser.UserName;
            existingApplicationUser.Email = applicationUser.Email;
            existingApplicationUser.Name = applicationUser.Name;
            existingApplicationUser.PhoneNumber = applicationUser.PhoneNumber;
            existingApplicationUser.StateId = applicationUser.StateId;

            _userManager.UpdateAsync(existingApplicationUser).Wait();

            //if (password!=null)
            //{
            //    IdentityResult identityResult = _userManager.ChangePasswordAsync(existingApplicationUser, currentPassword, password);
            //}
            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> PostApplicationUser(ApplicationUser applicationUser, string password)
        {

            await _userManager.CreateAsync(applicationUser, password);
           
            return CreatedAtAction("GetApplicationUser", new { id = applicationUser.Id }, applicationUser);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationUser(string id)
        {
            var applicationUser = await _userManager.FindByIdAsync(id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            //Hard delete
            //await _userManager.DeleteAsync(applicationUser);

            //Soft delete
            applicationUser.StateId = 0;
            await _userManager.UpdateAsync(applicationUser);
            return NoContent();
        }

        private bool ApplicationUserExists(string id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
