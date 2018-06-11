using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrsEf;

namespace PrsWithEf {

	class Program {

		private static PrsDbContext db = new PrsDbContext();

		static void Main(string[] args) {
			var users = db.Users.ToList(); //"var" is generic type for List<User> -- you can see this by hovering over "users"

			//testing to see if the program works up to this point
				//foreach (var user in users) {
				//	Console.WriteLine($"{user.Firstname}");

			//finds the user with a primary key of Id=1
			User user = db.Users.Find(1);

			//the below statement will return a null value because there is no user with a primary key id of "111"
			//User nouser = db.Users.Find(111);

			//adds a new user
			//User adduser = new User {
			//	Username = "user2",
			//	Password = "password",
			//	Firstname = "user",
			//	Lastname = "two",
			//	Phone = "123-5555",
			//	Email = "user2@a.com",
			//	IsReviewer = true,
			//	IsAdmin = true,
			//	Active = true
			//};
			//User addedUser = db.Users.Add(adduser);

			//save changes to the database
			//db.SaveChanges(); //adds the above user to the database

			//Removes the user that was added above
			//db.Users.Remove(addedUser);

			//save changes to the database
			//db.SaveChanges();

			//edit the user2 added earlier
			User u1 = db.Users.SingleOrDefault(u => u.Email == "user2@a.com"); //find a user by their email via this method -- only returns 1st value
				/*
				 * the above is equal to the following:
				 *	
				 *	foreach(var u in Users) {
				 *		if(u.email == "user2@a.com) {
				 *			return u;
				 *		}
				 *	}	
				 */
			u1.IsAdmin = false;

			//can also use the below method to replace the phone number
			u1.Phone = u1.Phone.Replace(u1.Phone,"1234"); //replaces the old u1.Phone number with that in the string

			//save changes to the database
			db.SaveChanges();
		}
	}
}

