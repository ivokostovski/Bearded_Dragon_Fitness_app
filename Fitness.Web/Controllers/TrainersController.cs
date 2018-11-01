using Fitness.Models;
using Fitness.Services;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace Fitness.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

    using Fitness.Repo;

    public class TrainersController : Controller
    {
        private FitnessManager manager = new FitnessManager();

        // GET: Trainers
        public ActionResult Index()
        {
            ViewBag.data = manager.ReturnAllTrainingTypes();
            
            return View(manager.ReturnAll());
        }

        // GET: Trainers/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = manager.Return(id.Value);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // GET: Trainers/Create
        public ActionResult Create()
        {
            ViewBag.TrainingTypes = manager.ReturnAllTrainingTypes();
            return View();
        }

        // POST: Trainers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "TrainerId,FullName,Phone,Email,ShortBiography,ImagePath,TrainingTypeId")] Trainer trainer, HttpPostedFileBase image1)
        {
                if (ModelState.IsValid)
                {
                // Photo upload
                if (image1 != null)
                    {
                        trainer.ImagePath = new byte[image1.ContentLength];
                        image1.InputStream.Read(trainer.ImagePath, 0, image1.ContentLength);
                    }

                manager.Create(trainer);
                //manager.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainer);
        }

        // GET: Trainers/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = manager.Return(id.Value);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrainingTypes = manager.ReturnAllTrainingTypes();
            return View(trainer);
        }

        // POST: Trainers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "TrainerId,FullName,Phone,Email,ShortBiography,ImagePath,TrainingTypeId")] Trainer trainer, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                //photo upload
                if (image1 != null)
                {
                    trainer.ImagePath = new byte[image1.ContentLength];
                    image1.InputStream.Read(trainer.ImagePath, 0, image1.ContentLength);
                }

                manager.Update(trainer);
                //manager.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainer);
        }

        // GET: Trainers/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = manager.Return(id.Value);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            manager.Delete(id);
            return RedirectToAction("Index");
        }
    }
}