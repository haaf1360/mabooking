using Mabooking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Mabooking.Models
{
    public class DataContext:DbContext
    {
        public DbSet<FlightsSchedule> ScheduleCollection { get; set; }

        public DbSet<Routs> RoutsCollection { get; set; }

        public DbSet<Reserv> ReservCollection { get; set; }

        public DataContext():base("MyConnectionString")
        {

        }

        public System.Data.Entity.DbSet<Mabooking.Models.Entities.Customer> Customers { get; set; }
    }

}