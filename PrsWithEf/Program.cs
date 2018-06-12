using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrsEf;

namespace PrsWithEf {

	class Program {

		private static PrsDbContext db = new PrsDbContext();
		
		void LinqExamples() {
			//examples for LINQ
			int[] nbrs = { 7, 7, 14, 13, 1, 11, 12, 3, 20, 10, 1, 10, 18, 17, 14, 15, 6, 14, 20, 13 };

			//calculte sum of above integers
			var total = nbrs.Sum();

			//calculate sum of number where numbers are greater than 10
			total = nbrs.Where(i => i >= 10).Sum();

			//calculate total with odd numbers
			total = nbrs.Where(i => i % 2 == 1).Sum(); //where returns a collection

			var sortedNbrs = nbrs.OrderBy(i => i); //same as Array.Sort(nbrs); but gives you flexibility to sort via columns if you said i.Username or something
			sortedNbrs = nbrs.OrderByDescending(i => i); //orders teh above sortedNbrs in reverse order from high to low (i.e., Array.Reverse(nbrs))

			var subsetArray = nbrs.Where(i => i % 3 == 0).ToArray();
			var subsetList = nbrs.Where(i => i % 3 == 0).ToList(); //this may tell you it's not the correct type

			//count of numbers greater than 5 and less than or equal to 15 in the nbrs array
			var Count = nbrs.Where(i => i > 5 && i <= 15).Count();

			//also note there are min and max methods you can use as well
		}

		void CalcPrTotal() { //calculates the total for a purchase request

			//get the purchase request id based on the description and set that id in  var prid
			var prid = db.PurchaseRequests.SingleOrDefault(p => p.Description == "3-5-7 Class Exercise").Id;

			//sum the total of all line items based on the prid variable above
			var total = db.PurchaseRequestLineitems
				.Where(p1 => p1.PurchaseRequestId == prid)
				.Sum(li => li.Product.Price * li.Quantity);

			var pr = db.PurchaseRequests.SingleOrDefault(fred => fred.Id == prid);
			pr.Total = total;
			db.SaveChanges();
			Console.WriteLine($"Total: {total}");
		}

		static void Main(string[] args) {

			(new Program()).CalcPrTotal();
		}
		static void run() { }


            //adding a new purchase request line item
                //var prli1 = new PurchaseRequestLineitem {
                //    Description = "we need this for the office",
                //    Quantity = 2,
                //    ProductId = db.Products.SingleOrDefault(p => p.PartNumber == "Echo").Id,
                //    PurchaseRequestId = db.PurchaseRequests.SingleOrDefault(pr => pr.Description == "First PR").Id
                //};
                //db.PurchaseRequestLineitems.Add(prli1);
                //db.SaveChanges();
                //db = new PrsDbContext();  //refreshing the database which can be handy if you add a user and then add something tied to that user


            //adding a new purchase request
                //var pr1 = new PurchaseRequest {
                //    Description = "Fourth PR",
                //    Justification = "",
                //    DeliveryMode = "Pickup",
                //    UserId = db.Users.SingleOrDefault(u => u.Username == "user").Id   //add the UserId where username is equal to user
                //};
                //db.PurchaseRequests.Add(pr1);
                //db.SaveChanges();
                //db = new PrsDbContext();  //refreshing the database which can be handy if you add a user and then add something tied to that user

            //creating a new product
                //var pEchoDot = new Product {
                //	Name = "Echo Dot",
                //	PartNumber = "EDOT",
                //	Price = 39.99,
                //	Unit = "Each",
                //	PhotoPath = null,
                //	VendorId = 1,
                //	Active = true,
                //	Vendor = null //make sure to nullify vendor instance so you don't accidentally add or change a vendor -- do this while reading
                //};
                //db.Products.Add(pEchoDot);
                //db.SaveChanges();
            //end creating a new product

            //checking to see if our foreign key works via the Amazon Echo entry we put in via SQL Server program
				//var products = db.Products.ToList();
				//var product = products[0]; //get the product instance at the 0 index spot in the array products
				//var vendorName = product.Vendor.Name; //get vendor's name from the array


				//var users = db.Users.ToList(); //"var" is generic type for List<User> -- you can see this by hovering over "users"

			//testing to see if the program works up to this point
				//foreach (var user in users) {
				//	Console.WriteLine($"{user.Firstname}");

			//finds the user with a primary key of Id=1
				//User user = db.Users.Find(1);

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
				//User u1 = db.Users.SingleOrDefault(u => u.Email == "user2@a.com"); //find a user by their email via this method -- only returns 1st value
				/*
				 * the above is equal to the following:
				 *	
				 *	foreach(var u in Users) {
				 *		if(u.email == "user2@a.com) {
				 *			return u;
				 *		}
				 *	}	
				 */

			//changing u1 property IsAdmin to false
				//u1.IsAdmin = false;

			//can also use the below method to replace the phone number
				//u1.Phone = u1.Phone.Replace(u1.Phone,"123-4564"); //replaces the old u1.Phone number with that in the string

			//save changes to the database
				//db.SaveChanges();
		}
	}

