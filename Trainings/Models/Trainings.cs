using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trainings.Models
{
    public class Trainings
    {
        [Key]
        public int RecordID { get; set; }

        public string TrainingName { get; set; }

        public DateTime StartDate { get; set; }


        public DateTime EndDate { get; set; }
    }
}