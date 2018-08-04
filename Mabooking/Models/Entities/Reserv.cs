using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mabooking.Models.Entities
{
    [Table("Reserv", Schema = "Flight")]
    public class Reserv
    {

        public long id { get; set; }

        public long Customer_Id { get; set; }
        [ForeignKey("Customer_Id")]
        public virtual Customer Customer { get; set; }

        public long FlightsSchedule_Id { get; set; }

        [ForeignKey("FlightsSchedule_Id")]
        public virtual FlightsSchedule FlightsSchedule { get; set; }
        public decimal Weight { get; set; }
        public int Pcs { get; set; }

        public string ULD { get; set; }

        public string Description { get; set; }

        public int UserName { get; set; }
        public bool Canceled { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime CreateDate { get; set; }

        public Reserv()
        {
            CreateDate = DateTime.Now;
        }


    }
}