using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.Models;

namespace Fitness.Repo
{
    internal class FitnessRegisterDbInitializer : DropCreateDatabaseAlways<FitnessRegisterDb>
    {
        protected override void Seed(FitnessRegisterDb context)
        {
            var trainers = new Models.Trainer();
            var trainingType = new Models.TrainingType()
                                   {
                                       Name = "BodyBuilding"
                                   };
            context.TrainingTypes.Add(new TrainingType() { Name = "CrossFit", Description = "CrossFit is a branded fitness regimen created by Greg Glassman and is a registered trademark of CrossFit, Inc. which was founded by Greg Glassman and Lauren Jenai in 2000." });
            context.TrainingTypes.Add(new TrainingType() { Name = "Boxing", Description = "Boxing is a combat sport in which two people, usually wearing protective gloves, throw punches at each other for a predetermined set of time in a boxing ring." });
            context.TrainingTypes.Add(new TrainingType() { Name = "Yoga", Description = "Yoga is a group of physical, mental, and spiritual practices or disciplines which originated in ancient India. There is a broad variety of yoga schools, practices, and goals in Hinduism, Buddhism, and Jainism. Among the most well-known types of yoga are Hatha yoga and Rāja yoga." });
            context.TrainingTypes.Add(new TrainingType() { Name = "Pilates", Description = "Pilates is a physical fitness system developed in the early 20th century by Joseph Pilates, after whom it was named." });
            context.TrainingTypes.Add(new TrainingType() { Name = "Jiu Jitsu", Description = "Jujutsu, also known in the West as Ju-Jitsu or Jiu-Jitsu, is a Japanese martial art and a method of close combat for defeating an armed and armored opponent in which one uses either a short weapon or none." });

            context.Trainers.Add(new Trainer()
            {
                FullName = "Dejan Jovanov",
                Phone = "078/123-456",
                Email = "Dejan@sedc.mk",
                ShortBiography = "Dejan has 2 years of Yoga experience",
                TrainingType = trainingType
            });
            context.Trainers.Add(new Trainer()
            {
                FullName = "Martin Panovski",
                Phone = "078/456-123",
                Email = "Martin@sedc.mk",
                ShortBiography = "Martin has 3 years of Pilates experience",
                TrainingType = trainingType
            });
            context.Trainers.Add(new Trainer()
            {
                FullName = "Sasho Damovski",
                Phone = "078/456-123",
                Email = "Sasho@sedc.mk",
                ShortBiography = "Saso has 6 years of Boxing experience",
                TrainingType = trainingType
            });
            context.Trainers.Add(new Trainer()
            {
                FullName = "Ivo Kostovski",
                Phone = "078/456-123",
                Email = "ivo@sedc.mk",
                ShortBiography = "Ivo has 5 years of Jiu Jitsu experience",
                TrainingType = trainingType
            });

            var schedules = new Models.Schedule()
                                {
                                    Days = EnumDays.Friday,
                                    StartTime = DateTime.Today,
                                    EndTime = DateTime.Now,
                                    Gyms = EnumGyms.Babylon,
                                    Trainer = trainers
                                };

            base.Seed(context);
        }
    }
}
