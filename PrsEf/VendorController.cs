using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsEf
{
	public class VendorController {

		//this variable is how we get it to talk to entity framework
		private PrsDbContext db = new PrsDbContext();

		//the following methods of List, Get, Create, Change, and Remove are the easier versions of our controllers from the "CSharpToSQLLibrarySolution"
		public IEnumerable<Vendor> List() {
			return db.Vendors.ToList();
		}

		//error check our web page on the final project so our program doesn't blow -- this is why we make it nullable with the ? below
		public Vendor Get(int? id) {
			if (id == null) {
				return null;
			}
			//return db.Users.SingleOrDefault(u => u.Id == id); //I did it this way but Greg did it as shown on line below
			return db.Vendors.Find(id);
		}

		public bool Create(Vendor vendor) {
			if (vendor == null) {
				return false;
			}
			db.Vendors.Add(vendor);
			db.SaveChanges();
			return true;
		}

		public bool Change(Vendor vendor) {
			if (vendor == null) {
				return false;
			}
			var aVendor = Get(vendor.Id);
			if (aVendor == null) {
				return false;
			}
			aVendor.Code = vendor.Code;
			aVendor.Name = vendor.Name;
			aVendor.Address = vendor.Address;
			aVendor.City = vendor.City;
			aVendor.State = vendor.State;
			aVendor.Zip = vendor.Zip;
			aVendor.Phone = vendor.Phone;
			aVendor.Email = vendor.Email;
			aVendor.IsPreApproved = vendor.IsPreApproved;
			aVendor.Active = vendor.Active;
			db.SaveChanges();
			return true;
		}

		public bool Remove(Vendor vendor) {
			if (vendor == null) {
				return false;
			}
			var aVendor = Get(vendor.Id);
			if (aVendor == null) {
				return false;
			}
			db.Vendors.Remove(vendor);
			db.SaveChanges();
			return true;
		}

		public VendorController() { }
	}
}
