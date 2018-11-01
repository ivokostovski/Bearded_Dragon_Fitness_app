using System.Web.Mvc;
using System.Net;
using Fitness.Models;
using Fitness.Services;

namespace Fitness.Web.Controllers
{
    using System.Linq;

    using Fitness.Models.ViewModels;

    public class ScheduleController : Controller
    {
        private FitnessManager manager = new FitnessManager();

        // GET: Schedule
        public ActionResult Index()
        {
            var trainersList = manager.ReturnAll();
            var ttypesList = manager.ReturnAllTrainingTypes();
            var schedulesList = manager.ReturnAllSchedules();
            var scheduleViewModel =
                new CreateScheduleViewModel() { Trainers = trainersList, TrainingTypes = ttypesList, Schedules = schedulesList };

            return View(scheduleViewModel);
        }

        // GET: Schedule/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = manager.ReturnSchedule(id.Value);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // GET: Schedule/Create
        [Authorize]
        public ActionResult Create()
        {
            var trainersList = manager.ReturnAll();
            var ttypesList = manager.ReturnAllTrainingTypes();
            var schedulesList = manager.ReturnAllSchedules();
            var scheduleViewModel =
                new CreateScheduleViewModel() { Trainers = trainersList, TrainingTypes = ttypesList, Schedules = schedulesList };
            return View(scheduleViewModel);
        }

        // POST: Schedule/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScheduleId,Days,StartTime,EndTime,Gyms,TrainerId")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                var trainersList = manager.ReturnAll();
                var ttypesList = manager.ReturnAllTrainingTypes();

                foreach (var trainingType in ttypesList)
                {
                    foreach (var trainer in trainersList)
                    {      //first argument refers to Schedule TrainingTypeId
                        if (schedule.TrainerId == trainer.TrainingTypeId && trainer.TrainingTypeId == trainingType.TrainingTypeId)
                        {
                            schedule.TrainerId = trainer.TrainerId;
                        }
                    }
                }

                manager.CreateSchedule(schedule);
                return RedirectToAction("Index");
            }

            return View(schedule);
        }

        // GET: Schedule/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            var trainersList = manager.ReturnAll();
            var ttypesList = manager.ReturnAllTrainingTypes();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Schedule schedule = manager.ReturnSchedule(id.Value);

            if (schedule.ScheduleId == id.Value)
                {
                    foreach (var trainer in trainersList)
                    {
                        foreach (var trainingType in ttypesList)
                        {
                            if (schedule.TrainerId == trainer.TrainerId && trainer.TrainingTypeId == trainingType.TrainingTypeId)
                            {
                                schedule.TrainerId = trainer.TrainingTypeId;
                            }
                        }
                    }
                }
            
            ViewBag.ListOfTrainingTypes = manager.ReturnAllTrainingTypes();

            if (schedule == null)
            {
                return HttpNotFound();
            }

            return View(schedule);
        }

        // POST: Schedule/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScheduleId,Days,StartTime,EndTime,Gyms,TrainerId")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                var trainersList = manager.ReturnAll();
                var ttypesList = manager.ReturnAllTrainingTypes();

                foreach (var trainingType in ttypesList)
                {
                    foreach (var trainer in trainersList)
                    {      //first argument refers to Schedule TrainingTypeId
                        if (schedule.TrainerId == trainer.TrainingTypeId && trainer.TrainingTypeId == trainingType.TrainingTypeId)
                        {
                            schedule.TrainerId = trainer.TrainerId;
                        }
                    }
                }

                manager.UpdateSchedule(schedule);
                return RedirectToAction("Index");
            }
            return View(schedule);
        }

        // GET: Schedule/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = manager.ReturnSchedule(id.Value);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Schedule/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            manager.DeleteSchedule(id);
            return RedirectToAction("Index");
        }
    }
}