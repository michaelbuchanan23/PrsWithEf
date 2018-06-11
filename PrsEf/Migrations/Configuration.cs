namespace PrsEf.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PrsEf.PrsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false; //allows for every time you change your model it will migrate again
        }

        protected override void Seed(PrsEf.PrsDbContext context) //this will seed the table with data (e.g., a new user admin each time table created)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
