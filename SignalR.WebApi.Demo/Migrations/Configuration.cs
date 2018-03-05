namespace SignalR.WebApi.Demo.Migrations
{
    using SignalR.WebApi.Demo.Data;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SignalR.WebApi.Demo.Data.DemoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        // Dummy data
        protected override void Seed(DemoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            #region User Initializer

            var aybars = new User { Name = "Aybars", Age = 25, IsAdmin = true };
            var sefa = new User { Name = "Sefa", Age = 24, IsAdmin = false };
            var leonardo = new User { Name = "Leonardo", Age = 33, IsAdmin = true };

            var users = new List<User>
            {
                aybars, sefa, leonardo
            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            #endregion

            #region Form Initializer

            var forms = new List<Form>
            {
                new Form {Title = "First Form", Description = "First Form Description", Content = "First Form Description", CreateTime = DateTime.Now.AddDays(-10),Users = users},
                new Form { Title = "Second Form", Description = "Second Form Description", Content = "Second Form Description", CreateTime = DateTime.Now.AddDays(-5),Users = users },
                new Form { Title = "Third Form", Description = "Third Form Description", Content = "Third Form Description", CreateTime = DateTime.Now,Users = users }
            };

            forms.ForEach(r => context.Forms.Add(r));
            context.SaveChanges();

            #endregion


            // can be better
            #region Realtion Initializer

            var dbUsers = context.Users;
            foreach (var user in dbUsers)
            {
                user.Forms = forms;
            }
            context.SaveChanges();

            #endregion


        }

    }
}
