using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mabooking.Models.Entities
{
    [Table("Schedule", Schema = "Flight")]
    public class FlightsSchedule
    {
        public long id { get; set; }

        public DateTime FltDate { get; set; }

        public string FltReg  { get; set; }

        public decimal FltCapVol { get; set; }

        public int FltCapWeight{ get; set; }

        public bool Active { get; set; }

        public DateTime CreateDate { get; set; }

        public long Routs_Id { get; set; }

        [ForeignKey("Routs_Id")]    
        public virtual Routs Routs { get; set; }


        //Constractor برای مقدار دهی اولیه
        public FlightsSchedule()
        {
            CreateDate = DateTime.Now;
        }

    }
}