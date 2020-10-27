using BaseDatosFisica.Models;
using BaseDatosFisica.Models.ParaLasVistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaseDatosFisica.Controllers
{
    public class ResponderTestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private TestCurso_Pregunta tcp;
       
        // GET: ResponderTest
        public ActionResult Index()
        {
            return View(db.Tests.Where(m=>m.Visible));
        }

        // GET: ResponderTest/Details/5
        public ActionResult RespondeTest(int? idTest)
        {
            if(idTest == null )
                return HttpNotFound();

            Test test = db.Tests.Find(idTest);
            if (test == null)
                return HttpNotFound();
            
            return View(test);
        }
      
        [HttpPost]
        public ActionResult Test(string i)
        {
            return HttpNotFound(i);
        }
        
       public ActionResult Test(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Test tc = db.Tests.Find(id);

            if (tc == null)
                return HttpNotFound();

            Pregunta p = tc.TestPreguntas.First().Pregunta;

            tcp = new TestCurso_Pregunta { test = tc, pregunta = p, respuesta = ""};
            
            return Comienzo();
        }
        public ActionResult Comienzo()
        {
            if (tcp == null)
                return HttpNotFound("Null en comienzo");
            ViewBag.Num_pregunta = 1;
            ViewBag.Test = tcp.test.TestID;
            return View("Comienzo",tcp);
        }
        
        [HttpPost]
        public ActionResult Comienzo(string i)
        {
            return HttpNotFound(" Hola" + i);
        }
        // GET: ResponderTest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResponderTest/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ResponderTest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ResponderTest/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ResponderTest/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ResponderTest/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
