﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsEf {

	public class User { //public here allows us to access this class outside of namespace -- defaults to internal meaning it can only be used in this namespace

		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public bool IsReviewer { get; set; }
		public bool IsAdmin { get; set; }
		public bool Active { get; set; }

		public User() {

		}
	}
}
