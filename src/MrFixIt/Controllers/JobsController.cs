using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrFixIt.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MrFixIt.Controllers
{
    public class JobsController : Controller
    {
        private MrFixItContext db = new MrFixItContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Job job)
        {
            //var thisWorker = db.Workers.FirstOrDefault(item => item.UserName == User.Identity.Name);
            //job.Worker = thisWorker;
            //thisWorker.Avaliable = false;
            db.Jobs.Add(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AssignJob(Job job)
        {
            var thisWorker = db.Workers.FirstOrDefault(item => item.UserName == User.Identity.Name);
            job.Worker = thisWorker;
            thisWorker.Avaliable = false;
            db.Entry(job).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");   
        }
    }
}
