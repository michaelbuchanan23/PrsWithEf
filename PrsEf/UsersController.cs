using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsEf {

	public class UsersController {

		//this variable is how we get it to talk to entity framework
		private PrsDbContext db = new PrsDbContext();

		//the following methods of List, Get, Create, Change, and Remove are the easier versions of our controllers from the "CSharpToSQLLibrarySolution"
		public IEnumerable<User> List() {
			return db.Users.ToList();
		}

		//error check our web page on the final project so our program doesn't blow -- this is why we make it nullable with the ? below
		public User Get(int? id) {
			if(id == null) {
				return null;
			}
			//return db.Users.SingleOrDefault(u => u.Id == id); //I did it this way but Greg did it as shown on line below
			return db.Users.Find(id);
		}

		public bool Create(User user) {
			if (user == null) {
				return false;
			}
			db.Users.Add(user);
			db.SaveChanges();
			return true;
		}

		public bool Change(User user) {
			if (user == null) {
				return false;
			}
			var aUser = Get(user.Id);
			if(aUser == null) {
				return false;
			}
			aUser.Username = user.Username;
			aUser.Password = user.Password;
			aUser.Firstname = user.Firstname;
			aUser.Lastname = user.Lastname;
			aUser.Phone = user.Phone;
			aUser.Email = user.Email;
			aUser.IsReviewer = user.IsReviewer;
			aUser.IsAdmin = user.IsAdmin;
			aUser.Active = user.Active;
			db.SaveChanges();
			return true;
		}

		public bool Remove(User user) {
			if (user == null) {
				return false;
			}
			var aUser = Get(user.Id);
			if (aUser == null) {
				return false;
			}
			db.Users.Remove(user);
			db.SaveChanges();
			return true;
		}

		public UsersController() {}
	}
}