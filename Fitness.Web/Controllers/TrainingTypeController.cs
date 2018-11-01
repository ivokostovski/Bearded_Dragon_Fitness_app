using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fitness.Models;
using Fitness.Services;

namespace Fitness.Web.Controllers
{
    using Fitness.Models.ViewModels;

    public class TrainingTypeController : Controller
    {
        private FitnessManager manager = new FitnessManager();

        // GET: TrainingType
        public ActionResult Index()
        {
            var trainersList = manager.ReturnAll();
            var ttypesList = manager.ReturnAllTrainingTypes();
            var trainingTypesViewModel =
                new ListTrainingTypesViewModel() { Trainers = trainersList, TrainingTypes = ttypesList };

            return View(trainingTypesViewModel);
        }

        // GET: TrainingType/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingType trainingType = manager.ReturnTrainingType(id.Value);
            if (trainingType == null)
            {
                return HttpNotFound();
            }
            return View(trainingType);
        }

        // GET: TrainingType/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.TrainingTypes = manager.ReturnAllTrainingTypes();
            return View();
        }

        // POST: TrainingType/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrainingTypeId,Name,Description,ImagePath,ScheduleId")] TrainingType trainingType, HttpPostedFileBase imageTT)
        {
            if (ModelState.IsValid)
            {
                if (imageTT != null)
                {
                    trainingType.ImagePath = new byte[imageTT.ContentLength];
                    imageTT.InputStream.Read(trainingType.ImagePath, 0, imageTT.ContentLength);
                }

                manager.CreateTrainingType(trainingType);
                return RedirectToAction("Index");
            }

            return View(trainingType);
        }

        // GET: TrainingType/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingType trainingType = manager.ReturnTrainingType(id.Value);
            if (trainingType == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrainingTypes = manager.ReturnAllTrainingTypes();
            return View(trainingType);
        }

        // POST: TrainingType/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrainingTypeId,Name,Description,ImagePath,ScheduleId")] TrainingType trainingType, HttpPostedFileBase imageTT)
        {
            if (ModelState.IsValid)
            {
                if (imageTT != null)
                {
                    trainingType.ImagePath = new byte[imageTT.ContentLength];
                    imageTT.InputStream.Read(trainingType.ImagePath, 0, imageTT.ContentLength);
                }

                manager.UpdateTrainingType(trainingType);
                return RedirectToAction("Index");
            }
            return View(trainingType);
        }

        // GET: TrainingType/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingType trainingType = manager.ReturnTrainingType(id.Value);
            if (trainingType == null)
            {
                return HttpNotFound();
            }
            return View(trainingType);
        }

        // POST: TrainingType/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            manager.DeleteTrainingType(id);
            return RedirectToAction("Index");
        }
    }
}