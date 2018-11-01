using Fitness.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainersManager
{
    public class TrainersManager
    {
        public static void InitializeDatabase()
        {
            TrainersRepo.InitializeDatabase();
        }

        public void Create(Trainer trainer)
        {
            using (var dataAccess = new TrainersRepo())
            {
                dataAccess.Add(trainer);
            }
        }

        public List<Trainer> ReturnAll()
        {
            using (var dataAccess = new TrainersRepo())
            {
                return dataAccess.GetAll();
            }

        }


        public Trainer Return(int trainerId)
        {
            using (var dataAccess = new TrainersRepo())
            {
                return dataAccess.Find(trainerId);
            }
        }

        public List<Trainer> ReturnAll(string searchCriteria = null)
        {
            using (var dataAccess = new TrainersRepo())
            {
                return dataAccess.GetAll(searchCriteria);
            }
        }

        public void Update(Trainer trainer)
        {
            using (var dataAccess = new TrainersRepo())
            {
                dataAccess.Edit(trainer);
            }
        }

        public void Delete(int trainerId)
        {
            using (var dataAccess = new TrainersRepo())
            {
                dataAccess.Remove(trainerId);
            }
        }

        public List<TrainingType> ReturnAllTrainingTypes()
        {
            using (var dataAccess = new TrainersRepo())
            {
                return dataAccess.GetAllTrainingTypes();
            }
        }

    }
}
