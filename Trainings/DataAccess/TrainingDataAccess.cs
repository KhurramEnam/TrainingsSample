using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Trainings.Models;

namespace Trainings.DataAccess
{
    public class TrainingDataAccess : DbContext
    {
        public DbSet<Trainings.Models.Trainings> Trainings { get; set; } 



    }
}