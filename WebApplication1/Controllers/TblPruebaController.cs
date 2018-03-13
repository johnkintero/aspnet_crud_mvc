using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class TblPruebaController : Controller
    {
        //se declara una variable de conexion hacia la BD
        private DBPruebaConexion dbcon = new DBPruebaConexion();
        // GET: TblPrueba
        public ActionResult Index()
        {
            return View(dbcon.tbl_prueba.ToList());
        }

        // GET: TblPrueba/Details/5
        public ActionResult Details(int? id)// con el signo de pregunta el parametro se vuelve opcional
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                tbl_prueba tbpruebaX = dbcon.tbl_prueba.Find(id);
                if (tbpruebaX == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(tbpruebaX);
                }
            }
            
        }

        // GET: TblPrueba/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TblPrueba/Create
        [HttpPost]
        public ActionResult Create(tbl_prueba tbprueba)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    dbcon.tbl_prueba.Add(tbprueba);
                    dbcon.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(tbprueba);
            }
            catch
            {
                return View(tbprueba);
            }
        }

        // GET: TblPrueba/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                tbl_prueba tbpruebaX = dbcon.tbl_prueba.Find(id);
                if (tbpruebaX == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(tbpruebaX);
                }
            }
        }

        // POST: TblPrueba/Edit/5
        [HttpPost]
        public ActionResult Edit(tbl_prueba tblpruebaX)//(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    dbcon.Entry(tblpruebaX).State = EntityState.Modified;
                    dbcon.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(tblpruebaX);
            }
            catch
            {
                return View(tblpruebaX);
            }
        }

        // GET: TblPrueba/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                tbl_prueba tbpruebaX = dbcon.tbl_prueba.Find(id);
                if (tbpruebaX == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(tbpruebaX);
                }
            }
        }

        // POST: TblPrueba/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, tbl_prueba tbpruebaX)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    tbpruebaX = dbcon.tbl_prueba.Find(id);
                    if (tbpruebaX == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        dbcon.tbl_prueba.Remove(tbpruebaX);
                        dbcon.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(tbpruebaX);
            }
            catch
            {
                return View(tbpruebaX);
            }
        }
    }
}
