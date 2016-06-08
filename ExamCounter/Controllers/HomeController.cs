using ExamCounter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamCounter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CounterViewModel counterModel = DataService.DataSrvc.GetCounter(); ;
           
            return View(counterModel);
        }
        

        [HttpPost]
        public ActionResult Index(CounterViewModel mdl)
        {
            if(ModelState.IsValid)
            {
               if (mdl.Counter < 10)
               {
               mdl.Counter = mdl.Counter + 1;
               DataService.DataSrvc.StoreCounter(mdl);
               }

               return RedirectToAction("Index");

            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}