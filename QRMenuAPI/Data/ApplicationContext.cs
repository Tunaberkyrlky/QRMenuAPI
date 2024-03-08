using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using QRMenuAPI.Models;
using QRMenuQPI.Models;

namespace QRMenuAPI.Data
{
	public class ApplicationContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
		}
		public DbSet<Company>? Companies { get; set; }
        public DbSet<State>? States { get; set; }
    }
}

