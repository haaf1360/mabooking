using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mabooking.Models.Entities
{
    public class Customer
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Family { get; set; }

        public string Mobile { get; set; }

        public string AgentName { get; set; }

        public DateTime CreateDate { get; set; }

      

        //ارتباط با Reserv 
        //Navigate property
        public virtual ICollection<Reserv> ReservColection { get; set; }
        public object SchemeMasters { get; internal set; }


        //initioalize
        public Customer()
        {
            ReservColection = new List<Reserv>();
        }

    }
}