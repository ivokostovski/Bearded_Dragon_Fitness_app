using Fitness.Models;
using Fitness.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Services
{
    public class FitnessManager
    {
        public static void InitializeDatabase()
        {
            FitnessRepo.InitializeDatabase();
        }

        public void Create(Trainer trainer)
        {
            using (var dataAccess = new FitnessRepo())
            {
                dataAccess.Add(trainer);
            }
        }

        public List<Trainer> ReturnAll()
        {
            using (var dataAccess = new FitnessRepo())
            {
                return dataAccess.GetAll();
            }

        }
        
        public Trainer Return(int trainerId)
        {
            using (var dataAccess = new FitnessRepo())
            {
                return dataAccess.Find(trainerId);
            }
        }

        public List<Trainer> ReturnAll(string searchCriteria = null)
        {
            using (var dataAccess = new FitnessRepo())
            {
                return dataAccess.GetAll(searchCriteria);
            }
        }

        public void Update(Trainer trainer)
        {
            using (var dataAccess = new FitnessRepo())
            {
                dataAccess.Edit(trainer);
            }
        }

        public void Delete(int trainerId)
        {
            using (var dataAccess = new FitnessRepo())
            {
                dataAccess.Remove(trainerId);
            }
        }


        //Training Types

        public List<TrainingType> ReturnAllTrainingTypes()
        {
            using (var dataAccess = new FitnessRepo())
            {
                return dataAccess.GetAllTrainingTypes();
            }
        }

        public void CreateTrainingType(TrainingType trainingType)
        {
            using (var dataAccess = new FitnessRepo())
            {
                dataAccess.AddTrainingType(trainingType);
            }
        }

        public TrainingType ReturnTrainingType(int trainingTypeId)
        {
            using (var dataAccess = new FitnessRepo())
            {
                return dataAccess.FindTrainingType(trainingTypeId);
            }
        }

        public List<TrainingType> ReturnAllTrainingTypes(string searchCriteria = null)
        {
            using (var dataAccess = new FitnessRepo())
            {
                return dataAccess.GetAllTrainingTypes(searchCriteria);
            }
        }

        public void UpdateTrainingType(TrainingType trainingType)
        {
            using (var dataAccess = new FitnessRepo())
            {
                dataAccess.EditTrainingType(trainingType);
            }
        }

        public void DeleteTrainingType(int trainingTypeId)
        {
            using (var dataAccess = new FitnessRepo())
            {
                dataAccess.RemoveTrainingType(trainingTypeId);
            }
        }

        //Schedules

        public List<Schedule> ReturnAllSchedules()
        {
            using (var dataAccess = new FitnessRepo())
            {
                return dataAccess.GetAllSchedules();
            }
        }

        public void CreateSchedule(Schedule schedule)
        {
            using (var dataAccess = new FitnessRepo())
            {
                dataAccess.AddSchedule(schedule);
            }
        }

        public Schedule ReturnSchedule(int scheduleId)
        {
            using (var dataAccess = new FitnessRepo())
            {
                return dataAccess.FindSchedule(scheduleId);
            }
        }

        //public List<Schedule> ReturnAllSchedules(string searchCriteria = null)
        //{
        //    using (var dataAccess = new FitnessRepo())
        //    {
        //        return dataAccess.GetAllSchedules(searchCriteria);
        //    }
        //}

        public void UpdateSchedule(Schedule schedule)
        {
            using (var dataAccess = new FitnessRepo())
            {
                dataAccess.EditSchedule(schedule);
            }
        }

        public void DeleteSchedule(int scheduleId)
        {
            using (var dataAccess = new FitnessRepo())
            {
                dataAccess.RemoveSchedule(scheduleId);
            }
        }
    }
}
