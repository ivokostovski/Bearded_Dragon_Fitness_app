using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.Models;

namespace Fitness.Repo
{
    public class FitnessRepo : IDisposable
    {
        private FitnessRegisterDb db;
        
        public FitnessRepo()
        {
            db = new FitnessRegisterDb();
        }

        public static void InitializeDatabase()
        {
            Database.SetInitializer(new FitnessRegisterDbInitializer());
        }

        public void Add(Trainer trainer)
        {
            db.Trainers.Add(trainer);
            db.SaveChanges();
        }

        public List<Trainer> GetAll()
        {
            try
            {
                return db.Trainers.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Trainer> GetAll(string searchCriteria)
        {
            try
            {
                return string.IsNullOrEmpty(searchCriteria)
                    ? db.Trainers.ToList()
                    : db.Trainers.Where(trainer => trainer.FullName.Contains(searchCriteria)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Trainer Find(int id)
        {
            return db.Trainers.Include("TrainingType")
                .SingleOrDefault(trainer => trainer.TrainerId == id);
        }

        public void Edit(Trainer trainer)
        {
            db.Entry(trainer).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Remove(int id)
        {
            Trainer trainer = db.Trainers.Find(id);
            db.Trainers.Remove(trainer);
            db.SaveChanges();
        }

        //Training Types

        public List<TrainingType> GetAllTrainingTypes()
        {
            try
            {
                return db.TrainingTypes.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddTrainingType(TrainingType trainingType)
        {
            db.TrainingTypes.Add(trainingType);
            db.SaveChanges();
        }

        public List<TrainingType> GetAllTrainingTypes(string searchCriteria)
        {
            try
            {
                return string.IsNullOrEmpty(searchCriteria)
                    ? db.TrainingTypes.ToList()
                    : db.TrainingTypes.Where(trainingType => trainingType.Name.Contains(searchCriteria)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TrainingType FindTrainingType(int id)
        {
            return db.TrainingTypes
                .SingleOrDefault(trainingType => trainingType.TrainingTypeId == id);
        }

        public void EditTrainingType(TrainingType trainingType)
        {
            db.Entry(trainingType).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveTrainingType(int id)
        {
            TrainingType trainingType = db.TrainingTypes.Find(id);
            db.TrainingTypes.Remove(trainingType);
            db.SaveChanges();
        }

        //Schedules

        public List<Schedule> GetAllSchedules()
        {
            try
            {
                return db.Schedules.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddSchedule(Schedule schedule)
        {
            db.Schedules.Add(schedule);
            db.SaveChanges();
        }

        //public List<Schedule> GetAllSchedules(string searchCriteria)
        //{
        //    try
        //    {
        //        return string.IsNullOrEmpty(searchCriteria)
        //                   ? db.Schedules.ToList()
        //                 : db.Schedules.Where(schedule => schedule.Days.Contains(searchCriteria)).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public Schedule FindSchedule(int id)
        {
            return db.Schedules
                .SingleOrDefault(schedule => schedule.ScheduleId == id);
        }

        public void EditSchedule(Schedule schedule)
        {
            db.Entry(schedule).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveSchedule(int id)
        {
            Schedule schedule = db.Schedules.Find(id);
            db.Schedules.Remove(schedule);
            db.SaveChanges();
        }


        //Dispose

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
