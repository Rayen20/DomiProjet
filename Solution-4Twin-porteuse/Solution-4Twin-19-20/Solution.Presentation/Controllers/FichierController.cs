using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class FichierController : Controller
    {
        IFichierService fichierService = null;
       // IProducerService producerService = null;
        public FichierController()
        {
            fichierService = new FichierService();
           // producerService = new ProducerService();
        }
    // GET: Fichier
    public ActionResult Index(string searchString)
        {
            var malisteVM = new List<FichierVM>();
            IEnumerable<Fichier> fichiers = fichierService.GetMany();

            if (!String.IsNullOrEmpty(searchString))
            {    //sans service
                //films = films.Where(f => f.Title.Contains(searchString));
                //avec service générique
                //films= fichierService.GetMany(f => f.Title.Contains(searchString));
                //avec service spécifique
              //  films = fichierService.GetFilmsByTitle(searchString);
            }
                foreach (Fichier film in fichiers)
            {
                FichierVM fvm = new FichierVM { 
                  Description= film.Description,
                  //Gender=(GenderVM)film.Gender,
                  ImageUrl= film.ImageUrl,
                  //OutDate=film.OutDate,
                  //Title=film.Title,
                 // ProducerId= film.ProducerId,
                  //name= film.Productor.FirstName
                };
                malisteVM.Add(fvm);
            }
            return View(malisteVM);
        }

     /*   // GET: Film/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }*/

      // GET: Fichier/Create
      public ActionResult Create()
        {
           
            return View();
        }

    // POST: Fichier/Create
    [HttpPost]
        public ActionResult Create(FichierVM FVM,HttpPostedFileBase file)
        {
            if (!ModelState.IsValid || file == null || file.ContentLength == 0)
            {
                RedirectToAction("Create");
            }
            Fichier filmDomain = new Fichier()
            {
                Description=FVM.Description,
                ImageUrl=file.FileName,
            
            };
            fichierService.Add(filmDomain);
            fichierService.Commit();
            //fichierService.Dispose();

            //ajout d'image dans le dossier
            if (file.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), file.FileName);
                file.SaveAs(path);
            }
            return RedirectToAction("Index");    
        }

      /*  // GET: Film/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Film/Edit/5
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

        // GET: Film/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Film/Delete/5
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
        }*/
    }
}
