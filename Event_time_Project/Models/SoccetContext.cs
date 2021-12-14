using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Event_time_Project.Models
{
    public class SoccetContext :DbContext
    {
        public SoccetContext() : base("IdentityDb")
        {

        }
        public DbSet<Category_Task> Category_Tasks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Organization> Organizations { get; set; }

    }
}