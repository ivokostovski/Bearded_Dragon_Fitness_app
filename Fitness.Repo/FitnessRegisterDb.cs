using Fitness.Models;
using System.Data.Entity;

namespace Fitness.Repo
{
    internal class FitnessRegisterDb : DbContext
    {
        public DbSet<Trainer> Trainers { get; set; }

        public DbSet<TrainingType> TrainingTypes { get; set; }

        public DbSet<Schedule> Schedules { get; set; }
    }
}
