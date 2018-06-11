using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsEf {
	public class PrsDbContext: DbContext {

		public PrsDbContext() : base() { }

		public DbSet<User> Users { get; set; } //adds the table that you are using so it can be accessed, viewed, etc.
		public DbSet<Vendor> Vendors { get; set; }
		public DbSet<Product> Products { get; set; }
	}
}
