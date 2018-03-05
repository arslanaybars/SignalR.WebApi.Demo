using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SignalR.WebApi.Demo.Data
{
    public class DemoContext : DbContext
    {
        public DemoContext() : base("MAIN")
        {

        }

        public DbSet<Form> Forms { get; set; }

        public DbSet<User> Users { get; set; }

    }
}