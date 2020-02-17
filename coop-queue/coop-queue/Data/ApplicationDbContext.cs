using System;
using System.Collections.Generic;
using System.Text;
using CoQ.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace coop_queue.Data
{
	public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{  }
    }
}
