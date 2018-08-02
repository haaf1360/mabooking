using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mabooking.Models.Entities
{
    [Table("Routs",Schema="Flight")]
    public class Routs
    {
      
        public long Id { get; set; }

        public string FlightNumber    { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public bool Delete { get; set; }


        //ارتباط با flight schedule 
        //Navigate property  مجموعه ای از مسیرها ارتباط دارند یزاس راحتی
        public virtual ICollection<FlightsSchedule> ScheduleCollection { get; set; }
        public object SchemeMasters { get; internal set; }


        //initioalize
        public Routs()
        {
            ScheduleCollection = new List<FlightsSchedule>();
        } 




    }
}